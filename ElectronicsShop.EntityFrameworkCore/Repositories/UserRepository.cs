using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Core.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.EntityFrameworkCore.Repositories
{
    public class UserRepository : RepositoryBase<User, int, ElectronicsShopDbContext>, IUserRepository
    {
        public UserRepository() : base()
        {
        }

        public UserRepository(ElectronicsShopDbContext dbContext) : base(dbContext)
        {
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }
    }
}
