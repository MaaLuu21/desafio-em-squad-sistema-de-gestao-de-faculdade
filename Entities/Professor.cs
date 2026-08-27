namespace SistemaGestaoDeFaculdade.Entities;

/// <summary>
/// Entidade Professor
/// Herança: reaproveita Nome, Cpf, Email e Notificações de Pessoa
/// </summary>
public class Professor : Pessoa
{
    public string Registro { get; private set; }
    public string Especialidade { get; private set; }

    public Professor(string nome, string cpf, string email, string registro, string especialidade)
        : base(nome, cpf, email)
    {
        if (string.IsNullOrWhiteSpace(registro))
            throw new ArgumentException("O registro do professor não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(especialidade))
            throw new ArgumentException("A especialidade do professor não pode ser vazia.");

        Registro = registro.Trim();
        Especialidade = especialidade.Trim();
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | CPF: {Cpf} | E-mail: {Email} | Registro: {Registro} | Especialidade: {Especialidade}";
    }
}