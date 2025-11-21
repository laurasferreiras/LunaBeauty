using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LunaBeauty.Migrations
{
    /// <inheritdoc />
    public partial class ItemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
