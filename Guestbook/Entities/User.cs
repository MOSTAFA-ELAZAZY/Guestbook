﻿using static Guestbook.Enums.SharedEnums;

namespace Guestbook.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Gender Gender { get; set; }
    }
}
