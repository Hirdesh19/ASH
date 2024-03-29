﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASHEmployee.Data;
using Microsoft.EntityFrameworkCore;

namespace ASHEmployee.Repository
{
    public abstract  class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext:DbContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            this._context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity =await  _context.Set<TEntity>().FindAsync(id);
            if(entity==null)
            {
                return entity;
            }
            _context.Set<TEntity>().Remove(entity);
             await _context.SaveChangesAsync();
            return entity;
        }

        public async  Task<TEntity> Get(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var entityList = await _context.Set<TEntity>().ToListAsync();
            return entityList;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
