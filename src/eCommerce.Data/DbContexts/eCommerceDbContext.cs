using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Users;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User relations
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<User>(u => u.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Payments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.CreditCard)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.CreditCardId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region chat relations
            modelBuilder.Entity<Chat>()
                .HasOne(ch => ch.FirstUser)
                .WithMany(u => u.Chats)
                .HasForeignKey(ch => ch.FirstUserId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Chat>()
            //    .HasOne(ch => ch.SecondUser)
            //    .WithMany(u => u.Chats)
            //    .HasForeignKey(ch => ch.SecondUserId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(ch => ch.Messages)
                .HasForeignKey(m => m.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region product relations
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.SearchTags)
                .WithOne(st => st.Product)
                .HasForeignKey(st => st.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductSearchTag>()
                .HasOne(pst => pst.SearchTag)
                .WithMany(st => st.ProductSearchTags)
                .HasForeignKey(st => st.SearchTagId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region order relations
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion
        }

        #region Chats
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        #endregion

        #region Orders
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        #endregion

        #region Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSearchTag> ProductSearchTags { get; set; }
        public DbSet<SearchTag> SearchTags { get; set; }
        #endregion

        #region Users
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
