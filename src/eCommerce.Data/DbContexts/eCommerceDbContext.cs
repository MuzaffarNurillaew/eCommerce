using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.DbContexts
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
