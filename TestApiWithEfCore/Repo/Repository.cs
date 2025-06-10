using Microsoft.EntityFrameworkCore;
using System;
using TestApiWithEfCore.NewFolder;

namespace TestApiWithEfCore.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SchoolContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SchoolContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
    }

}
