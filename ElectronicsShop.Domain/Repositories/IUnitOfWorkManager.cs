namespace ElectronicsShop.Domain.Repositories
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork Current { get; }
        IUnitOfWork Begin();
    }
}