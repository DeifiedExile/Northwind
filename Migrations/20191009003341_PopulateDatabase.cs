using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace Northwind.Migrations
{
    public partial class PopulateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var categorySqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "sql", "Northwind_Populate_Categories.sql");
            migrationBuilder.Sql(File.ReadAllText(categorySqlFile));
            var productSqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "sql", "Northwind_Populate_Products.sql");
            migrationBuilder.Sql(File.ReadAllText(productSqlFile));
            var updateProductSqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "sql", "Fix_Products.sql");
            migrationBuilder.Sql(File.ReadAllText(updateProductSqlFile));
            var discountSqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "sql", "Populate_Discounts.sql");
            migrationBuilder.Sql(File.ReadAllText(discountSqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
