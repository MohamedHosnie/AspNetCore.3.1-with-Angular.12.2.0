using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicsShop.EntityFrameworkCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PriceOfTwo = table.Column<float>(type: "real", nullable: true),
                    CategoryId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    Fulfilled = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (short)1, "TVs" },
                    { (short)2, "Laptops" },
                    { (short)3, "Sound Systems" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "Email", "FullAddress", "FullName", "PasswordHash", "PhoneNumber", "Role", "Username" },
                values: new object[] { 1, new DateTime(2022, 7, 30, 20, 11, 34, 984, DateTimeKind.Local).AddTicks(837), "sample@email.com", "Cairo, Egypt", "Electronics Shop Admin", "$2a$11$UBds5HSkR4cEPlGDo8lUyOCNOBmen37At0FJA8/kIgNdjUdMBxHUu", "011111", 1, "admin" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "PriceOfTwo" },
                values: new object[,]
                {
                    { 1, (short)1, "This is a test dummy data description", "Test Product 1", 600f, 1100f },
                    { 16, (short)3, "This is a test dummy data description", "Test Product 16", 778f, null },
                    { 15, (short)3, "This is a test dummy data description", "Test Product 15", 456f, 700f },
                    { 11, (short)3, "This is a test dummy data description", "Test Product 11", 770f, null },
                    { 9, (short)3, "This is a test dummy data description", "Test Product 9", 500f, 800f },
                    { 6, (short)3, "This is a test dummy data description", "Test Product 6", 1100f, 2000f },
                    { 3, (short)3, "This is a test dummy data description", "Test Product 3", 2200f, 4000f },
                    { 23, (short)2, "This is a test dummy data description", "Test Product 23", 128f, 256f },
                    { 20, (short)2, "This is a test dummy data description", "Test Product 20", 254f, null },
                    { 14, (short)2, "This is a test dummy data description", "Test Product 14", 940f, 1750f },
                    { 13, (short)2, "This is a test dummy data description", "Test Product 13", 750f, null },
                    { 10, (short)2, "This is a test dummy data description", "Test Product 10", 660f, 1000f },
                    { 8, (short)2, "This is a test dummy data description", "Test Product 8", 7200f, null },
                    { 5, (short)2, "This is a test dummy data description", "Test Product 5", 3800f, 6800f },
                    { 2, (short)2, "This is a test dummy data description", "Test Product 2", 1500f, null },
                    { 22, (short)1, "This is a test dummy data description", "Test Product 22", 512f, null },
                    { 19, (short)1, "This is a test dummy data description", "Test Product 19", 888f, 1500f },
                    { 18, (short)1, "This is a test dummy data description", "Test Product 18", 999f, 1700f },
                    { 17, (short)1, "This is a test dummy data description", "Test Product 17", 666f, 1111f },
                    { 12, (short)1, "This is a test dummy data description", "Test Product 12", 850f, 1600f },
                    { 7, (short)1, "This is a test dummy data description", "Test Product 7", 1700f, 3000f },
                    { 4, (short)1, "This is a test dummy data description", "Test Product 4", 2400f, 4500f },
                    { 21, (short)3, "This is a test dummy data description", "Test Product 21", 256f, 512f },
                    { 24, (short)3, "This is a test dummy data description", "Test Product 24", 1024f, 2048f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
