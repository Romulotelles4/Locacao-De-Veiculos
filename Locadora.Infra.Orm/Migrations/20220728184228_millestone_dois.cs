using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Locadora.Infra.Orm.Migrations
{
    public partial class millestone_dois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cnh = table.Column<string>(type: "varchar(50)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false),
                    TipoCadastro = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Login = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoDeCalculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Cnh = table.Column<string>(type: "varchar(11)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(60)", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(18)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiarioDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiarioPorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LivreDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ControladoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ControladoPorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ControladoLimiteKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPlanoCobranca_TBGrupoVeiculo_GrupoVeiculoId",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "TBGrupoVeiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    CapacidadeTanque = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    KmPercorrido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoDeCombustivel = table.Column<int>(type: "int", nullable: false),
                    GrupoDeVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbVeiculo_TBGrupoVeiculo_GrupoDeVeiculoId",
                        column: x => x.GrupoDeVeiculoId,
                        principalTable: "TBGrupoVeiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPlanoCobranca_GrupoVeiculoId",
                table: "TbPlanoCobranca",
                column: "GrupoVeiculoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbVeiculo_GrupoDeVeiculoId",
                table: "TbVeiculo",
                column: "GrupoDeVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TbPlanoCobranca");

            migrationBuilder.DropTable(
                name: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TbVeiculo");

            migrationBuilder.DropTable(
                name: "TbCliente");

            migrationBuilder.DropTable(
                name: "TBGrupoVeiculo");
        }
    }
}
