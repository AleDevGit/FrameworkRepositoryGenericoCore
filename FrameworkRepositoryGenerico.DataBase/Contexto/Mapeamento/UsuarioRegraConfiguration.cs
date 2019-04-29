using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento
{
    public class UsuarioRegraConfiguration : IEntityTypeConfiguration<UsuarioRegra>
    {
        public void Configure(EntityTypeBuilder<UsuarioRegra> builder) {

            builder.HasKey(x => x.Id);
            

        }
    }
}
