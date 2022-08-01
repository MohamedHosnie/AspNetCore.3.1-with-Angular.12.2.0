using System;
using System.Threading.Tasks;

namespace ElectronicsShop.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        dynamic DbContext { get; }
        bool IsDisposed { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}