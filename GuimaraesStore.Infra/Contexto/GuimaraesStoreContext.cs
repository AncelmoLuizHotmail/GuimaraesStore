using GuimaraesStore.Domain.Entities;
using GuimaraesStore.Infra.Mappings;
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
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
