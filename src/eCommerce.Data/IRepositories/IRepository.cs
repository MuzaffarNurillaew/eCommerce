namespace eCommerce.Data.IRepositories
{

    public interface IRepository<TEintity>
    {
        Task<TEintity> InsertAsync(TEintity teintity);
        Task<TEintity> UpdateAsync(TEintity teintity);
        Task<bool> DeleteAsync(int id);
        Task<TEintity> GetByAsync(Predicate<TEintity> predicate = null);

        IQueryable<TEintity> GetAllAsync(Predicate<TEintity> predicate = null);
    }
}
