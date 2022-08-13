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
        [Route("AddMessageAndReplay")]
        public async Task<IActionResult> AddNewMessage([FromBody] MessageForCreationDto newMessage)
        {
            try
            {
                //Check If User Want Add Repaly and he Send The ID Of Main Message 
                if (newMessage.IsReplay == 1 && newMessage.MainMessageId > 0)
                {
                    //Get Message by Id
                    var MainMessage = await _messageRepo.GetMessage(newMessage.MainMessageId);
                    //If not Found (If If Deleted) He Can't Add Replay
                    if (MainMessage == null)
                        //Return Not Found
                        return NotFound();
                }

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
