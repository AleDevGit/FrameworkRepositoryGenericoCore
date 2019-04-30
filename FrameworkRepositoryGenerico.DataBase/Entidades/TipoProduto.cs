namespace FrameworkRepositoryGenerico.DataBase.Entidades
{
    public class TipoProduto : Dominio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Descrição não foi Informado");
        }
    }
}
