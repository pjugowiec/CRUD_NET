﻿using System;
using System.Security.Authentication;
using server.Domain.Annotations;
using server.Domain.Models;
using server.Repositories;
using server.Utils;
using webApi.Domain.Entities;

namespace server.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Transactional]
        public void CheckCredentials(LoginForm loginForm)
        {
            UserEntity userEntity = _userRepository.GetUserEntityByUsername(loginForm.Login);

            ValidatePassword(loginForm.Login, userEntity.Login);

        }

        private void ValidatePassword(string passIncoming, string passUser)
        {
            if (!CommonUtils.CheckPasswordsSame(passIncoming, passUser))
            {
                throw new AuthenticationException("Wrong credentials");
            }
        }


    }
}
