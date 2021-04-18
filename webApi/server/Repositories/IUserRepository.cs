using System;
using webApi.Domain.Entities;

namespace server.Repositories
{
    public interface IUserRepository
    {
        public UserEntity GetUserEntityByUsername(string login);
    }
}
