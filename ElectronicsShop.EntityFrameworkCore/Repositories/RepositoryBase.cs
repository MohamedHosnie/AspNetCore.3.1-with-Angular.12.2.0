using ElectronicsShop.Core;
using ElectronicsShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.EntityFrameworkCore.Repositories
{
    public class RepositoryBase<TEntity, TPrimaryKey, TDbContext> : IRepository<TEntity, TPrimaryKey>
        where TEntity : Entity<TPrimaryKey> where TDbContext : DbContext
    {
        public TDbContext _dbContext;
        public RepositoryBase()
        {
            _dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext));
        }
        public RepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Get(TPrimaryKey entityId)
        {
            TEntity entity = getDbSet().Where(e => e.Id.Equals(entityId)).FirstOrDefault();
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }

        public async Task<TEntity> GetAsync(TPrimaryKey entityId)
        {
            TEntity entity = await getDbSet().Where(e => e.Id.Equals(entityId)).FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }

        public TEntity GetIncluding(TPrimaryKey entityId, string navigationPropertyPath)
        {
            TEntity entity = getDbSet().Where(e => e.Id.Equals(entityId)).Include(navigationPropertyPath).FirstOrDefault();
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }

        public async Task<TEntity> GetIncludingAsync(TPrimaryKey entityId, string navigationPropertyPath)
        {
            TEntity entity = await getDbSet().Where(e => e.Id.Equals(entityId)).Include(navigationPropertyPath).FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Entity with the given ID is not found!");
            return entity;
        }

        public IList<TEntity> GetAll()
        {
            return getDbSet().ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await getDbSet().ToListAsync();
        }

        public IList<TEntity> GetAllIncluding(string navigationPropertyPath)
        {
            return getDbSet().Include(navigationPropertyPath).ToList();
        }

        public async Task<IList<TEntity>> GetAllIncludingAsync(string navigationPropertyPath)
        {
            return await getDbSet().Include(navigationPropertyPath).ToListAsync();
        }

        public TPrimaryKey Add(TEntity entity)
        {
            getDbSet().Add(entity);
            Save();

            return entity.Id;
        }

        public async Task<TPrimaryKey> AddAsync(TEntity entity)
        {
            await getDbSet().AddAsync(entity);
            await SaveAsync();

            return entity.Id;
        }

        public void Update(TPrimaryKey entityId, TEntity entity)
        {
            TEntity original = getDbSet().Where(e => e.Id.Equals(entityId)).FirstOrDefault();
            if (original == null) throw new Exception("Entity with the given ID is not found!");

            PropertyInfo[] properties = typeof(TEntity).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(entity) != null)
                {
                    property.SetValue(original, property.GetValue(entity));
                }
            }

            Save();
        }

        public async Task UpdateAsync(TPrimaryKey entityId, TEntity entity)
        {
            TEntity original = getDbSet().Where(e => e.Id.Equals(entityId)).FirstOrDefault();
            if (original == null) throw new Exception("Entity with the given ID is not found!");

            PropertyInfo[] properties = typeof(TEntity).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(entity) != null)
                {
                    property.SetValue(original, property.GetValue(entity));
                }
            }

            await SaveAsync();
        }

        public bool Delete(TPrimaryKey entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TPrimaryKey entityId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private DbSet<TEntity> getDbSet()
        {
            string typeName = typeof(TEntity).FullName;
            DbSet<TEntity> dbSet = _dbContext.Set<TEntity>(typeName);
            return dbSet;
        }
    }
}
