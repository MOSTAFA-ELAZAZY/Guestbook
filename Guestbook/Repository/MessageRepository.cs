using Guestbook.Context;
using Guestbook.Contracts;

namespace Guestbook.Repository
{

    public class MessageRepository : IMessageRepository
    {
        private readonly DbContext _context;

        public MessageRepository(DbContext context)
        {
            _context = context;
        }
    }
}
