using System.Linq.Expressions;

namespace eCommerce.Data.IRepositories
{

    public interface IRepository<TEntity>
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> SelectAll();
        Task SaveAsync();
    }
}
