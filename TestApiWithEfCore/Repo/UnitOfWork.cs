using System;
using TestApiWithEfCore.NewFolder;

namespace TestApiWithEfCore.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public IRepository<BasketModel> Baskets { get; }
        public IRepository<BasketLoanItem> BasketLoanItems { get; }
        public IRepository<Customer> Customers { get; }

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            Baskets = new Repository<BasketModel>(_context);
            BasketLoanItems = new Repository<BasketLoanItem>(_context);
            Customers = new Repository<Customer>(_context);
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}
