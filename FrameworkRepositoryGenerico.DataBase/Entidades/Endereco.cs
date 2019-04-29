using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public partial class Endereco : Dominio
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string Ativo { get; set; }

        public virtual Cliente Cliente { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Logradouro))
                AdicionarCritica("Logradouro não foi Informado");

            if (string.IsNullOrEmpty(Cep))
                AdicionarCritica("Cep não foi Informado");

            if (string.IsNullOrEmpty(Uf))
                AdicionarCritica("Uf não foi Informado");

            if (string.IsNullOrEmpty(Municipio))
                AdicionarCritica("Municipio não foi Informado");

            if (string.IsNullOrEmpty(Bairro))
                AdicionarCritica("Bairro não foi Informado");
        }
    }
}
