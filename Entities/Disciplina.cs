using System;

namespace SistemaGestaoDeFaculdade.Entities
{
    // Uma disciplina pode ser vinculada a um ou mais cursos (o vinculo fica no Curso).
    // O professor responsavel deve existir ANTES da criacao (validado em CadastrarDisciplina).
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
            Codigo = codigo;
            Nome = nome;
            CargaHoraria = cargaHoraria;
            Professor = professor;
        }
    }
}
