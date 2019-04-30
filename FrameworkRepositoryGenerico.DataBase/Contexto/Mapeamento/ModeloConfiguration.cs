using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
