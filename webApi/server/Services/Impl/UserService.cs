using System;
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

        // <summary>Check the correctness of passwords</summary>
        // <param name="passIncoming">Argument of type String containing the password from the DTO</param>
        // <param name="passUser">Argument of type String containing the password from the user</param>
        // <exception>AuthenticationException when credentials are incorrect</exception>
        private void ValidatePassword(string passIncoming, string passUser)
        {
            if (!CommonUtils.CheckPasswordsSame(passIncoming, passUser))
            {
                throw new AuthenticationException("Wrong credentials");
            }
        }


    }
}
