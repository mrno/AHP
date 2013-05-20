using sisExperto.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace sisexperto.Entidades.AHP
{
    public class ValoracionAHP : Valoracion, ICloneable
    {
        public virtual CriterioMatriz CriterioMatriz { get; set; }
        public virtual ICollection<AlternativaMatriz> AlternativasMatrices { get; set; }

        public double[,] GenerarMatrizAlternativas(Criterio Criterio)
        {
            int dimension = ExpertoEnProyecto.Proyecto.Alternativas.Count;
            var matriz = new double[dimension, dimension];

            
            /*
            List<ValoracionAlternativasPorCriterioExperto> listaValoracion = 
                (from c in ValoracionAlternativasPorCriterioExperto
                                   where c.Criterio.CriterioId == Criterio.CriterioId
                                   select c).ToList();

            foreach (var val in listaValoracion)
            {
                foreach (var comp in val.ComparacionAlternativasPorCriterio)
                {
                    matriz[comp.Fila, comp.Columna] = comp.Valor;
                }                    
            }

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i==j)
                        matriz[i, j] = 1;
                    if (i>j)
                        matriz[i, j] = (double)1.0/matriz[j, i];
                }
            }
            */
            return matriz;
        }

        public void GuardarMatrizAlternativas(double[,] MatrizAlternativa, Criterio Criterio)
        {
        }

        private List<double[,]> ListaMatrizAlternativas()
        {
            return (from c in AlternativasMatrices
                    select c.Matriz).ToList();
        }

        public List<double[,]> ListaCriterioAlternativas()
        {
            var listaCriterioAlternativas = new List<double[,]>();

            listaCriterioAlternativas.Add(CriterioMatriz.Matriz);

            listaCriterioAlternativas.AddRange(ListaMatrizAlternativas());
            return listaCriterioAlternativas;
        }

        public bool TodasMisValoracionesConsistentes()
        {
            return MisCriteriosConsistentes() && MisAlternativasConsistentes();
        }

        private bool MisCriteriosConsistentes()
        {
            return CriterioMatriz.Consistencia;
        }

        private bool MisAlternativasConsistentes()
        {
            bool flag = true;
            foreach (AlternativaMatriz matrizAlter in AlternativasMatrices)
            {
                flag &= matrizAlter.Consistencia;
            }
            return flag;
        }

        //#region Implementation of ICloneable

        //public object Clone()
        //{
        //    var alternativas = from c in AlternativasMatrices
        //                       select
        //                           new AlternativaMatriz
        //                               {
        //                                   Matriz = c.Matriz,
        //                                   Consistencia = c.Consistencia,
                                           
        //                               };

        //    return new ValoracionAHP
        //               {
        //                   AlternativasMatrices = alternativas.ToList(),
        //                   CriterioMatriz = new CriterioMatriz()
        //               };
        //}

        //#endregion

        #region Implementation of ICloneable

        public object Clone()
        {
            return new ValoracionAHP
                       {
                           AlternativasMatrices = new List<AlternativaMatriz>()
                       };
        }

        #endregion
    }
}
