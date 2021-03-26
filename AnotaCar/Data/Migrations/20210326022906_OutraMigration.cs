using Microsoft.EntityFrameworkCore.Migrations;

namespace AnotaCar.Data.Migrations
{
    public partial class OutraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abastecimento_PostoCombustivel_PostoId",
                table: "Abastecimento");

            migrationBuilder.AlterColumn<int>(
                name: "PostoId",
                table: "Abastecimento",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Abastecimento",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Abastecimento_PostoCombustivel_PostoId",
                table: "Abastecimento",
                column: "PostoId",
                principalTable: "PostoCombustivel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abastecimento_PostoCombustivel_PostoId",
                table: "Abastecimento");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Abastecimento");

            migrationBuilder.AlterColumn<int>(
                name: "PostoId",
                table: "Abastecimento",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Abastecimento_PostoCombustivel_PostoId",
                table: "Abastecimento",
                column: "PostoId",
                principalTable: "PostoCombustivel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
