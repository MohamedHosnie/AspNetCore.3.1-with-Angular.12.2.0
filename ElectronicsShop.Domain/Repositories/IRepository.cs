using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        TEntity Get(TPrimaryKey entityId);
        Task<TEntity> GetAsync(TPrimaryKey entityId);
        IQueryable<TEntity> GetIQueryable(TPrimaryKey entityId);
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllIQueryable();
        TPrimaryKey Add(TEntity entity);
        Task<TPrimaryKey> AddAsync(TEntity entity);
        void Update(TPrimaryKey entityId, TEntity entity);
        Task UpdateAsync(TPrimaryKey entityId, TEntity entity);
        bool Delete(TPrimaryKey entityId);
        Task<bool> DeleteAsync(TPrimaryKey entityId);
        void Save();
        Task SaveAsync();
    }
}
