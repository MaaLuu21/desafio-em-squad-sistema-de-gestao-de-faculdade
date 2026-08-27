namespace SistemaGestaoDeFaculdade;

class Program
{
     //"Banco de Dados" em memória
    public static List<Curso> Cursos = new();
    public static List<Professor> Professores = new();
    public static List<Aluno> alunos = new();
    public static List<Disciplina> Disciplinas = new();
    public static List<Matricula> Matriculas = new();

    static void Main(string[] args)
    {
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("========= GESTÃO DA FACULDADE =========");
            Console.WriteLine("1 - Cadastrar curso");
            Console.WriteLine("2 - Cadastrar professor");
            Console.WriteLine("3 - Cadastrar aluno");
            Console.WriteLine("4 - Cadastrar disciplina");
            Console.WriteLine("5 - Vincular disciplina a um curso");
            Console.WriteLine("6 - Matricular aluno em curso");
            Console.WriteLine("7 - Lançar nota");
            Console.WriteLine("8 - Consultar pessoas");
            Console.WriteLine("9 - Consultar cursos");
            Console.WriteLine("10 - Consultar matrículas");
            Console.WriteLine("11 - Consultar boletim");
            Console.WriteLine("12 - Enviar notificação");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": 
                    CadastrarCurso(); 
                    break;
                case "2": 
                    CadastrarProfessor(); 
                    break;
                case "3": 
                    CadastrarAluno(); 
                    break;
                case "4": 
                    CadastrarDisciplina(); 
                    break;
                case "5": 
                    VincularDisciplinaCurso(); 
                    break;
                case "6": 
                    MatricularAluno(); 
                    break;
                case "7": 
                    LancarNota(); 
                    break;
                case "8": 
                    ConsultarPessoas(); 
                    break;
                case "9": 
                    ConsultarCursos(); 
                    break;
                case "10": 
                    ConsultarMatriculas(); 
                    break;
                case "11": 
                    ConsultarBoletim(); 
                    break;
                case "12": 
                    EnviarNotificacao(); 
                    break;
                case "0": executando = false; break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Pausar();
                    break;
            }
        }
    }

    // Métodos vazios para cada integrante preencher no seu branch:
    static void CadastrarCurso() { 
        /* Dev 1 */ 
    }
    static void CadastrarProfessor()
    {
        /* Dev 1 */
    }
    static void CadastrarAluno()
    {
        Console.Clear();
        Console.WriteLine("***Cadastro de Aluno***");
        Console.WriteLine("CPF aluno:");
        string cpfDigitado = (Console.ReadLine() ?? "").Trim().Replace("-", "").Replace(".", "");
        bool cpfExiste = Aluno.CpfJaCadastrado(cpfDigitado, alunos);
        if (cpfExiste)
        {
            Console.WriteLine("\n[ERRO]O aluno não pode ser repetido! CPF já cadastrado.");
            return;
        }
        Console.WriteLine("Nome aluno:");
        string nomeDigitado = (Console.ReadLine() ?? "").Trim();

        Console.WriteLine("Email aluno:");
        string emailDigitado = (Console.ReadLine() ?? "").Trim();

        int numeroMatricula = alunos.Any() ? alunos.Max(a => a.NumeroMatricula) + 1 : 1;

        alunos.Add(new Aluno(nomeDigitado, cpfDigitado, emailDigitado, numeroMatricula));

        Console.WriteLine($"\nAluno {nomeDigitado} cadastrado com sucesso! Número de matrícula: {numeroMatricula}");
        Pausar();
    }
    static void CadastrarDisciplina() { 
        /* Dev 3 */ 
    }
    static void VincularDisciplinaCurso() { 
        /* Dev 3 */ 
    }
    static void MatricularAluno() { 
        /* Dev 4 */ 
    } 
    static void LancarNota() { 
        /* Dev 4 */ 
    }
    static void ConsultarPessoas() { 
        /* Dev 2 */ 
    }
    static void ConsultarCursos() { 
        /* Dev 1 */ 
    }
    static void ConsultarMatriculas() { 
        /* Dev 5 */ 
    }
    static void ConsultarBoletim() { 
        /* Dev 5 */ 
    }
    static void EnviarNotificacao() { 
        /* Dev 2 */ 
    }

    public static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}