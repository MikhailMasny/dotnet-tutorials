using Microsoft.EntityFrameworkCore.Migrations;

namespace Masny.DotNet.TransactionSystem.WebApi.Migrations
{
    public partial class AddTransactionIdentifierFieldToReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionIdentifier",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionIdentifier",
                table: "Reports");
        }
    }
}