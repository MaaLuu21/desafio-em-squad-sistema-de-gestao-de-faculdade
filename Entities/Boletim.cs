using System.Reflection.Metadata.Ecma335;

namespace SistemaGestaoDeFaculdade.Entities
{
    public class Boletim
    {
        public List<NotaDisciplina> Notas { get; private set; } = [];

        public Boletim() { }
        public Boletim(List<NotaDisciplina> notas)
        {
            Notas = notas ?? new();
        }

    }
}