namespace SistemaGestaoDeFaculdade.Entities
{
    public class Matricula
    {
        //coisas que criei que preciso além do obvio é a classe notadisciplina e boletim
        public Aluno Aluno { get; private set; }
        public Curso Curso { get; private set; }
        public Boletim Boletim { get; private set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            ValidarAluno(aluno);
            ValidarCurso(curso);
            Aluno = aluno;
            Curso = curso;
            Boletim = new Boletim();
        }

        private void ValidarAluno(Aluno aluno)
        {
            if (aluno == null || aluno.NumeroMatricula <= 0)
            {
                throw new ArgumentException("Aluno não encontrado");
            }
        }

        private void ValidarCurso(Curso curso)
        {
            if(curso == null)
            {
                throw new ArgumentException("Curso não encontrado");
            }
        }
    }
}
