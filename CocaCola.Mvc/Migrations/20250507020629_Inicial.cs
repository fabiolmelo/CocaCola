using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CocaCola.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    AceitaMensagem = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataAceite = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RecusaMensagem = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataRecusa = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Token = table.Column<Guid>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Telefone);
                });

            migrationBuilder.CreateTable(
                name: "ImportacoesEfetuadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeArquivoServer = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    NomeArquivo = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    DataImportacao = table.Column<DateTime>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportacoesEfetuadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RedesContato",
                columns: table => new
                {
                    RedeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContatoTelefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedesContato", x => new { x.ContatoTelefone, x.RedeId });
                    table.ForeignKey(
                        name: "FK_RedesContato_Contatos_ContatoTelefone",
                        column: x => x.ContatoTelefone,
                        principalTable: "Contatos",
                        principalColumn: "Telefone",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RedesContato_Redes_RedeId",
                        column: x => x.RedeId,
                        principalTable: "Redes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Uf = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    RedeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurantes_Redes_RedeId",
                        column: x => x.RedeId,
                        principalTable: "Redes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExtratosVendas",
                columns: table => new
                {
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    RestauranteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Competencia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPedidos = table.Column<int>(type: "INTEGER", nullable: false),
                    PedidosComCocaCola = table.Column<int>(type: "INTEGER", nullable: false),
                    IncidenciaReal = table.Column<decimal>(type: "TEXT", precision: 2, nullable: false),
                    Meta = table.Column<decimal>(type: "TEXT", precision: 2, nullable: false),
                    PrecoUnitarioMedio = table.Column<decimal>(type: "TEXT", precision: 2, nullable: false),
                    TotalPedidosNaoCapturados = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceitaNaoCapturada = table.Column<decimal>(type: "TEXT", precision: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtratosVendas", x => new { x.Ano, x.Mes, x.RestauranteId });
                    table.ForeignKey(
                        name: "FK_ExtratosVendas_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtratosVendas_RestauranteId",
                table: "ExtratosVendas",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_RedesContato_RedeId",
                table: "RedesContato",
                column: "RedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_RedeId",
                table: "Restaurantes",
                column: "RedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtratosVendas");

            migrationBuilder.DropTable(
                name: "ImportacoesEfetuadas");

            migrationBuilder.DropTable(
                name: "RedesContato");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Redes");
        }
    }
}
