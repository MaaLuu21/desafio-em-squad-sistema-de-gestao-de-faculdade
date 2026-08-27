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

    public Curso(string codigo, string nome, TipoCurso tipo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("O código do curso não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do curso não pode ser vazio.");

        Codigo = codigo.Trim().ToUpper();
        Nome = nome.Trim();
        Tipo = tipo;
    }

    public string DescricaoTipo => Tipo == TipoCurso.Graduacao ? "Graduação" : "Pós-graduação";

    public override string ToString()
    {
        return $"Código: {Codigo} | Nome: {Nome} | Tipo: {DescricaoTipo}";
    }
}