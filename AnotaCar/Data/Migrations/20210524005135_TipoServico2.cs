using Microsoft.EntityFrameworkCore.Migrations;

namespace AnotaCar.Data.Migrations
{
    public partial class TipoServico2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "TipoServicoId",
                table: "Servico",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.AlterColumn<int>(
                name: "TipoServicoId",
                table: "Servico",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
