using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder) {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Ativo).IsRequired();

            builder.HasMany(x => x.Contatos).WithOne(p => p.Usuario);
            builder.HasMany(x => x.UsuarioRegras).WithOne(p => p.Usuario);

        }
    }
}
