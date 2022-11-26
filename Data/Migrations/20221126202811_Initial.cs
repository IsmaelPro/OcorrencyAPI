using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPedido = table.Column<int>(nullable: false),
                    HoraPedido = table.Column<DateTime>(nullable: false),
                    IndCancelado = table.Column<bool>(nullable: false),
                    IndConcluido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrência",
                columns: table => new
                {
                    IdOcorrência = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndFinalizadora = table.Column<int>(nullable: false),
                    TipoOcorrencia = table.Column<string>(nullable: true),
                    HoraOcorrencia = table.Column<DateTime>(nullable: false),
                    PedidoIdPedido = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocorrência");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
