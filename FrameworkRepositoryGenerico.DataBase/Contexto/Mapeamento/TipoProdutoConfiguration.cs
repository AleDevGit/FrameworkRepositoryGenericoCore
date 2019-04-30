using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class TipoProdutoConfiguration : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Ativo).IsRequired();

        }
    }
}
