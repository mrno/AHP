using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using sisexperto.Entidades;
using sisexperto.Fachadas;

namespace sisExperto.Entidades
{
    [Table("ExpertosEnProyecto")]
    public class ExpertoEnProyecto
    {
        public int ExpertoEnProyectoId { get; set; }
        public int ProyectoId { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public int ExpertoId { get; set; }
        public virtual Experto Experto { get; set; }
        public double Ponderacion { get; set; }
        public int Peso { get; set; }
        
        public virtual CriterioMatriz CriterioMatriz { get; set; }
        public virtual ICollection<AlternativaMatriz> AlternativasMatrices { get; set; }
       
        public virtual ValoracionIL ValoracionIl { get; set; }

        public double[,] GenerarMatrizAlternativas(Criterio Criterio)
        {
            int dimension = Proyecto.Alternativas.Count;
            var matriz = new double[dimension,dimension];
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
        
        public double[,] CalcularMiRanking()
        {
            if (TodasMisValoracionesConsistentes())
            {
                return FachadaCalculos.Instance.calcularRanking(ListaCriterioAlternativas());
            }
            else
            {
                return new double[1,1];
            }
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
    }
}