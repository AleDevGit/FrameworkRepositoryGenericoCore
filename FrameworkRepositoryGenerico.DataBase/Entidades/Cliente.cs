using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class Cliente : Dominio
    {

        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("CPF CNPJ")]
        public string Cpf_Cnpj { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        [DisplayName("Tipo de Cliente")]
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
