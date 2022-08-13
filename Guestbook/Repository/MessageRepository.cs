using Dapper;
using Guestbook.Context;
using Guestbook.Contracts;
using Guestbook.Dto.Message;
using Guestbook.Entities;
using Guestbook.Enums;
using System.Data;
using static Dapper.SqlMapper;
using static Guestbook.Enums.SharedEnums;

namespace Guestbook.Repository
{

    public class MessageRepository : IMessageRepository
    {
        private readonly DbContext _context;

        public MessageRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Message> AddNewMessage(MessageForCreationDto NewMessage)
        {
            //Create Insert
            var query = "INSERT INTO Messages(Message, IsReplay, UserId,Status,MainMessageId) VALUES(@Message, @IsReplay, @UserId,@Status,@MainMessageId) " +
                //Return Primary Key Added In the Table In the Same Scope
                "Select CAST(SCOPE_IDENTITY() AS int) " +
                //Return name For Use Added This Message To Use It to View Message By Name 
                "Select Name from Users where id= @UserId ";
            //Set Parameter
            var Paramters = new DynamicParameters();
            Paramters.Add("Message", NewMessage.Message, DbType.String);
            Paramters.Add("IsReplay", NewMessage.IsReplay, DbType.Int32);
            Paramters.Add("UserId", NewMessage.UserId, DbType.Int32);
            Paramters.Add("Status", (int)SharedEnums.Status.Active, DbType.Int32);
            Paramters.Add("MainMessageId", NewMessage.MainMessageId, DbType.Int32);

            //Open Connection
            using var connection = _context.CreateConnection();
            //Create Run For Query 
            GridReader Result = await connection.QueryMultipleAsync(query, Paramters);
            //Get Data Retern Deon Multiple Query We Run It 
            int id = Result.ReadFirst<int>();
            //Get Data Of Sacaend Query We Run It 
            IEnumerable<User> users = Result.Read<User>();
            //Create New Obj From Message
            var MessageCreated = new Message
            {
                Id = id,
                MessageBody = NewMessage.Message,
                IsReplay = NewMessage.IsReplay,
                UserId = NewMessage.UserId,
                User = new User { Name = users.First().Name }

            };
            //Return Object 
            return MessageCreated;
        }

        public async Task<Message> GetMessage(int Id, int UserId)
        {
            //Select message If it Active That Mean it's not Deleted
            string query = "Select * from Messages where Id = @Id and  Status = @Status ";
            //if We Want Chek We userId 
            if (UserId > 0)
            {
                query = query + " and UserId=@UserId ";
            }
            //open Connection
            using (var connection = _context.CreateConnection())
            {
                //Run Quray 
                var message = await connection.QueryFirstOrDefaultAsync<Message>(query, new { Id, Status = Status.Active, UserId });
                //Return Message
                return message;
            }
        }
    }
}
