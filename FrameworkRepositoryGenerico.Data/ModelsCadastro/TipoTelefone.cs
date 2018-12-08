using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.Data.ModelsCadastro
{
    public partial class TipoTelefone
    {
        public TipoTelefone()
        {
            Telefone = new HashSet<Telefone>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Telefone> Telefone { get; set; }
    }
}
