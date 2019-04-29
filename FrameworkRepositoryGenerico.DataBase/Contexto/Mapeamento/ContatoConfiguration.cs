using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Ativo).IsRequired();

            builder.HasOne(x => x.TipoContato);
            builder.HasOne(x => x.Usuario);
        }
    }
}
