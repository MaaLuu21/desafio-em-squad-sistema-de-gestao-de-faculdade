namespace SistemaGestaoDeFaculdade.Entities
{
    public abstract class Pessoa
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; private set; } = string.Empty;
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

        // Normaliza a entrada de CPF retirando qualquer coisa que não é numérica
        public static string NormalizarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return string.Empty;
            return cpf.Trim().Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");
        }

        // Valida o formato de um e-mail.
        public static bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            email = email.Trim();

            int arroba = email.IndexOf('@');
            if (arroba <= 0) return false; // precisa ter "@" e algo antes dele

            if (email.Contains(' ')) return false; // e-mail não pode ter espacos

            return true;
        }
    }
}
