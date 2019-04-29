using System.Collections.Generic;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class UsuarioRegra : Dominio
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Regra Regra { get; set; }


        public override void Validate()
        {
            
        }
    }
}
