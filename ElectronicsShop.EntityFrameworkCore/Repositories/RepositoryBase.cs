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
    public class RepositoryBase<TEntity, TPrimaryKey, TDbContext> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey> where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        protected RepositoryBase()
        {
            _dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext));
        }
        protected RepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Get(TPrimaryKey entityId)
        {
            TEntity entity = _dbSet.FirstOrDefault(e => e.Id.Equals(entityId));
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }
        
        public async Task<TEntity> GetAsync(TPrimaryKey entityId)
        {
            TEntity entity = await _dbSet.FirstOrDefaultAsync(e => e.Id.Equals(entityId));
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

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
            IQueryable<TEntity> query = _dbSet;

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
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TPrimaryKey entityId, TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TPrimaryKey entityId)
        {
            var entityToDelete = _dbSet.Find(entityId);
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public async Task DeleteAsync(TPrimaryKey entityId)
        {
            var entityToDelete = await _dbSet.FindAsync(entityId);
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public int Save()
        {
            int result = _dbContext.SaveChanges();
            return result;
        }

        public async Task<int> SaveAsync()
        {
            int result = await _dbContext.SaveChangesAsync();
            return result;
        }

    }
}
