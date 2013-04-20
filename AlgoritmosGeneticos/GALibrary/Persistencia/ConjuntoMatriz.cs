using System.Collections.Generic;
using System.Linq;
using GALibrary.Complementos;

namespace GALibrary.Persistencia
{
    public class ConjuntoMatriz
    {
        public int Id { get; set; }
        public virtual ConjuntoOrdenN ConjuntoOrdenN { get; set; }
        public virtual ICollection<ObjetoMatriz> Matrices { get; set; }
        public virtual NivelInconsistencia NivelInconsistencia { get; set; }

        public ConjuntoMatriz()
        {
        }

        public ConjuntoMatriz(NivelInconsistencia nivelInconsistencia)
        {
            Matrices = new List<ObjetoMatriz>();
            NivelInconsistencia = nivelInconsistencia;
        }
    }

    public enum NivelInconsistencia
    {
        Consistente,
        Bajo,
        Medio,
        Alto,
        NoTiene
    }
}
