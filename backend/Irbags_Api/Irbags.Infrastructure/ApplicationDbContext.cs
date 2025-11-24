using Irbags.Core.Order;
using Irbags.Core.Product;
using Irbags.Core.User;
using Microsoft.EntityFrameworkCore;


namespace Irbags.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Таблицы (агрегатные корни и явные join-таблицы)
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> Tags { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<ProductColorSize> ProductColorSizes { get; set; }
        public DbSet<ProductCard> ProductCards { get; set; }
        public DbSet<ProductBanner> ProductBanners { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.Id);
                user.HasIndex(u => u.Login).IsUnique();

                user.HasOne(u => u.Token)
                    .WithOne(t => t.User)
                    .HasForeignKey<Token>(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Token>(token =>
            {
                token.HasKey(t => t.Id);
                token.Property(t => t.RefreshToken).IsRequired();
            });

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Tag)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.TagId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductColorSize>()
                .HasOne(pcs => pcs.Product)
                .WithMany(p => p.ProductColorSizes)
                .HasForeignKey(pcs => pcs.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductColorSize>()
                .HasOne(pcs => pcs.Color)
                .WithMany(c => c.ProductColorSizes)
                .HasForeignKey(pcs => pcs.ColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductColorSize>()
                .HasOne(pcs => pcs.Size)
                .WithMany(s => s.ProductColorSizes)
                .HasForeignKey(pcs => pcs.SizeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(p => p.ShortDescription)
                .HasMaxLength(150);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(255);

            modelBuilder.Entity<ProductSize>()
                .Property(s => s.Size)
                .HasMaxLength(10);

            modelBuilder.Entity<ProductTag>()
                .Property(t => t.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<ProductColor>()
                .Property(c => c.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Order>(order =>
            {
                order.Property(o => o.ProductId).IsRequired();

                order.OwnsOne(o => o.Name, name =>
                {
                    name.Property(n => n.FirstName).HasMaxLength(60).IsRequired();
                    name.Property(n => n.LastName).HasMaxLength(60).IsRequired();
                });

                order.OwnsOne(o => o.DeliveryAddress, addr =>
                {
                    addr.Property(a => a.Address).HasMaxLength(250).IsRequired();
                    addr.Property(a => a.City).HasMaxLength(250).IsRequired();
                });

                order.OwnsOne(o => o.Phone, phone =>
                {
                    phone.Property(p => p.Value).HasMaxLength(20).IsRequired();
                });

                order.OwnsOne(o => o.Email, email =>
                {
                    email.Property(e => e.Value).HasMaxLength(25).IsRequired();
                });

                order.Property(o => o.DeliveryType).HasConversion<int>();
                order.Property(o => o.PaymentType).HasConversion<int>();
            });

            // Индексы/уникальности при необходимости:
            // modelBuilder.Entity<ProductColorSize>().HasIndex(pcs => new { pcs.ProductId, pcs.ColorId, pcs.SizeId }).IsUnique();
        }
    }
}
