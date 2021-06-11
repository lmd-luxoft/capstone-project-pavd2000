using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAccounting.BusinesLogic.EF.Migrations
{
    public partial class ChangeBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Banks");
        }
    }
}
