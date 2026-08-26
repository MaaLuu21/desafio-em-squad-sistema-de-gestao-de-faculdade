namespace SistemaGestaoDeFaculdade.Entities;

public class Aluno : Pessoa
{
    public int NumeroMatricula { get; set; }
    public Aluno(string nome, string cpf, string email, int numeroMatricula)
        : base(nome, cpf, email)
    {
        NumeroMatricula = numeroMatricula;
    }
    public class ServicoCadastroAluno
    {
        private readonly List<Aluno> _alunos;
        public ServicoCadastroAluno(List<Aluno> alunos)
        {
            _alunos = alunos;
        }

        public void CadastrarAluno()
        {
            Console.Clear();
            Console.WriteLine("***Cadastro de Aluno***");
            Console.WriteLine("CPF aluno:");
            string cpfDigitado = Console.ReadLine();
            bool cpfExiste = _alunos.Any(a => a.Cpf == cpfDigitado);
            if (cpfExiste)
            {
                Console.WriteLine("\n[ERRO]O aluno não pode ser repetido! CPF já cadastrado.");
                return;
            }
            Console.WriteLine("Nome aluno:");
            string nomeDigitado = Console.ReadLine();

            Console.WriteLine("Email aluno:");
            string emailDigitado = Console.ReadLine();

            int numeroMatricula = _alunos.Any() ? _alunos.Max(a => a.NumeroMatricula) + 1 : 1;
            _alunos.Add(new Aluno(nomeDigitado, cpfDigitado, emailDigitado, numeroMatricula));
        }

    }
}