using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using webApi.Domain.Entities;

namespace webApi.Repositories
{
    public class Repository <T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _dbContext = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(long id)
        {
            return _entities.Single(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity, long id)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            _entities.Where(x => x.Id == id).Delete();
            _dbContext.SaveChanges();
        }
    }
}
