using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers
{
    public interface IUserMapper
    {
        public UserEntity UserModifyToUserEntity(UserModify user);
        public UserEntity UpdateUserEntityByUserModify(UserModify user, UserEntity userEntity);
    }
}
