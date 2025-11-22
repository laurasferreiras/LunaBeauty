namespace LunaBeauty.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Descricao { get; set; }

        // ALTERAÇÃO AQUI : Adicionando a lista de Pedidos
        public List<ItemPedido> ItensPedidos { get; set; } = new List<ItemPedido>();
    }
}
