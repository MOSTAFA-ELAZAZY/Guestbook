using static Guestbook.Enums.SharedEnums;

namespace Guestbook.Dto.user
{
    public class UserForCreationDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Gender Gender { get; set; }
    }
}
