using GALibrary.Complementos;
using GALibrary.Persistencia;

namespace GALibrary.ProcesoGenetico.Entidades
{
    public class Estructura
    {
        #region Propiedades

        public double[] Vector { get; set; }
        public double[,] Matriz { get { return Utilidades.ConvertirVectorEnMatriz(Vector); } }
        public double? Inconsistencia { get; set; }

        public double[] Faltantes 
        { 
            get { return Vector.ValoresFaltantes(); }
        }

        public double[] Completos
        {
            get { return Vector.ValoresCompletos(); }
        }

        #endregion

        public Estructura(ObjetoMatriz objetoMatriz)
        {
            Vector = objetoMatriz.Vector;
            Inconsistencia = objetoMatriz.Inconsistencia;
            _cantidadCaracteristicas = 0;
        }

        private int _cantidadCaracteristicas;

        public int CantidadCaracteristicas 
        {
            get
            {
                if(_cantidadCaracteristicas == 0)
                {
                    //_cantidadCaracteristicas = Faltantes.Length;
                    //if(_cantidadCaracteristicas == 0)
                    //{
                        _cantidadCaracteristicas = Vector.Length;
                    //}
                }
                return _cantidadCaracteristicas;
            }
        }
    }
}
