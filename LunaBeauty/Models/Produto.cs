using System.ComponentModel.DataAnnotations;

namespace LunaBeauty.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        [Display(Name = ("Preço"))]
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        [Display(Name = ("Descrição"))]
        public string Descricao { get; set; }

        // ALTERAÇÃO AQUI : Adicionando a lista de Pedidos
        public List<ItemPedido> ItensPedidos { get; set; } = new List<ItemPedido>();
    }
}
