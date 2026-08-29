namespace SistemaGestaoDeFaculdade.Entities;

public class NotaDisciplina
{
    public Disciplina Disciplina { get; set; }
    public double Valor { get; set; }
    public string Situacao { get; set; } = "Reprovado";// "Aprovado" ou "Reprovado"

    public NotaDisciplina(Disciplina disciplina, double valor, string situacao)
    {
        Disciplina = disciplina;
        Valor = valor;
        Situacao = situacao;
    }
}