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
                .HasForeignKey(ch => ch.FirstUserId);

            modelBuilder.Entity<Chat>()
                .HasOne(ch => ch.SecondUser)
                .WithMany(u => u.Chats)
                .HasForeignKey(ch => ch.SecondUserId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(ch => ch.Messages)
                .HasForeignKey(m => m.ChatId);
            #endregion

            #region product relations
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.SearchTags)
                .WithOne(st => st.Product)
                .HasForeignKey(st => st.ProductId);

            modelBuilder.Entity<ProductSearchTag>()
                .HasOne(pst => pst.SearchTag)
                .WithMany(st => st.ProductSearchTags)
                .HasForeignKey(st => st.SearchTagId);
            #endregion

            #region order relations
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId);
            #endregion
        }
    }
}
