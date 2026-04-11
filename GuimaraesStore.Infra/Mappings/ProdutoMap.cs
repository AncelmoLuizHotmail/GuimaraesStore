using GuimaraesStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuimaraesStore.Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id)
                .HasName("IdProduto");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TipoProduto)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasMaxLength(500);

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.QuantidadeEstoque)
                .IsRequired();
        }
    }
}
