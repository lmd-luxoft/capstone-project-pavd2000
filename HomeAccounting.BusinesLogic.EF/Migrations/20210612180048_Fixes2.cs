using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAccounting.BusinesLogic.EF.Migrations
{
    public partial class Fixes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Deposites",
                newName: "PercentType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentType",
                table: "Deposites",
                newName: "Type");
        }
    }
}
