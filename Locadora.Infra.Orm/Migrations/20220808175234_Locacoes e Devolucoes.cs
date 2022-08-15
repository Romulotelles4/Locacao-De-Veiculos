using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Orm.Migrations
{
    public partial class LocacoeseDevolucoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuilometragemInicial = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataInicialLocacao = table.Column<DateTime>(type: "date", nullable: false),
                    DataPrevistaDevolucao = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "0 == 'Aberta' \n 1 == 'Fechada' \n 2 == 'Cancelada'"),
                    TipoPlanoCobranca = table.Column<int>(type: "int", nullable: false, comment: "0 == 'Diaria' \n 1 == 'Livre' \n 2 == 'Controlada'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoVeiculo_GrupoVeiculoId",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "TBGrupoVeiculo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TbPlanoCobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TbPlanoCobranca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBLocacao_TbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TbVeiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbDevolucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuilometragemFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDevolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbDevolucao_TBLocacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBLocacaoTaxa",
                columns: table => new
                {
                    LocacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacaoTaxa", x => new { x.LocacoesId, x.TaxasId });
                    table.ForeignKey(
                        name: "FK_TBLocacaoTaxa_TBLocacao_LocacoesId",
                        column: x => x.LocacoesId,
                        principalTable: "TBLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacaoTaxa_TBTaxa_TaxasId",
                        column: x => x.TaxasId,
                        principalTable: "TBTaxa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbDevolucao_LocacaoId",
                table: "TbDevolucao",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CondutorId",
                table: "TBLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_FuncionarioId",
                table: "TBLocacao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_GrupoVeiculoId",
                table: "TBLocacao",
                column: "GrupoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_PlanoCobrancaId",
                table: "TBLocacao",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_VeiculoId",
                table: "TBLocacao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacaoTaxa_TaxasId",
                table: "TBLocacaoTaxa",
                column: "TaxasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbDevolucao");

            migrationBuilder.DropTable(
                name: "TBLocacaoTaxa");

            migrationBuilder.DropTable(
                name: "TBLocacao");
        }
    }
}
