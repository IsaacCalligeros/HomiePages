using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HomiePages.Infrastructure.Persistence.Migrations
{
    public partial class PortfolioContainerLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContainerId",
                table: "Portfolios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "ContainerId",
                table: "Containers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ContainerId",
                table: "Portfolios",
                column: "ContainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Containers_ContainerId",
                table: "Portfolios",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "ContainerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Containers_ContainerId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_ContainerId",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ContainerId",
                table: "Portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "ContainerId",
                table: "Containers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
