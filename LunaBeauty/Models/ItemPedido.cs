namespace LunaBeauty.Models
{
    public class ItemPedido
    {
        public int PedidoId { get; set; }
        public Pedido? PedidoOrigem { get; set; }
        public int ProdutoId { get; set; }
        public Produto? ProdutoOrigem { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
