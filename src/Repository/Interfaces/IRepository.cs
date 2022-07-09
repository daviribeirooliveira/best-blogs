#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Entities;

#endregion

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<bool> Exists(Guid id);

        public Task<IEnumerable<TEntity>> GetAll();

        public Task<TEntity> Get(Guid id);

        public Task<TEntity> Create(TEntity entity);

        public Task<TEntity> Update(TEntity entity);

        public Task<bool> Delete(Guid id);
    }
}