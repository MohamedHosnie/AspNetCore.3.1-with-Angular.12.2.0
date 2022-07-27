using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Core
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        TEntity Get(TPrimaryKey entityId);
        Task<TEntity> GetAsync(TPrimaryKey entityId);
        TEntity GetIncluding(TPrimaryKey entityId, string navigationPropertyPath);
        Task<TEntity> GetIncludingAsync(TPrimaryKey entityId, string navigationPropertyPath);
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        IList<TEntity> GetAllIncluding(string navigationPropertyPath);
        Task<IList<TEntity>> GetAllIncludingAsync(string navigationPropertyPath);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TPrimaryKey entityId, TEntity entity);
        Task UpdateAsync(TPrimaryKey entityId, TEntity entity);
        bool Delete(TPrimaryKey entityId);
        Task<bool> DeleteAsync(TPrimaryKey entityId);
        void Save();
        Task SaveAsync();
    }
}
