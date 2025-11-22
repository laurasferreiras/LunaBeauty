using System.ComponentModel.DataAnnotations;

namespace LunaBeauty.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }

        // ALTERAÇÃO AQUI : Adicionando a lista de Pedidos
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

    }
}
