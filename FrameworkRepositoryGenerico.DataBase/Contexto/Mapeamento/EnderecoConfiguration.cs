using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Municipio).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Uf).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100);
            
            builder.Property(x => x.Ativo).IsRequired();



        }
    }
}
