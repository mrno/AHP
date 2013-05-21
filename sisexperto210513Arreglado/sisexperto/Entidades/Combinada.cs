using sisExperto.Entidades;
using sisexperto.Entidades.IL;

namespace sisexperto.Entidades
{
    public class Combinada
    {
        public string ExpertoNombre { get; set; }
        public string ExpertoApellido { get; set; }
        public bool Admin { get; set; }
        public Experto Experto { get; set; }
        public string ConjuntoEtiquetasNombre { get; set; }
        public ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
    }
}