namespace SistemaGestaoDeFaculdade;

using SistemaGestaoDeFaculdade.Entities;
using SistemaGestaoDeFaculdade.Enums;

class Program
{
    // "Banco de Dados" em memória 
    public static List<Curso> cursos = new();
    public static List<Professor> professores = new();
    public static List<Aluno> alunos = new();
    public static List<Disciplina> disciplinas = new();
    //public static List<Matricula> matriculas = new();

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

    private static void CadastrarCurso()
    {
        try
        {
            Console.Write("Vamos iniciar o cadastro de um novo curso.\n");
            Console.Write("Código do curso: ");
            string codigo_curso = Console.ReadLine()!;

            // Regra de negócio: código do curso não pode se repetir
            bool codigoJaExiste = cursos.Any(c =>
                c.Codigo.Equals(codigo_curso.Trim(), StringComparison.OrdinalIgnoreCase));

            if (codigoJaExiste)
            {
                Console.WriteLine($"Erro: já existe um curso cadastrado com o código '{codigo_curso}'.");
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
            cursos.Add(curso);

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
    
    private static void CadastrarProfessor()
    {
        try
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()!;

            // Regra de negócio: CPF não pode se repetir
            bool cpfJaExiste = professores.Any(p =>
                p.Cpf.Equals(cpf.Trim(), StringComparison.OrdinalIgnoreCase));

            if (cpfJaExiste)
            {
                Console.WriteLine($"Erro: já existe um professor cadastrado com o CPF '{cpf}'.");
                return;
            }

            Console.Write("E-mail: ");
            string email = Console.ReadLine()!;

            Console.Write("Registro: ");
            string registro = Console.ReadLine()!;

            // Regra de negócio: registro não pode se repetir
            bool registroJaExiste = professores.Any(p =>
                p.Registro.Equals(registro.Trim(), StringComparison.OrdinalIgnoreCase));

            if (registroJaExiste)
            {
                Console.WriteLine($"Erro: já existe um professor cadastrado com o registro '{registro}'.");
                return;
            }

            Console.Write("Especialidade: ");
            string especialidade = Console.ReadLine()!;

            Professor professor = new Professor(nome, cpf, email, registro, especialidade);
            professores.Add(professor);

            Console.WriteLine("\nProfessor cadastrado com sucesso!");
            Console.WriteLine(professor);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar professor: {ex.Message}");
        }
        finally
        {
            Pausar();
        }
    }

    static void CadastrarAluno()
    {
        Console.Clear();
        Console.WriteLine("***Cadastro de Aluno***");
       
        Console.Write("Nome aluno:");
        string nomeDigitado = (Console.ReadLine() ?? "").Trim();
       
        Console.Write("CPF aluno:");
        string cpfDigitado = (Console.ReadLine() ?? "").Trim().Replace("-", "").Replace(".", "");
        bool cpfExiste = Aluno.CpfJaCadastrado(cpfDigitado, alunos);
        if (cpfExiste)
        {
            Console.WriteLine("\n[ERRO]O aluno não pode ser repetido! CPF já cadastrado.");
            return;
        }

         Console.WriteLine("Email aluno:");
        string emailDigitado = (Console.ReadLine() ?? "").Trim();

        int numeroMatricula = alunos.Any() ? alunos.Max(a => a.NumeroMatricula) + 1 : 1;

        alunos.Add(new Aluno(nomeDigitado, cpfDigitado, emailDigitado, numeroMatricula));

        Console.WriteLine($"\nAluno {nomeDigitado} cadastrado com sucesso! Número de matrícula: {numeroMatricula}");
        Pausar();
    }

    static void CadastrarDisciplina()
    {
        Console.WriteLine("*** Cadastrar disciplina ***");

        if (professores.Count == 0)
        {
            Console.WriteLine("Nenhum professor cadastrado. Cadastre um professor antes.");
            Pausar();
            return;
        }

        Console.Write("Codigo da disciplina: ");
        string codigo = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(codigo))
        {
            Console.WriteLine("Codigo da disciplina é um item obrigatorio.");
            Pausar();
            return;
        }

        bool codigoExiste = disciplinas.Exists(d =>
            d.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        if (codigoExiste)
        {
            Console.WriteLine("Já existe uma disciplina com esse código.");
            Pausar();
            return;
        }

        string nomeDisciplina;
        while (true)
        {
            Console.Write("Nome da disciplina: ");
            nomeDisciplina = (Console.ReadLine() ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(nomeDisciplina)) break;

            Console.WriteLine("Nome da disciplina é um item obrigatoóio.");
        }

        int cargaHoraria;
        while (true)
        {
            Console.Write("Carga horária (em horas): ");

            if (int.TryParse(Console.ReadLine() ?? "", out cargaHoraria) && cargaHoraria > 0) break; 

            Console.WriteLine("Carga horária inválida.");
        }

        int idxProfessor = SelecionarProfessor("Selecione o professor responsável:");

        if (idxProfessor < 0)
        {
            Console.WriteLine("Seleção inválida.");
            Pausar();
            return;
        }

        Professor responsavel = professores[idxProfessor];

        disciplinas.Add(new Disciplina(codigo, nomeDisciplina, cargaHoraria, responsavel));
        Console.WriteLine($"Disciplina '{nomeDisciplina}' cadastrada com sucesso.");
        Pausar();
    }
    static void VincularDisciplinaCurso()
    {
        /* Dev 3 */
    }
    static void MatricularAluno()
    {
        /* Dev 4 */
    }
    static void LancarNota()
    {
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

    static int LerIndiceSelecionado(int totalItens)
    {
        Console.Write("Numero: ");
        string entrada = Console.ReadLine() ?? "";

        if (!int.TryParse(entrada, out int escolha))
            return -1;
        if (escolha < 1 || escolha > totalItens)
            return -1;

        return escolha - 1;
    }


    static int SelecionarProfessor(string titulo)
    {
        Console.WriteLine(titulo);

        for (int i = 0; i < professores.Count; i++)
        {
            Professor p = professores[i];
            Console.WriteLine($"{i + 1} - {p.Nome} (Registro: {p.Registro} | {p.Especialidade})");
        }

        return LerIndiceSelecionado(professores.Count);
    }

    static int SelecionarCurso(string titulo)
    {
        Console.WriteLine(titulo);

        for (int i = 0; i < cursos.Count; i++)
        {
            Curso c = cursos[i];
            Console.WriteLine($"{i + 1} - {c.Codigo} - {c.Nome} ({c.Tipo})");
        }

        return LerIndiceSelecionado(cursos.Count);
    }

    static int SelecionarDisciplina(string titulo)
    {
        Console.WriteLine(titulo);

        for (int i = 0; i < disciplinas.Count; i++)
        {
            Disciplina d = disciplinas[i];
            Console.WriteLine($"{i + 1} - {d.Codigo} - {d.Nome} (Prof: {d.Professor.Nome})");
        }

        return LerIndiceSelecionado(disciplinas.Count);
    }
}