using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class Cliente : Dominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf_Cnpj { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoCliente TipoCliente { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Nome não foi Informado");
        }
    }
}
