using GuimaraesStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuimaraesStore.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id)
                .HasName("IdCliente");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.Telefone)
                .HasMaxLength(15); //(351)99999-9999

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
