using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAccounting.BusinesLogic.EF.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Operations_OperationId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_OperationId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromAccountId",
                table: "Operations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToAccountId",
                table: "Operations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Banks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_FromAccountId",
                table: "Operations",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ToAccountId",
                table: "Operations",
                column: "ToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Accounts_FromAccountId",
                table: "Operations",
                column: "FromAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Accounts_ToAccountId",
                table: "Operations",
                column: "ToAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Accounts_FromAccountId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Accounts_ToAccountId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_FromAccountId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_ToAccountId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FromAccountId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "ToAccountId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Banks");

            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BasePrice",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OperationId",
                table: "Accounts",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Operations_OperationId",
                table: "Accounts",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
