using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Complementos;

namespace GALibrary.Persistencia
{
    public class ConjuntoOrdenN
    {
        public virtual int Id { get; set; }
        public virtual int Dimension { get; set; }

        public ICollection<ConjuntoMatriz> ConjuntosMatrices { get; set; }

        public ConjuntoOrdenN()
        {
        }

        public ConjuntoOrdenN(int dimensionMatrices)
        {
            ConjuntosMatrices = new List<ConjuntoMatriz>();
            Dimension = dimensionMatrices;
        }

        public static List<ConjuntoMatriz> GenerarConjuntosDiferenciadosPorNivelDeInconsistencia(int cantidad, int dimension)
        {
            var conjuntos = new List<ConjuntoMatriz>();
            var conjuntoConsistente = new ConjuntoMatriz(NivelInconsistencia.Consistente);
            conjuntos.Add(conjuntoConsistente);
            var conjuntoInconsistenteBajo = new ConjuntoMatriz(NivelInconsistencia.Bajo);
            conjuntos.Add(conjuntoInconsistenteBajo); 
            var conjuntoInconsistenteMedio = new ConjuntoMatriz(NivelInconsistencia.Medio);
            conjuntos.Add(conjuntoInconsistenteMedio); 
            var conjuntoInconsistenteAlto = new ConjuntoMatriz(NivelInconsistencia.Alto);
            conjuntos.Add(conjuntoInconsistenteAlto);
            
            while (conjuntoInconsistenteBajo.Matrices.Count < cantidad || conjuntoInconsistenteMedio.Matrices.Count < cantidad
                || conjuntoInconsistenteAlto.Matrices.Count < cantidad)
            {
                var objetoMatriz = new ObjetoMatriz(dimension, true, false);

                if (objetoMatriz.NivelDeInconsistencia == NivelInconsistencia.Bajo)
                {
                    if (conjuntoInconsistenteBajo.Matrices.Count < cantidad)
                    {
                        conjuntoInconsistenteBajo.Matrices.Add(objetoMatriz);
                    }
                }
                else
                {
                    if (objetoMatriz.NivelDeInconsistencia == NivelInconsistencia.Medio)
                    {
                        if (conjuntoInconsistenteMedio.Matrices.Count < cantidad)
                        {
                            conjuntoInconsistenteMedio.Matrices.Add(objetoMatriz);
                        }
                    }
                    else
                    {
                        if (objetoMatriz.NivelDeInconsistencia == NivelInconsistencia.Alto)
                        {
                            if (conjuntoInconsistenteAlto.Matrices.Count < cantidad)
                            {
                                conjuntoInconsistenteAlto.Matrices.Add(objetoMatriz);
                            }
                        }
                    }
                }
            }

            while (conjuntoConsistente.Matrices.Count < cantidad)
            {
                var objetoMatriz = new ObjetoMatriz(dimension);
                if (objetoMatriz.NivelDeInconsistencia == NivelInconsistencia.Consistente)
                {
                    conjuntoConsistente.Matrices.Add(objetoMatriz);
                }
            }

            return conjuntos;
        }
    }
}
