namespace SistemaGestaoDeFaculdade.Entities;

using SistemaGestaoDeFaculdade.Enums;

/// <summary>
/// Entidade Curso
/// Encapsulamento: as propriedades têm "set" privado porque depois de
/// criado um curso não pode ser alterado por fora da classe.
/// </summary>
public class Curso
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public TipoCurso Tipo { get; private set; }
    public List<Disciplina> Disciplinas { get; private set; } = new List<Disciplina>(); 

    public Curso(string codigo_curso, string nome_curso, TipoCurso tipo_curso)
    {
        if (string.IsNullOrWhiteSpace(codigo_curso))
            throw new ArgumentException("O código do curso não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(nome_curso))
            throw new ArgumentException("O nome do curso não pode ser vazio.");

        Codigo = codigo_curso.Trim().ToUpper();
        Nome = nome_curso.Trim();
        Tipo = tipo_curso;
    }

    public string DescricaoTipo => Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-graduação";

    public override string ToString()
    {
        return $"Código: {Codigo} | Nome: {Nome} | Tipo: {DescricaoTipo}";
    }
}