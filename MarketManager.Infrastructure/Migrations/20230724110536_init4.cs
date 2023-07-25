using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CashPurchaseSum",
                table: "Orders",
                newName: "ItemPurchaseSum");

            migrationBuilder.RenameColumn(
                name: "CardPriceSum",
                table: "Orders",
                newName: "ItemPriceSum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemPurchaseSum",
                table: "Orders",
                newName: "CashPurchaseSum");

            migrationBuilder.RenameColumn(
                name: "ItemPriceSum",
                table: "Orders",
                newName: "CardPriceSum");
        }
    }
}
