﻿namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class TipoCliente : Dominio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição não foi Informado");


        }
    }
}
