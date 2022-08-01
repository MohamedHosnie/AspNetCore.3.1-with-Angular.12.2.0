using ElectronicsShop.Domain.Repositories;

namespace ElectronicsShop.EntityFrameworkCore.Repositories
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private IUnitOfWork _unitOfWork;
        
        public IUnitOfWork Begin()
        {
            this._unitOfWork = new UnitOfWork();
            return this._unitOfWork;
        }

        public IUnitOfWork Current => _unitOfWork;
    }
}