using Guestbook.Dto.Message;
using Guestbook.Entities;

namespace Guestbook.Contracts
{
    public interface IMessageRepository
    {
        public Task<Message> AddNewMessage(MessageForCreationDto NewMessage);
        public Task<Message> GetMessage(int Id, int UserId = 0);
        public Task EditMessage(int id, string massage);
        public Task DeleteMessage(int id, int userId);
    }
}
