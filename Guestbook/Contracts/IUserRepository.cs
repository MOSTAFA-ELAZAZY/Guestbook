﻿using Guestbook.Dto.user;
using Guestbook.Entities;

namespace Guestbook.Contracts
{
    public interface IUserRepository
    {
        //Create Interface for Login Function 
        public Task<User> Login(string email, string password = "");

        public Task<User> Register(UserForCreationDto NewUser);
    }
}
