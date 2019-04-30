using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class Contato : Dominio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual TipoContato TipoContato { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição não foi Informado");
        }
    }
}
