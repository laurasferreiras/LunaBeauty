using LunaBeauty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LunaBeauty.Data
{
    public class LunaContext : DbContext
    {
        public LunaContext(DbContextOptions options) : base(options)
        {
        
        }
        public DbSet<Produto> Produtos {  get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
