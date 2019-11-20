using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Migrations
{
    public partial class populatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var categorySqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "sql", "Northwind_Populate.sql");
            migrationBuilder.Sql(File.ReadAllText(categorySqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
