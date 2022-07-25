using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSistemaWeb.Migrations
{
    public partial class Initial : Migration
    {
        private int Pending = 0;
        private int Billed = 1;
        private int Canceled = 2;
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BaseSalary = table.Column<double>(type: "double", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seller_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalesRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRecord_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecord_SellerId",
                table: "SalesRecord",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartmentId",
                table: "Seller",
                column: "DepartmentId");

            /************** Db-fixtures mocados ******************/
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computadores" },
                    { 2, "Eletrônicos" },
                    { 3, "Moda" },
                    { 4, "Livros" }
                }
            );

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "Name", "Email", "BirthDate", "BaseSalary", "DepartmentId" },
                values: new object[,]
                {
                    { 1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, 1 },
                    { 2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3100.0, 2 },
                    { 3, "Alex Grey", "alex@gmail.com", new DateTime(1998, 1, 15), 2200.0, 1 },
                    { 4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, 4 },
                    { 5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 5300.0, 3 },
                    { 6, "Davidson Almeida", "davidson@gmail.com", new DateTime(1992, 5, 29), 3000.0, 2 }
                }
            );

            migrationBuilder.InsertData(
                table: "SalesRecord",
                columns: new[] { "Id", "Date", "Amount", "Status", "SellerId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 09, 25), 11000.0, Billed, 1 },
                    { 2, new DateTime(2018, 09, 4), 7000.0, Billed, 5 },
                    { 3, new DateTime(2018, 09, 13), 4000.0, Canceled, 4 },
                    { 4, new DateTime(2018, 09, 1), 8000.0, Billed, 1 },
                    { 5, new DateTime(2018, 09, 21), 3000.0, Billed, 3 },
                    { 6, new DateTime(2018, 09, 15), 2000.0, Billed, 1 },
                    { 7, new DateTime(2018, 09, 28), 13000.0, Billed, 2 },
                    { 8, new DateTime(2018, 09, 11), 4000.0, Billed, 4 },
                    { 9, new DateTime(2018, 09, 14), 11000.0, Pending, 6 },
                    { 10, new DateTime(2018, 09, 7), 9000.0, Billed, 6 },
                    { 11, new DateTime(2018, 09, 13), 6000.0, Billed, 2 },
                    { 12, new DateTime(2019, 09, 25), 7000.0, Pending, 3 },
                    { 13, new DateTime(2019, 09, 29), 10000.0, Billed, 4 },
                    { 14, new DateTime(2019, 09, 4), 3000.0, Billed, 5 },
                    { 15, new DateTime(2019, 09, 12), 4000.0, Billed, 1 },
                    { 16, new DateTime(2019, 10, 5), 2000.0, Billed, 4 },
                    { 17, new DateTime(2019, 10, 1), 12000.0, Billed, 1 },
                    { 18, new DateTime(2019, 10, 24), 6000.0, Billed, 3 },
                    { 19, new DateTime(2019, 10, 22), 8000.0, Billed, 5 },
                    { 20, new DateTime(2019, 10, 15), 8000.0, Billed, 6 },
                    { 21, new DateTime(2019, 10, 17), 9000.0, Billed, 2 },
                    { 22, new DateTime(2021, 10, 24), 4000.0, Billed, 4 },
                    { 23, new DateTime(2021, 10, 19), 11000.0, Canceled, 2 },
                    { 24, new DateTime(2021, 10, 12), 8000.0, Billed, 5 },
                    { 25, new DateTime(2021, 10, 31), 7000.0, Billed, 3 },
                    { 26, new DateTime(2021, 10, 6), 5000.0, Billed, 4 },
                    { 27, new DateTime(2022, 01, 13), 9000.0, Pending, 1},
                    { 28, new DateTime(2022, 03, 7), 4000.0, Billed, 3 },
                    { 29, new DateTime(2022, 05, 23), 12000.0, Billed, 5 },
                    { 30, new DateTime(2022, 06, 12), 5000.0, Billed, 2 }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "1",
                keyValue: null
            );*/

            migrationBuilder.DropTable(
                name: "SalesRecord");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
