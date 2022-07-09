#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Contexts;
using Repository.Interfaces;

#endregion

namespace Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly BlogContext _blogContext;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(BlogContext blogContext)
        {
            _blogContext = blogContext;
            _dbSet = blogContext.Set<TEntity>();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _dbSet.AnyAsync(entity => entity.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _blogContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbSet.Update(entity);

            await _blogContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            _dbSet.Remove(entity);

            return Convert.ToBoolean(await _blogContext.SaveChangesAsync());
        }
    }
}