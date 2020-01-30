using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalogApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_brand_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 2000, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    CatalogTypeId = table.Column<int>(nullable: false),
                    CatalogBrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Addidas" },
                    { 2, "Puma" },
                    { 3, "Slazenger" }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Running" },
                    { 2, "Basketball" },
                    { 3, "Tennis" }
                });

            migrationBuilder.InsertData(
                table: "Catalog",
                columns: new[] { "Id", "CatalogBrandId", "CatalogTypeId", "Description", "Name", "PictureUrl", "Price" },
                values: new object[,]
                {
                    { 2, 2, 1, "will make you world champions", "White Line", "http://externalcatalogbaseurltobereplaced/api/pic/2", 88.50m },
                    { 8, 1, 1, "Light as carbon", "Deep Purple", "http://externalcatalogbaseurltobereplaced/api/pic/8", 238.5m },
                    { 9, 2, 1, "High Jumper", "Addidas<White> Running", "http://externalcatalogbaseurltobereplaced/api/pic/9", 129m },
                    { 11, 2, 1, "All round", "Inredeible", "http://externalcatalogbaseurltobereplaced/api/pic/11", 248.5m },
                    { 1, 3, 2, "Shoes for next century", "World Star", "http://externalcatalogbaseurltobereplaced/api/pic/1", 199.5m },
                    { 3, 3, 2, "You have already won gold medal", "Prism White Shoes", "http://externalcatalogbaseurltobereplaced/api/pic/3", 129m },
                    { 4, 2, 2, "Olympic runner", "Foundation Hitech", "http://externalcatalogbaseurltobereplaced/api/pic/4", 12m },
                    { 5, 1, 2, "Roslyn Red Sheet", "Roslyn White", "http://externalcatalogbaseurltobereplaced/api/pic/5", 188.5m },
                    { 6, 2, 2, "Lala Land", "Blue Star", "http://externalcatalogbaseurltobereplaced/api/pic/6", 112m },
                    { 7, 1, 2, "High in the sky", "Roslyn Green", "http://externalcatalogbaseurltobereplaced/api/pic/7", 212m },
                    { 10, 3, 2, "Dunker", "Elequent", "http://externalcatalogbaseurltobereplaced/api/pic/10", 12m },
                    { 12, 1, 2, "Pricesless", "London Sky", "http://externalcatalogbaseurltobereplaced/api/pic/12", 412m },
                    { 13, 3, 3, "Tennis Star", "Elequent", "http://externalcatalogbaseurltobereplaced/api/pic/13", 123m },
                    { 14, 2, 3, "Wimbeldon", "London Star", "http://externalcatalogbaseurltobereplaced/api/pic/14", 218.5m },
                    { 15, 1, 3, "Rolan Garros", "Paris Blues", "http://externalcatalogbaseurltobereplaced/api/pic/15", 312m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogBrandId",
                table: "Catalog",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");

            migrationBuilder.DropSequence(
                name: "catalog_brand_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_type_hilo");
        }
    }
}
