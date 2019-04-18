using System;
using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.ModelsCadastro
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        
        public virtual Cliente Cliente { get; set; }
    }
}
