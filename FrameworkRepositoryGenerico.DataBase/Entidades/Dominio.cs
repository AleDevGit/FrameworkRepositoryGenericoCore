using System.Collections.Generic;
using System.Linq;

namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public abstract class Dominio
    {
        private List<string> _mensagensValidacao { get; set; }

        private List<string> mensagemValidacao
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }

        protected void LimparMensagemValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public abstract void Validate();

        protected bool Ehvalido
        {
            get { return !mensagemValidacao.Any(); }
        }
                
    }
}
