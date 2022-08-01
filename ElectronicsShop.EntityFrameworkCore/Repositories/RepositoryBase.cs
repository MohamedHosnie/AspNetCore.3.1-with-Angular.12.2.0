using ElectronicsShop.Domain;
using ElectronicsShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicsShop.EntityFrameworkCore.Repositories
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey>
    {
        private readonly ElectronicsShopDbContext _dbContext;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private DbSet<TEntity> DbSet => _unitOfWorkManager.Current == null || _unitOfWorkManager.Current.IsDisposed ? _dbContext.Set<TEntity>()
                : (_unitOfWorkManager.Current.DbContext as ElectronicsShopDbContext)?.Set<TEntity>();
        
        private ElectronicsShopDbContext DbContext => _unitOfWorkManager.Current == null || _unitOfWorkManager.Current.IsDisposed ? _dbContext
            : (_unitOfWorkManager.Current.DbContext as ElectronicsShopDbContext);

        protected RepositoryBase(ElectronicsShopDbContext dbContext, IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _dbContext = dbContext;
        }

        public TEntity Get(TPrimaryKey entityId)
        {
            TEntity entity = DbSet.FirstOrDefault(e => e.Id.Equals(entityId));
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }
        
        public async Task<TEntity> GetAsync(TPrimaryKey entityId)
        {
            TEntity entity = await DbSet.FirstOrDefaultAsync(e => e.Id.Equals(entityId));
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.FirstOrDefault(filter);
        }
        
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.FirstOrDefaultAsync(filter);
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var includePropertiesArray = includeProperties.Split(new[] { ',' }, 
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var includeProperty in includePropertiesArray)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var includePropertiesArray = includeProperties.Split(new[] { ',' }, 
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var includeProperty in includePropertiesArray)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Update(TPrimaryKey entityId, TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TPrimaryKey entityId)
        {
            var entityToDelete = DbSet.Find(entityId);
            Delete(entityToDelete);
        }

        public async Task DeleteAsync(TPrimaryKey entityId)
        {
            var entityToDelete = await DbSet.FindAsync(entityId);
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            Delete(entityToDelete);
        }
        
        public void Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public int Save()
        {
            int result = DbContext.SaveChanges();
            return result;
        }

        public async Task<int> SaveAsync()
        {
            int result = await DbContext.SaveChangesAsync();
            return result;
        }

    }
}
