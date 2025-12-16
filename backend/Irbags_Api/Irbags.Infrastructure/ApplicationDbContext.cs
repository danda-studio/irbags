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

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTag> Tags { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<BannerBlock> ProductCards { get; set; }
        public DbSet<ProductBlock> ProductBanners { get; set; }
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

            // Many-to-many: Product/ProductColor 
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Colors)
                .WithMany(c => c.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "product_color_size",
                    right => right
                        .HasOne<ProductColor>()
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Restrict),
                    left => left
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade),
                    join =>
                    {
                        join.HasKey("ProductId", "ColorId");
                        join.ToTable("product_color_size");
                        join.Property<Guid>("ProductId");
                        join.Property<Guid>("ColorId");
                    });

            // One-to-One: ProductImage/BannerBlock 
            modelBuilder.Entity<ProductImage>(pi =>
            {
                pi.HasKey(x => x.Id);
                pi.HasOne(x => x.Product)
                  .WithMany(p => p.Images)
                  .HasForeignKey("ProductId") // nullable FK generated if no property
                  .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BannerBlock>(bb =>
            {
                bb.HasKey(b => b.Id);

                // One-to-One: BannerBlock.ImageId -> ProductImage.Id 
                bb.HasOne(b => b.Image)
                  .WithOne(i => i.BannerBlock)
                  .HasForeignKey<BannerBlock>(b => b.ImageId)
                  .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>()
                .Property(p => p.ShortDescription)
                .HasMaxLength(150);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(255);

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
            // modelBuilder.Entity<Dictionary<string, object>>("product_color_size")
            //     .HasIndex("ProductId", "ColorId").IsUnique();
        }
    }
}
