using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HomiePages.Infrastructure.Persistence.Migrations
{
    public partial class Ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equities_Portfolios_PortfolioId",
                table: "Equities");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDos_ToDoId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_Equities_PortfolioId",
                table: "Equities");

            migrationBuilder.RenameColumn(
                name: "ContainerId",
                table: "Containers",
                newName: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "ToDoId",
                table: "ToDoItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Portfolios",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Equities",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "PortfolioId1",
                table: "Equities",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equities_PortfolioId1",
                table: "Equities",
                column: "PortfolioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Equities_Portfolios_PortfolioId1",
                table: "Equities",
                column: "PortfolioId1",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDos_ToDoId",
                table: "ToDoItems",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equities_Portfolios_PortfolioId1",
                table: "Equities");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDos_ToDoId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_Equities_PortfolioId1",
                table: "Equities");

            migrationBuilder.DropColumn(
                name: "PortfolioId1",
                table: "Equities");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Containers",
                newName: "ContainerId");

            migrationBuilder.AlterColumn<long>(
                name: "ToDoId",
                table: "ToDoItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Portfolios",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Equities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Equities_PortfolioId",
                table: "Equities",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equities_Portfolios_PortfolioId",
                table: "Equities",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDos_ToDoId",
                table: "ToDoItems",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
