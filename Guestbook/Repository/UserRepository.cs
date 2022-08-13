using Dapper;
using Guestbook.Context;
using Guestbook.Contracts;
using Guestbook.Entities;

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
    }
}
