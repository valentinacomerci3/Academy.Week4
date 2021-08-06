using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommerceEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerCode", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "4738539", "Rossi", "Mario" },
                    { 2, "4758954", "Verdi", "Luca" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Cost", "CustomerId", "OrderCode", "OrderDate", "ProductCode" },
                values: new object[,]
                {
                    { 1, 7m, null, "82299", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "400239" },
                    { 2, 5m, null, "8913j9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "40008539" },
                    { 3, 3m, null, "890009", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4118679" },
                    { 4, 9m, null, "89ft434", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "474yuh539" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
