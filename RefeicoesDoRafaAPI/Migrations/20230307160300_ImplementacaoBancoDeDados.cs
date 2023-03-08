using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefeicoesDoRafaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImplementacaoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "refeicao",
                columns: table => new
                {
                    idRefeicao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preco = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    nomeRefeicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoProteina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoAcompanhamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refeicao", x => x.idRefeicao);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    nomeCompletoCliente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    whatsapp = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    enderecoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cpf);
                    table.ForeignKey(
                        name: "FK_cliente_endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    idPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientecpf = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    refeicaoidRefeicao = table.Column<int>(type: "int", nullable: false),
                    horaSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPedidoEntregue = table.Column<bool>(type: "bit", nullable: false),
                    observacoesDoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_clientecpf",
                        column: x => x.clientecpf,
                        principalTable: "cliente",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_refeicao_refeicaoidRefeicao",
                        column: x => x.refeicaoidRefeicao,
                        principalTable: "refeicao",
                        principalColumn: "idRefeicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_enderecoid",
                table: "cliente",
                column: "enderecoid");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_clientecpf",
                table: "pedido",
                column: "clientecpf");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_refeicaoidRefeicao",
                table: "pedido",
                column: "refeicaoidRefeicao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "refeicao");

            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}
