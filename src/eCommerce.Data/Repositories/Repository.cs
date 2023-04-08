using eCommerce.Data.DbContexts;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly eCommerceDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        public Repository(eCommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }
        #region delete
        /// <summary>
        /// Deletes information in database
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>true if action is successful, false if unable to delete</returns>
        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await this.SelectAsync(expression);

            if (entity is not null)
            {
                this.dbSet.Remove(entity);
                return true;
            }

            return false;
        }
        #endregion

        #region insert
        /// <summary>
        /// Inserts element to a table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var entry = await this.dbSet.AddAsync(entity);

            return entry.Entity;
        }
        #endregion

        #region save
        /// <summary>
        /// saves tracking changes
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
        #endregion

        #region select all
        /// <summary>
        /// Selects all element of table
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> SelectAll() => this.dbSet;
        #endregion

        #region select
        /// <summary>
        /// selects element from a table specified with expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
            => await this.dbSet.FirstOrDefaultAsync(expression);
        #endregion

        #region update
        /// <summary>
        /// updates element in the table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = this.dbSet.Update(entity);

            return await Task.FromResult(entry.Entity);
        }
        #endregion

    }
}

