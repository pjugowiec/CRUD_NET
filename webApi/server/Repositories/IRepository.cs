﻿using System;
using System.Collections.Generic;
using webApi.Domain.Entities;

namespace webApi.Repositories
{
    public interface IRepository <T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity, long id);
        void Delete(long id);
    }
}