using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers
{
    public interface IUserMapper
    {
        public UserEntity UserCreateToUserEntity(UserCreate user);
        public UserEntity UpdateUserEntityByUserCreate(UserCreate user, UserEntity userEntity);
    }
}
