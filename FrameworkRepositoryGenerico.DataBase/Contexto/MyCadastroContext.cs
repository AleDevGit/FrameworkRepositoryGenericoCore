using FrameworkRepositoryGenerico.DataBase.Contexto.Mapeamento;
using FrameworkRepositoryGenerico.DataBase.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FrameworkRepositoryGenerico.DataBase.Contexto
{
    public partial class MyCadastroContext : DbContext
    {
        public MyCadastroContext()
        {
        }

        public MyCadastroContext(DbContextOptions<MyCadastroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ano> Ano { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Fabricante> Fabricante { get; set; }
        public virtual DbSet<Montadora> Montadora { get; set; }
        public virtual DbSet<Regra> Regra { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }
        public virtual DbSet<TipoContato> TipoContato { get; set; }
        public virtual DbSet<TipoProduto> TipoProduto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRegra> UsuarioRegra { get; set; }

        
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new FabricanteConfiguration());
            modelBuilder.ApplyConfiguration(new MontadoraConfiguration());
            modelBuilder.ApplyConfiguration(new RegraConfiguration());
            modelBuilder.ApplyConfiguration(new TipoClienteConfiguration());
            modelBuilder.ApplyConfiguration(new TipoContatoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRegraConfiguration());



            base.OnModelCreating(modelBuilder);
        }
    }
}
