using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FixOcorrenciaentityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocorrência");

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    IdOcorrencia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndFinalizadora = table.Column<int>(nullable: false),
                    TipoOcorrencia = table.Column<string>(nullable: true),
                    HoraOcorrencia = table.Column<DateTime>(nullable: false),
                    PedidoIdPedido = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.IdOcorrencia);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Pedido_PedidoIdPedido",
                        column: x => x.PedidoIdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_PedidoIdPedido",
                table: "Ocorrencia",
                column: "PedidoIdPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.CreateTable(
                name: "Ocorrência",
                columns: table => new
                {
                    IdOcorrência = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndFinalizadora = table.Column<int>(type: "int", nullable: false),
                    PedidoIdPedido = table.Column<int>(type: "int", nullable: true),
                    TipoOcorrencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrência", x => x.IdOcorrência);
                    table.ForeignKey(
                        name: "FK_Ocorrência_Pedido_PedidoIdPedido",
                        column: x => x.PedidoIdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrência_PedidoIdPedido",
                table: "Ocorrência",
                column: "PedidoIdPedido");
        }
    }
}
