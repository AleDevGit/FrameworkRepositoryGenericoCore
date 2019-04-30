using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class Ano : Dominio
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Ativo { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição não foi Informado");
        }
    }
}
