using Guestbook.Contracts;
using Guestbook.Dto.user;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Guestbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo) =>
            _userRepo = userRepo;

        //We Use Http Post In Login To Send DataBody (Best Practice)
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserForLoginDto UserForLoginDto)
        {
            //Send Data From User To Function 
            var user = await _userRepo.Login(UserForLoginDto.Email, UserForLoginDto.Password);
            //If Email Or Password are Wrong Return Not Found 404 Erorr Code
            if (user == null)
                return NotFound();
            //If Found Id 
            return Ok(user);
        }
    }
}
