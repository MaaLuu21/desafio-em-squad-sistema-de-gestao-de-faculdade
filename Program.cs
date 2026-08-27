namespace SistemaGestaoDeFaculdade;

using SistemaGestaoDeFaculdade.Entities;
using SistemaGestaoDeFaculdade.Enums;

class Program
{
    // "Banco de Dados" em memória 
    public static List<Curso> Cursos = new();
    public static List<Professor> Professores = new();
    public static List<Aluno> Alunos = new();
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
    private static void CadastrarCurso()
    {
        try
        {
            Console.Write("Código do curso: ");
            string codigo_curso = Console.ReadLine()!;

            // Regra de negócio: código do curso não pode se repetir
            bool codigoJaExiste = Cursos.Any(c =>
                c.Codigo.Equals(codigo_curso.Trim(), StringComparison.OrdinalIgnoreCase));

            if (codigoJaExiste)
            {
                Console.WriteLine($"Erro: já existe um curso cadastrado com o código '{codigo_curso}'.");
                Pausar();
                return;
            }

            Console.Write("Nome do curso: ");
            string nome_curso = Console.ReadLine()!;

            Console.WriteLine("Tipo do curso:");
            Console.WriteLine("1 - Graduação");
            Console.WriteLine("2 - Pós-graduação");
            Console.Write("Escolha: ");

            string? opcaoTipoCurso = Console.ReadLine();

            TipoCurso tipo_curso = opcaoTipoCurso switch
            {
                "1" => TipoCurso.Graduacao,
                "2" => TipoCurso.PosGraduacao,
                _ => throw new ArgumentException("Tipo de curso inválido. Escolha 1 ou 2.")
            };

            Curso curso = new Curso(codigo_curso, nome_curso, tipo_curso);
            Cursos.Add(curso);

            Console.WriteLine("\nCurso cadastrado com sucesso!");
            Console.WriteLine(curso);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar curso: {ex.Message}");
        }
        finally
        {
            Pausar();
        }
    }

    static void CadastrarProfessor() { 
        /* Dev 1 */ 
    }
    static void CadastrarAluno() { 
        /* Dev 2 */ 
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