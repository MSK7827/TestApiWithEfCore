using TestApiWithEfCore.NewFolder;

namespace TestApiWithEfCore.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<BasketModel> Baskets { get; }
        IRepository<BasketLoanItem> BasketLoanItems { get; }
        IRepository<Customer> Customers { get; }
        Task<int> CompleteAsync();
    }

}
