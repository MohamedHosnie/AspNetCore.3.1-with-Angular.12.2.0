using ElectronicsShop.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        public User GetByUsername(string username);
        public Task<User> GetByUsernameAsync(string username);
    }
}
