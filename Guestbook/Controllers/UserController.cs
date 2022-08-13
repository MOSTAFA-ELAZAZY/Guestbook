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
            try
            {
                //Send Data From User To Function 
                var user = await _userRepo.Login(UserForLoginDto.Email, UserForLoginDto.Password);
                //If Email Or Password are Wrong Return Not Found 404 Erorr Code
                if (user == null)
                    return NotFound();
                //If Found Id 
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserForCreationDto NewUser)
        {
            try
            {
                //First Check If Email Is In DataBase Or Not
                var user = await _userRepo.Login(NewUser.Email, "");
                //User Not Equl Null That Mean We Found This Mail In Data Base
                if (user != null)
                    return NotFound();

                //Else We Create New User
                var CreatedUser = await _userRepo.Register(NewUser);
                //And Return Data
                return Ok(new
                {
                    id = CreatedUser.Id,
                    Name = CreatedUser.Name,
                    Email = CreatedUser.Email,
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
