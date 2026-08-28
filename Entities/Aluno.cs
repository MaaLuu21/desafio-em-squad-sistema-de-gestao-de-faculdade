using SistemaGestaoDeFaculdade.Entities;

namespace SistemaGestaoDeFaculdade;

public class Aluno : Pessoa
{
    public int NumeroMatricula { get; set; }

    public Aluno(string nome, string cpf, string email, int numeroMatricula)
        : base(nome, cpf, email)
    {
        NumeroMatricula = numeroMatricula;
    }
    public static bool CpfJaCadastrado(string cpf, List<Aluno> alunos)
    {
        return alunos.Any(a => a.Cpf == cpf);
    }
}