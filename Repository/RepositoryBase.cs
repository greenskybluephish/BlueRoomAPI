﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Entities.Context;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly BlueRoomContext _repositoryContext;

        protected RepositoryBase(BlueRoomContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
                _repositoryContext.Set<T>()
                    .AsNoTracking() :
                _repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
            bool trackChanges) =>
            !trackChanges ?
                _repositoryContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking() :
                _repositoryContext.Set<T>()
                    .Where(expression);
        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
    }
}