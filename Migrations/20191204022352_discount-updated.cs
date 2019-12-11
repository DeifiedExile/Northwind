using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Migrations
{
    public partial class discountupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "DiscountID",
                table: "CartItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_DiscountID",
                table: "CartItems",
                column: "DiscountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Discounts_DiscountID",
                table: "CartItems",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "DiscountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Discounts_DiscountID",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_DiscountID",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "DiscountID",
                table: "CartItems");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "CartItems",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
