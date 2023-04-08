using eCommerce.Data.IRepositories;
using eCommerce.Domain.Commons;

namespace eCommerce.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Auditable
    {
    }
}