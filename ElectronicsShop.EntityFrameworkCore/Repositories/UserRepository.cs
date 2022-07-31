using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Domain.Users;
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
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
