using System.ComponentModel.DataAnnotations;

namespace LunaBeauty.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Display(Name =("E-mail"))]
        public string Email { get; set; }
        [Display(Name = ("Endereço"))]
        public string Endereco { get; set; }

        // ALTERAÇÃO AQUI : Adicionando a lista de Pedidos
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

    }
}
