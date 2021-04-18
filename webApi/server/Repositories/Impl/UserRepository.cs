using System;
using System.Linq;
using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using webApi;
using webApi.Domain.Entities;

namespace server.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private DbSet<UserEntity> _entities;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<UserEntity>();
        }

        public UserEntity GetUserEntityByUsername(string login)
        {
            UserEntity userEntity = _entities.Where(s => s.Login == login).FirstOrDefault();

            if (userEntity == null)
            {
                throw new AuthenticationException("Wrong credentials");
            }

            return userEntity;
        }
    }
}
