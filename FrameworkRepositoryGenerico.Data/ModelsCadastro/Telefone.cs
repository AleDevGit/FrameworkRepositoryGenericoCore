using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.Data.ModelsCadastro
{
    public partial class Telefone
    {
        public int Id { get; set; }
        public int? IdTipoTelefone { get; set; }
        public string Telefone1 { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual TipoTelefone IdTipoTelefoneNavigation { get; set; }
    }
}
