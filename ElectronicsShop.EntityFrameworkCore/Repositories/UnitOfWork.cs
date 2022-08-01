using System;
using System.Threading.Tasks;
using ElectronicsShop.Domain.Repositories;

namespace ElectronicsShop.EntityFrameworkCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElectronicsShopDbContext _context = null;
        
        private bool _disposed = false;

        public dynamic DbContext => _context;

        public bool IsDisposed => _disposed;

        public UnitOfWork()
        {
            _context = new ElectronicsShopDbContext();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}