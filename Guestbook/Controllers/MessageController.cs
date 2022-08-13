using Guestbook.Contracts;
using Guestbook.Dto.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guestbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepo;
        public MessageController(IMessageRepository messageRepo) =>
           _messageRepo = messageRepo;


        [HttpPost]
        [Route("AddMessage")]
        public async Task<IActionResult> AddNewMessage([FromBody] MessageForCreationDto newMessage)
        {
            try
            {
                //Pass Data To Function Create message
                var CreatedMessage = await _messageRepo.AddNewMessage(newMessage);
                //Return New Object From Message
                return Ok(new
                {
                    id = CreatedMessage.Id,
                    MessageBody = CreatedMessage.MessageBody,
                    IsReplay = CreatedMessage.IsReplay,
                    UserId = CreatedMessage.UserId,
                    username = CreatedMessage.User.Name

                });
            }
            catch
            {
                return BadRequest();
            }

            
        }

    }
}
