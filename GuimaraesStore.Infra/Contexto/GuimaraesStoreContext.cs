using GuimaraesStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuimaraesStore.Infra.Contexto
{
    public class GuimaraesStoreContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        public GuimaraesStoreContext(DbContextOptions<GuimaraesStoreContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
