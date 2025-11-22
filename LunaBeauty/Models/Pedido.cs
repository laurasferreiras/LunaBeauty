using System.ComponentModel.DataAnnotations;

namespace LunaBeauty.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        [Display(Name = ("Cliente"))]
        public int ClienteId { get; set; }
        public Cliente? ClienteOrigem { get; set; }
        [Display(Name = ("Vendedor"))]
        public int VendedorId { get; set; }
        public Vendedor? VendedorOrigem { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;

        public List<ItemPedido> Itens { get; set; }


    }
}
