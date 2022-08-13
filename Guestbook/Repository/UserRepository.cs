using Dapper;
using Guestbook.Context;
using Guestbook.Contracts;
using Guestbook.Dto.user;
using Guestbook.Entities;
using System.Data;

namespace Guestbook.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;


        public UserRepository(DbContext context) =>
            _context = context;

        public async Task<User> Login(string email, string password = "")
        {

            // Create Select Statment 
            var query = "Select [Id],[Name],[Email],[Gender] From Users Where Email = @Email ";
            //I Create This Validation For Use It When We Check If Email 
            //alredy add in DataBase Or Not
            if (!password.Length.Equals(0))
                query = query + " and Password = @Password ";
            //Open Connection
            using var connection = _context.CreateConnection();
            //Get Data of User 
            var User = await connection.QuerySingleOrDefaultAsync<User>(query, new { email, password });
            //Return Data
            return User;
        }

        public async Task<User> Register(UserForCreationDto NewUser)
        {
            var query = "INSERT INTO Users (Name,Email,Password,Gender) VALUES (@Name,@Email,@Password,@Gender) " +
                "Select CAST(SCOPE_IDENTITY() AS int) ";

            var Paramters = new DynamicParameters();
            Paramters.Add("Name", NewUser.Name, DbType.String);
            Paramters.Add("Email", NewUser.Email, DbType.String);
            Paramters.Add("Password", NewUser.Password, DbType.String);
            Paramters.Add("Gender", NewUser.Gender, DbType.String);

            using var connection = _context.CreateConnection();

            var id = await connection.QuerySingleAsync<int>(query, Paramters);

            var USerCreated = new User
            {
                Name = NewUser.Name,
                Email = NewUser.Email,
                Gender = NewUser.Gender,
                Id = id,
                Password = ""

            };
            return USerCreated;
        }
    }
}
