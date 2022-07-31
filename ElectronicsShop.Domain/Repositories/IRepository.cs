using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        TEntity Get(TPrimaryKey entityId);
        Task<TEntity> GetAsync(TPrimaryKey entityId);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TPrimaryKey entityId, TEntity entity);
        void Delete(TPrimaryKey entityId);
        Task DeleteAsync(TPrimaryKey entityId);
        int Save();
        Task<int> SaveAsync();
    }
}
