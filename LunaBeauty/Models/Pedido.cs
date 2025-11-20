using System.ComponentModel.DataAnnotations;

namespace LunaBeauty.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto? ProdutoOrigem { get; set; }
        public int ClienteId { get; set; }
        public Cliente? ClienteOrigem { get; set; }
        public int VendedorId { get; set; }
        public Vendedor? VendedorOrigem { get; set; }
        public string Data { get; set; }
        [Display(Name = ("Valor total"))]
        public decimal ValorTotal { get; set; }

    }
}
