using Microsoft.EntityFrameworkCore.Migrations;

namespace HomiePages.Infrastructure.Persistence.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Containers",
                newName: "ContainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContainerId",
                table: "Containers",
                newName: "Id");
        }
    }
}
