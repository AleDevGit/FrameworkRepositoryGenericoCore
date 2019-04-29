using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Cpf_Cnpj).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Ativo).IsRequired();

            builder.HasMany(x => x.Usuarios).WithOne(p => p.Cliente);
            builder.HasMany(x => x.Enderecos).WithOne(p => p.Cliente);

            builder.HasOne(x => x.TipoCliente);
        }
    }
}
