using SistemaGestaoDeFaculdade.Entities;
using SistemaGestaoDeFaculdade.Enums;

namespace SistemaGestaoDeFaculdade;

class Program
{
    //"Banco de Dados" em memória
    public static List<Curso> cursos = new();
    public static List<Professor> professores = new();
    public static List<Aluno> alunos = new();
    public static List<Disciplina> disciplinas = new();
    public static List<Matricula> matriculas = new();

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
                    ReceberNotificacoes();
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
            Console.Clear();
            Console.WriteLine("*** Cadastro de novo curso ***\n");
            Console.Write("Vamos iniciar o cadastro de um novo curso.\n");

            Console.Write("Nome do curso: ");
            string nome_curso = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nome_curso))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O nome não pode ser vazio.");
                Console.ResetColor();
                return;
            }

            Console.Write("Código do curso: ");
            string codigo_curso = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(codigo_curso))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O código do curso não pode ser vazio.");
                Console.ResetColor();
                return;
            }

            // Regra de negócio: código do curso não pode se repetir
            bool codigoJaExiste = cursos.Any(c =>
                c.Codigo.Equals(codigo_curso, StringComparison.OrdinalIgnoreCase));

            if (codigoJaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: Já existe um curso cadastrado com o código '{codigo_curso}'.");
                Console.ResetColor();
                return;
            }

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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCurso cadastrado com sucesso!");
            Console.ResetColor();

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
            Console.Clear();
            Console.WriteLine("*** Cadastro de Professor ***\n");
            Console.Write("Vamos iniciar o cadastro de um professor.\n");

            Console.Write("Nome do Professor: ");
            string nome = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O nome não pode ser vazio.");
                Console.ResetColor();
                return;
            }

            Console.Write("CPF: ");
            string cpf = Pessoa.NormalizarCpf(Console.ReadLine() ?? ""); // Normaliza o CPF na entrada

            if (cpf.Length != 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O CPF deve possuir exatamente 11 números.");
                Console.ResetColor();
                return;
            }

            // Regra de negócio: CPF não pode se repetir
            bool cpfJaExiste = professores.Any(p =>
                p.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));

            if (cpfJaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: Já existe um professor cadastrado com o CPF '{cpf}'.");
                Console.ResetColor();
                return;
            }

            string email = LerEmailValido("E-mail: ");

            Console.Write("Registro: ");
            string registro = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(registro))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O registro não pode ser vazio.");
                Console.ResetColor();
                return;
            }

            // Regra de negócio: registro não pode se repetir
            bool registroJaExiste = professores.Any(p =>
                p.Registro.Equals(registro, StringComparison.OrdinalIgnoreCase));

            if (registroJaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: Já existe um professor cadastrado com o registro '{registro}'.");
                Console.ResetColor();
                return;
            }

            Console.Write("Especialidade: ");
            string especialidade = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(especialidade))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: A especialidade não pode ser vazia.");
                Console.ResetColor();
                return;
            }

            Professor professor = new Professor(nome, cpf, email, registro, especialidade);
            professores.Add(professor);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProfessor cadastrado com sucesso!");
            Console.ResetColor();

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
        try
        {
            Console.Clear();
            Console.WriteLine("*** Cadastrar Aluno ***\n");

            Console.Write("Nome aluno: ");
            string nomeDigitado = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nomeDigitado))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O nome do aluno não pode ser vazio.");
                Console.ResetColor();
                return;
            }

            Console.Write("CPF aluno: ");
            string cpfDigitado = Pessoa.NormalizarCpf(Console.ReadLine() ?? ""); // Normaliza o CPF na entrada

            if (cpfDigitado.Length != 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O CPF deve possuir exatamente 11 números");
                Console.ResetColor();
                return;
            }

            bool cpfExiste = Aluno.CpfJaCadastrado(cpfDigitado, alunos);
            if (cpfExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: O aluno não pode ser repetido! CPF já cadastrado.");
                Console.ResetColor();
                return;
            }

            string emailDigitado = LerEmailValido("E-mail: ");

            int numeroMatricula = alunos.Any() ? alunos.Max(a => a.NumeroMatricula) + 1 : 1;

            alunos.Add(new Aluno(nomeDigitado, cpfDigitado, emailDigitado, numeroMatricula));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAluno {nomeDigitado} cadastrado com sucesso! Número de matrícula: {numeroMatricula}");
            Console.ResetColor();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar aluno: {ex.Message}");
        }
        finally
        {
            Pausar();
        }
    }

    static void CadastrarDisciplina()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("*** Cadastrar nova disciplina ***\n");

            if (professores.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum professor cadastrado. Cadastre um novo professor usando o item 2 do Menu principal.");
                Console.ResetColor();
                return;
            }

            string nomeDisciplina;
            while (true)
            {
                Console.Write("Nome da disciplina: ");

                nomeDisciplina = (Console.ReadLine() ?? "").Trim();

                if (!string.IsNullOrWhiteSpace(nomeDisciplina)) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nome da disciplina é um item obrigatório.");
                Console.ResetColor();
            }

            string codigo;
            while (true)
            {
                Console.Write("Codigo da disciplina: ");
                codigo = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Codigo da disciplina é uma informação obrigatória.");
                    Console.ResetColor();
                    continue;
                }

                bool codigoExiste = disciplinas.Exists(d => d.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
                if (codigoExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Já existe uma disciplina com esse código.");
                    Console.ResetColor();
                    return;
                }
                break;
            }

            int cargaHoraria;
            while (true)
            {
                Console.Write("Carga horária (em horas): ");

                if (int.TryParse(Console.ReadLine() ?? "", out cargaHoraria) && cargaHoraria > 0) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Carga horária inválida.");
                Console.ResetColor();
            }

            int idxProfessor = SelecionarProfessor("Selecione entre os professores abaixo o responsável pela disciplina cadastrada:");

            if (idxProfessor < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seleção inválida.Selecione uma das opções apresentadas.");
                Console.WriteLine("Se o professor esperado não estiver disponivel na lista, ele deve ser cadastrado usando o item 2 do Menu principal.");
                Console.ResetColor();
                return;
            }

            Professor responsavel = professores[idxProfessor];

            disciplinas.Add(new Disciplina(codigo, nomeDisciplina, cargaHoraria, responsavel));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Disciplina '{nomeDisciplina}' cadastrada com sucesso!");
            Console.ResetColor();
            Console.WriteLine($"Disciplina '{nomeDisciplina}' cadastrada com professor {responsavel} e carga horária de {cargaHoraria} horas.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar disciplina: {ex.Message}");
        }
        finally
        {
            Pausar();
        }
    }

    static void VincularDisciplinaCurso()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("*** Associar disciplina a um curso ***\n");

            if (cursos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum curso cadastrado. Cadastre um novo curso usando o item 1 do Menu principal.");
                Console.ResetColor();
                return;
            }

            if (disciplinas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhuma disciplina cadastrada. Cadastre uma nova disciplina usando o item 4 do Menu principal.");
                Console.ResetColor();
                return;
            }

            int idxCurso = SelecionarCurso("Selecione um curso abaixo para receber a disciplina:");
            if (idxCurso < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seleção inválida. Selecione uma das opções apresentadas.");
                Console.ResetColor();
                Console.WriteLine("Se o curso esperado não estiver disponivel na lista, ele deve ser cadastrado usando o item 1 do Menu principal.");
                return;
            }
            Curso curso = cursos[idxCurso];

            int idxDisc = SelecionarDisciplina("Selecione uma disciplina a ser associada ao curso selecionada:");
            if (idxDisc < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seleção inválida. Selecione uma das opções apresentadas.");
                Console.ResetColor();
                Console.WriteLine("Se a disciplina esperada não estiver disponivel na lista, ela deve ser cadastrada usando o item 4 do Menu principal.");
                return;
            }

            Disciplina disciplina = disciplinas[idxDisc];

            if (curso.Disciplinas.Contains(disciplina))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A disciplina já esta associada a este curso.");
                Console.ResetColor();
                return;
            }

            curso.Disciplinas.Add(disciplina);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Disciplina '{disciplina.Nome}' vinculada ao curso '{curso.Nome}' com sucesso!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao vincula disciplina ao curso: {ex.Message}");
        }
        finally
        {
            Pausar();
        }
    }

    private static void MatricularAluno()
    {
        Console.Clear();
        Console.WriteLine("*** Matricular Aluno Em Curso ***\n");

        Console.Write("Digite o número de matrícula do aluno: ");
        if (!int.TryParse(Console.ReadLine(), out int numMatricula))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNúmero de matrícula inválido.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        Aluno? alunoEscolhido = alunos.FirstOrDefault(a => a.NumeroMatricula == numMatricula);

        if (alunoEscolhido == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAluno com essa matrícula não foi encontrado.");
            Console.ResetColor();
            Pausar();
            return;
        }

        Console.Write("Digite o código do curso: ");
        string codigoCurso = (Console.ReadLine() ?? "").Trim();

        Curso? cursoEscolhido = cursos.FirstOrDefault(c =>
            c.Codigo.Equals(codigoCurso, StringComparison.OrdinalIgnoreCase));

        if (cursoEscolhido == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCurso não encontrado.");
            Console.ResetColor();
            Pausar();
            return;
        }

        // Verifica se já existe uma matrícula deste aluno neste mesmo curso
        bool jaMatriculado = matriculas.Any(m =>
            m.Aluno.NumeroMatricula == alunoEscolhido.NumeroMatricula &&
            m.Curso.Codigo.Equals(cursoEscolhido.Codigo, StringComparison.OrdinalIgnoreCase)); //outra forma e evitar código case sensitive

        if (jaMatriculado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nO aluno(a) {alunoEscolhido.Nome} já está matriculado(a) no curso '{cursoEscolhido.Nome}' e não pode ser matrículado novamente.");
            Console.ResetColor();
            Pausar();
            return;
        }

        var novaMatricula = new Matricula(alunoEscolhido, cursoEscolhido);

        matriculas.Add(novaMatricula);

        Console.WriteLine($"\nAluno(a) {alunoEscolhido.Nome} (Matrícula Aluno: {alunoEscolhido.NumeroMatricula}) matriculado(a) no curso '{cursoEscolhido.Nome}'!");
        Console.WriteLine("Boletim criado e vinculado automaticamente a esta matrícula.");

        Pausar();
    }

    static void LancarNota()
    {
        Console.Clear();
        Console.WriteLine("*** Lançamento de notas ***\n");

        Console.Write("Digite o número de mátricula do aluno: ");
        if (!int.TryParse(Console.ReadLine(), out int numeroMatricula))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Número da matrícula inválido");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        Aluno? alunoEscolhido = alunos.FirstOrDefault(a => a.NumeroMatricula == numeroMatricula);

        if (alunoEscolhido == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Aluno com essa matrícula não foi encontrado");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        Console.Write("Digite o código do curso: ");
        string codigoCurso = (Console.ReadLine() ?? "").Trim();

        Curso? cursoEscolhido = cursos.FirstOrDefault(c =>
            c.Codigo.Equals(codigoCurso, StringComparison.OrdinalIgnoreCase));

        if (cursoEscolhido == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Curso não encontrado");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        Matricula? matriculaEscolhida = matriculas.FirstOrDefault(m =>
            m.Aluno.NumeroMatricula == alunoEscolhido.NumeroMatricula &&
            m.Curso.Codigo.Equals(cursoEscolhido.Codigo, StringComparison.OrdinalIgnoreCase));

        if (matriculaEscolhida == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O aluno não está matrículado neste curso.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        Console.Write("Digite a disciplina: ");
        string codigoDisciplina = (Console.ReadLine() ?? "").Trim();

        Disciplina? disciplinaEscolhida = disciplinas.FirstOrDefault(d =>
            d.Codigo.Equals(codigoDisciplina, StringComparison.OrdinalIgnoreCase));

        if (disciplinaEscolhida == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Disciplina não encontrada no sistema.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        bool disciplinaPertenceCurso = cursoEscolhido.Disciplinas
            .Any(d => d.Codigo.Equals(codigoDisciplina, StringComparison.OrdinalIgnoreCase));

        if (!disciplinaPertenceCurso)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Esta disciplina não pertence ao curso informado.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        if (matriculaEscolhida.Boletim == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Não existe boletim associado a esta matrícula.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        Console.Write("Digite a nota (0 a 10): ");
        if (!double.TryParse(Console.ReadLine(), out double nota) || nota < 0 || nota > 10)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nota inválida! A nota deve estar entre 0 e 10.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        double notaMinimaAprovacao = cursoEscolhido.Tipo == TipoCurso.PosGraduacao ? 8.0 : 7.0;
        string statusAprovacao = nota >= notaMinimaAprovacao ? "Aprovado" : "Reprovado";

        matriculaEscolhida.Boletim.Notas.Add(new NotaDisciplina(disciplinaEscolhida, nota, statusAprovacao));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nNota {nota:F1} registrada com sucesso!");
        Console.ResetColor();

        Pausar();

    }
    static void ConsultarPessoas()
    {
        Console.Clear();
        Console.WriteLine("** Escolha Consultar Professor ou Aluno ***");
        Console.WriteLine("1 - Professor");
        Console.WriteLine("2 - Aluno");
        string escolhaPessoa = Console.ReadLine()!;

        {
            if (escolhaPessoa == "1")
            {
                Console.WriteLine("\n--- PROFESSORES CADASTRADOS ---");
                foreach (var professor in professores)
                {
                    Console.WriteLine($"Nome professor: {professor.Nome}");
                    Console.WriteLine($"CPF professor: {professor.Cpf}");
                    Console.WriteLine($"E-mail professor: {professor.Email}");
                    Console.WriteLine($"Registro professor: {professor.Registro}");
                    Console.WriteLine($"Especialidade professor: {professor.Especialidade}");
                    Console.WriteLine("---------------------------------------------");
                }
            }
            else if (escolhaPessoa == "2")
            {
                Console.WriteLine("\n--- ALUNOS CADASTRADOS ---");

                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"Nome aluno: {aluno.Nome}");
                    Console.WriteLine($"CPF aluno: {aluno.Cpf}");
                    Console.WriteLine($"E-mail aluno: {aluno.Email}");
                    Console.WriteLine($"Número de Matrícula: {aluno.NumeroMatricula}");
                    Console.WriteLine($"Cursos Matriculado: {string.Join(", ", matriculas.Where
                        (m => m.Aluno.NumeroMatricula == aluno.NumeroMatricula).Select(m => m.Curso.Nome))}");
                    Console.WriteLine("---------------------------------------------");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida.");
                Console.ResetColor();
            }
        }
        Pausar();
    }

    static void ConsultarCursos()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("*** Consultar curso ***\n");

            if (cursos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: nenhum curso cadastrado. Cadastre um curso usando o item 1 do Menu principal.");
                Console.ResetColor();
                return;
            }

            int idxCurso = SelecionarCurso("Selecione um curso para consultar:");
            if (idxCurso < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: seleção inválida. Selecione uma das opções apresentadas.");
                Console.ResetColor();
                return;
            }

            Curso curso = cursos[idxCurso];

            Console.WriteLine($"\nCódigo do Curso: {curso.Codigo}");
            Console.WriteLine($"Nome do Curso: {curso.Nome}");
            Console.WriteLine($"Tipo do Curso: {curso.DescricaoTipo}");

            Console.WriteLine("\nDisciplina(s): ");
            if (curso.Disciplinas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhuma disciplina vinculada a este curso.");
                Console.ResetColor();
            }
            else
            {
                foreach (Disciplina disciplina in curso.Disciplinas)
                {
                    Console.WriteLine(disciplina.Nome);
                    Console.WriteLine($"Professor: {disciplina.Professor.Nome}");
                }
            }

            List<Aluno> alunosMatriculados = matriculas
                .Where(m => m.Curso.Codigo.Equals(curso.Codigo, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.Aluno)
                .ToList();

            Console.WriteLine("\nAlunos matriculados neste curso: ");
            if (alunosMatriculados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum aluno matriculado neste curso.");
                Console.ResetColor();
            }
            else
            {
                foreach (Aluno aluno in alunosMatriculados)
                {
                    Console.WriteLine(aluno.Nome);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao consultar curso: {ex.Message}");
        }
        finally
        {
            Pausar();
        }
    }

    static void ConsultarMatriculas()
    {
        Console.WriteLine("*** Consulta matrícula ***\n");

        if (matriculas.Count == 0)
        {
            Console.WriteLine("Não há matrículas cadastradas no sistema.");
            return;
        }

        foreach (var matricula in matriculas)
        {
            Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
            Console.WriteLine($"Matrícula: {matricula.Aluno.NumeroMatricula}");
            Console.WriteLine($"Curso: {matricula.Curso.Nome}");
            Console.WriteLine($"Tipo: {matricula.Curso.Tipo}");
            Console.WriteLine("---------------------------------------------");
        }
        Pausar();
    }

    static void ConsultarBoletim()
    {

        Console.WriteLine("*** Consulta boletim ***\n");

        if (alunos.Count == 0)
        {
            Console.WriteLine("Aluno não encontrado.");
            return;
        }

        if (matriculas.Count == 0)
        {
            Console.WriteLine($"Não existem matrículas ativas.");
            return;
        }

        Console.WriteLine("\n--- ALUNOS CADASTRADOS ---");

        foreach (var i in alunos)
        {

            Console.WriteLine($"Nome: {i.Nome} / CPF: {i.Cpf} / Número de Matrícula: {i.NumeroMatricula}");

        }
        Console.Write("Digite o numero de matrícula para consultar o aluno: ");

        if (!int.TryParse(Console.ReadLine(), out int numMatricula))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNúmero de matrícula inválido.");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }
        Aluno? aluno = alunos.FirstOrDefault(a => a.NumeroMatricula == numMatricula);

        if (aluno == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A matricula {numMatricula} não foi encontrada");
            Console.ForegroundColor = ConsoleColor.White;
            Pausar();
            return;
        }

        foreach (var matricula in matriculas)
        {
            if (matricula.Boletim == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não há boletim associado a esta matrícula.");
                Console.ForegroundColor = ConsoleColor.White;
                Pausar();
                return;
            }
            Console.WriteLine("\n========= BOLETIM =========");
            Console.WriteLine($"Aluno: {matricula.Aluno.Nome}");
            Console.WriteLine($"Matrícula: {matricula.Aluno.NumeroMatricula}");
            Console.WriteLine($"Curso: {matricula.Curso.Nome}");
            Console.WriteLine($"Tipo: {matricula.Curso.Tipo}");

            foreach (var notaDisciplina in matricula.Boletim.Notas)
            {
                Console.WriteLine($"Disciplina: {notaDisciplina.Disciplina.Nome}"); // Supondo que Disciplina tenha uma propriedade Nome
                Console.WriteLine($"Nota: {notaDisciplina.Valor}");
                Console.WriteLine($"Situação: {notaDisciplina.Situacao}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        Pausar();
    }


    public static void Pausar()
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static string LerEmailValido(string mensagem = "E-mail: ")
    {
        string email;
        while (true)
        {
            Console.Write(mensagem);
            email = (Console.ReadLine() ?? "").Trim();
            if (Pessoa.EmailValido(email)) break;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O formato do e-mail digitado é inválido. Exemplo: nome@dominio.com");
            Console.ResetColor();
        }
        return email;
    }

    static int LerIndiceSelecionado(int totalItens)
    {
        Console.Write("Número: ");
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

    static void ReceberNotificacoes()
    {
        Console.WriteLine("*** Enviar Notificação ***\n");
        Console.WriteLine("Deseja notificar um professor ou um aluno? Digite '1' para professor ou '2' para aluno:");
        string tipo = Console.ReadLine()!;

        if (tipo == "1")
        {
            if (professores.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum professor cadastrado.");
                Console.ResetColor();
                Pausar();
                return;
            }

            for (int i = 0; i < professores.Count; i++)
            {
                Console.WriteLine($"[{i}] - {professores[i].Nome}");
            }

            Console.WriteLine("Digite o número do professor: ");
            int indice = int.TryParse(Console.ReadLine() ?? "0", out int result) ? result : 0;
            if (indice < 0 || indice >= professores.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Índice inválido.");
                Console.ResetColor();
                Pausar();
                return;
            }
            Console.Write("Digite a mensagem da notificação: ");
            string mensagem = Console.ReadLine()!;

            professores[indice].ReceberNotificacoes(mensagem);
            Console.WriteLine($"Notificação para {professores[indice].Nome}:{mensagem}");
        }
        else if (tipo == "2")
        {
            if (alunos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum aluno cadastrado.");
                Console.ResetColor();
                Pausar();
                return;
            }

            for (int i = 0; i < alunos.Count; i++)
            {
                Console.WriteLine($"[{i}] - {alunos[i].Nome}");
            }

            Console.Write("Digite o número do aluno: ");
            int indice = int.TryParse(Console.ReadLine() ?? "0", out int result) ? result : 0;
            if (indice < 0 || indice >= alunos.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Índice inválido.");
                Console.ResetColor();
                Pausar();
                return;
            }
            Console.Write("Digite a mensagem da notificação: ");
            string mensagem = Console.ReadLine()!;

            alunos[indice].ReceberNotificacoes(mensagem);
            Console.WriteLine($"Notificação para {alunos[indice].Nome}:{mensagem}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida.");
            Console.ResetColor();
            Pausar();
        }

        Pausar();
    }
   

}