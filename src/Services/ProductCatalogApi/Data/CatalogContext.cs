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


            builder.Entity<CatalogBrand>().HasData(
                new CatalogBrand() {Id=1, Brand = "Addidas" },
                new CatalogBrand() {Id=2, Brand = "Puma" },
                new CatalogBrand() {Id=3, Brand = "Slazenger" });

            builder.Entity<CatalogType>().HasData(
               new CatalogType() { Id=1, Type = "Running" },
               new CatalogType() { Id=2, Type = "Basketball" },
               new CatalogType() { Id=3, Type = "Tennis" });

            builder.Entity<CatalogItem>().HasData(
                new CatalogItem() { Id = 1, CatalogTypeId = 2, CatalogBrandId = 3, Description = "Shoes for next century", Name = "World Star", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new CatalogItem() { Id = 2, CatalogTypeId = 1, CatalogBrandId = 2, Description = "will make you world champions", Name = "White Line", Price = 88.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new CatalogItem() { Id = 3, CatalogTypeId = 2, CatalogBrandId = 3, Description = "You have already won gold medal", Name = "Prism White Shoes", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new CatalogItem() { Id = 4, CatalogTypeId = 2, CatalogBrandId = 2, Description = "Olympic runner", Name = "Foundation Hitech", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new CatalogItem() { Id = 5, CatalogTypeId = 2, CatalogBrandId = 1, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price = 188.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new CatalogItem() { Id = 6, CatalogTypeId = 2, CatalogBrandId = 2, Description = "Lala Land", Name = "Blue Star", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new CatalogItem() { Id = 7, CatalogTypeId = 2, CatalogBrandId = 1, Description = "High in the sky", Name = "Roslyn Green", Price = 212, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },
                new CatalogItem() { Id = 8, CatalogTypeId = 1, CatalogBrandId = 1, Description = "Light as carbon", Name = "Deep Purple", Price = 238.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new CatalogItem() { Id = 9, CatalogTypeId = 1, CatalogBrandId = 2, Description = "High Jumper", Name = "Addidas<White> Running", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new CatalogItem() { Id = 10, CatalogTypeId = 2, CatalogBrandId = 3, Description = "Dunker", Name = "Elequent", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new CatalogItem() { Id = 11, CatalogTypeId = 1, CatalogBrandId = 2, Description = "All round", Name = "Inredeible", Price = 248.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new CatalogItem() { Id = 12, CatalogTypeId = 2, CatalogBrandId = 1, Description = "Pricesless", Name = "London Sky", Price = 412, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new CatalogItem() { Id = 13, CatalogTypeId = 3, CatalogBrandId = 3, Description = "Tennis Star", Name = "Elequent", Price = 123, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new CatalogItem() { Id = 14, CatalogTypeId = 3, CatalogBrandId = 2, Description = "Wimbeldon", Name = "London Star", Price = 218.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new CatalogItem() { Id = 15, CatalogTypeId = 3, CatalogBrandId = 1, Description = "Rolan Garros", Name = "Paris Blues", Price = 312, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }
                );
        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(item => item.Id)
                .UseHiLo("catalog_hilo")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(item => item.Name)
                .IsRequired(true)
                .HasMaxLength(2000);

            builder.Property(item => item.Price).HasColumnType("decimal(10,2)")
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
                .ValueGeneratedOnAdd()
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
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            builder.Property(item => item.Type)
                .IsRequired(true)
                .HasMaxLength(2000);
        }


    }
}
