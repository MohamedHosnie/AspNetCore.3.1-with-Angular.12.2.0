using ElectronicsShop.Domain;
using ElectronicsShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.EntityFrameworkCore.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey, ElectronicsShopDbContext>,
        IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        public Repository() : base()
        {
        }

        public Repository(ElectronicsShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
