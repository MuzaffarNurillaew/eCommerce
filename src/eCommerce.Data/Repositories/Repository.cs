using eCommerce.Data.IRepositories;

namespace eCommerce.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllAsync(Predicate<TEntity> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByAsync(Predicate<TEntity> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity teintity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity teintity)
        {
            throw new NotImplementedException();
        }
    }
}
