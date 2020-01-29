using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogApi.Domain;

namespace ProductCatalogApi.Data
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            builder.Entity<CatalogType>(ConfiguringCatalogType);
            builder.Entity<CatalogItem>(ConfigureCatalogItem);
        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(item => item.Id)
                .UseHiLo("catalog_hilo")
                .IsRequired(true);

            builder.Property(item => item.Name)
                .IsRequired(true)
                .HasMaxLength(2000);

            builder.Property(item => item.Price).HasColumnType("decimal(10,2)")
                .IsRequired(true);

            builder.Property(item => item.PictureFileName)
                .IsRequired(true);

            builder.Property(item => item.PictureUrl)
                .IsRequired(true);

            builder.HasOne(item => item.CatalogBrand)
                .WithMany().HasForeignKey(item => item.CatalogBrandId);

            builder.HasOne(item => item.CatalogType)
                .WithMany().HasForeignKey(item => item.CatalogTypeId);
        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");
            builder.Property(item=> item.Id)
                .UseHiLo("catalog_brand_hilo")
                .IsRequired(true);

            builder.Property(item => item.Brand)
                .IsRequired(true)
                .HasMaxLength(2000);
        }

        private void ConfiguringCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.Property(item => item.Id)
                .UseHiLo("catalog_type_hilo")
                .IsRequired(true);

            builder.Property(item => item.Type)
                .IsRequired(true)
                .HasMaxLength(2000);
        }


    }
}
