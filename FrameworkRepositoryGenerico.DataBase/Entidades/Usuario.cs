using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class Usuario : Dominio 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<UsuarioRegra> UsuarioRegras { get; set; }

        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual Cliente Cliente { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome não foi Informado");

            if (string.IsNullOrEmpty(Cpf))
                AdicionarCritica("Cpf não foi Informado");

            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("senha não foi Informado");
        }
    }
}
