using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.ModelsCadastro
{
    public partial class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        
        public virtual Cliente Cliente { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
