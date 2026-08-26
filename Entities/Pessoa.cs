namespace SistemaGestaoDeFaculdade.Entities

{
    public abstract class Pessoa
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Notificacoes { get; private set; } = new List<string>();

        //protected para bloquear heranças fora do fluxo das classes filhas
        protected Pessoa(string nome, string cpf, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }
        public void ReceberNotificacoes(string mensagem)
        {
            Notificacoes.Add(mensagem);
        }
    }
}
