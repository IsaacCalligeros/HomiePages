using Microsoft.EntityFrameworkCore.Migrations;

namespace HomiePages.Infrastructure.Persistence.Migrations
{
    public partial class AuthCodesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "code",
                table: "AuthCodes",
                newName: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "AuthCodes",
                newName: "code");
        }
    }
}
