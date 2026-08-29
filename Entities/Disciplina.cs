using System;

namespace SistemaGestaoDeFaculdade.Entities
{
    public class Disciplina
    {
        // Propriedades com "set" privado: uma vez criada, a disciplina nao muda seus dados.
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public int CargaHoraria { get; private set; }

        // Professor responsavel pela disciplina (composicao: a disciplina "tem um" professor).
        public Professor Professor { get; private set; }

        public Disciplina(string codigo, string nome, int cargaHoraria, Professor professor)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("Código inválido. O código da disciplina não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido. O nome da disciplina não pode ser vazio.");

            if (cargaHoraria <= 0)
                throw new ArgumentException("Carga horaria inválida. A carga horaria deve ser um número positivo.");

            if (professor == null)
                throw new ArgumentException("Toda disciplina precisa de um professor responsavel.");

            Codigo = codigo.Trim().ToUpper();
            Nome = nome.Trim();
            CargaHoraria = cargaHoraria;
            Professor = professor;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nome} ({CargaHoraria}h | Prof: {Professor.Nome})";
        }
    }
}