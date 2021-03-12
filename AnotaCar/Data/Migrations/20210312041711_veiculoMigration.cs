using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AnotaCar.Data.Migrations
{
    public partial class veiculoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCombustivel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Modelo = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: true),
                    Placa = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CapacidadeTanque = table.Column<double>(type: "double precision", nullable: false),
                    TipoVeiculoID = table.Column<int>(type: "integer", nullable: false),
                    MarcaId = table.Column<int>(type: "integer", nullable: false),
                    TipoCombustivelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculo_TipoCombustivel_TipoCombustivelId",
                        column: x => x.TipoCombustivelId,
                        principalTable: "TipoCombustivel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Veiculo_TipoVeiculo_TipoVeiculoID",
                        column: x => x.TipoVeiculoID,
                        principalTable: "TipoVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_MarcaId",
                table: "Veiculo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_TipoCombustivelId",
                table: "Veiculo",
                column: "TipoCombustivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_TipoVeiculoID",
                table: "Veiculo",
                column: "TipoVeiculoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "TipoCombustivel");

            migrationBuilder.DropTable(
                name: "TipoVeiculo");
        }
    }
}
