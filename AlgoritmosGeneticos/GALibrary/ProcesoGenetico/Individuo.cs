using GALibrary.Complementos;
using GALibrary.Persistencia;

namespace GALibrary.ProcesoGenetico
{
    public class Individuo
    {
        #region Propiedades

        public double[] Vector { get; set; }
        public double[,] Matriz { get { return Utilidades.ConvertirVectorEnMatriz(Vector); } }
        public double? Inconsistencia { get; set; }

        #endregion

        public Individuo(ObjetoMatriz objetoMatriz)
        {
            Vector = objetoMatriz.Vector;
            Inconsistencia = objetoMatriz.Inconsistencia;
        }
    }
}
