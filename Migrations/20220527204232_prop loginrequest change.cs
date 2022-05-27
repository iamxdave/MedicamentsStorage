using Microsoft.EntityFrameworkCore.Migrations;

namespace cw_8_ko_xDejw.Migrations
{
    public partial class proploginrequestchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginRequests",
                table: "LoginRequests");

            migrationBuilder.RenameTable(
                name: "LoginRequests",
                newName: "LoginRequest");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "LoginRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "LoginRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginRequest",
                table: "LoginRequest",
                column: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginRequest",
                table: "LoginRequest");

            migrationBuilder.RenameTable(
                name: "LoginRequest",
                newName: "LoginRequests");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "LoginRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "LoginRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginRequests",
                table: "LoginRequests",
                column: "Login");
        }
    }
}
