using Guestbook.Dto.Message;
using Guestbook.Entities;

namespace Guestbook.Contracts
{
    public interface IMessageRepository
    {
        public Task<Message> AddNewMessage(MessageForCreationDto NewMessage);
    }
}
