using System;
using server.Domain.Models;
using server.Utils;
using webApi.Domain.Entities;

namespace server.Mappers.Impl
{
    public class UserMapper : IUserMapper
    {
        public UserMapper()
        {
        }

        public UserEntity UserCreateToUserEntity(UserCreate user)
        {
            return new UserEntity()
            {
                Login = user.Login,
                Password = CommonUtils.EncodePasswordToBase64(user.Password),
                Email = user.Email,
                IsActive = true
            };
        }
    }
}
