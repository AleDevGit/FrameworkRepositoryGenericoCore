using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.ModelsCadastro
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
