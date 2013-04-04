using System.Collections.Generic;
using System.Linq;
using GALibrary.Complementos;

namespace GALibrary.Persistencia
{
    public class ConjuntoMatriz
    {
        public virtual int Id { get; set; }
        public virtual ICollection<ObjetoMatriz> Matrices { get; set; }
        public virtual int Dimension { get; set; }

        public ConjuntoMatriz()
        {
        }

        public ConjuntoMatriz(int cantidadMatrices, int dimensionMatrices)
        {
            Matrices = new List<ObjetoMatriz>();
            Dimension = dimensionMatrices;
            GenerarMatrices(cantidadMatrices);
        }

        private void GenerarMatrices(int cantidad)
        {

            while (Matrices.Count(x => x.Inconsistencia.Entre(0.1, 0.3)) < cantidad ||
                Matrices.Count(x => x.Inconsistencia.Entre(0.3, 0.5)) < cantidad ||
                Matrices.Count(x => x.Inconsistencia.Entre(0.5, double.MaxValue)) < cantidad)
            {
                var objetoMatriz = new ObjetoMatriz(this, true, false);

                if (objetoMatriz.Inconsistencia.Entre(0.1, 0.3))
                {
                    if (Matrices.Count(x => x.Inconsistencia.Entre(0.1, 0.3)) < cantidad)
                    {
                        Matrices.Add(objetoMatriz);
                    }
                }
                else
                {
                    if (objetoMatriz.Inconsistencia.Entre(0.3, 0.5))
                    {
                        if (Matrices.Count(x => x.Inconsistencia.Entre(0.3, 0.5)) < cantidad)
                        {
                            Matrices.Add(objetoMatriz);
                        }
                    }
                    else
                    {
                        if (objetoMatriz.Inconsistencia.Entre(0.5, double.MaxValue))
                        {
                            if (Matrices.Count(x => x.Inconsistencia.Entre(0.5, double.MaxValue)) < cantidad)
                            {
                                Matrices.Add(objetoMatriz);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < cantidad; i++)
            {
                Matrices.Add(new ObjetoMatriz(this, matricesConFaltantes: 3));
            }
        }
    }
}
