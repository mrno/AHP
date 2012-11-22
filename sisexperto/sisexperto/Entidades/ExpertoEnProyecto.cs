using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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


        //public int ConjuntoEtiquetasId { get; set; }
        public virtual ConjuntoEtiquetas ConjuntoEtiquetas { get; set; }
        
        public virtual CriterioMatriz CriterioMatriz { get; set; }

        public virtual ICollection<AlternativaMatriz> AlternativasMatrices { get; set; }

        


        public double[,] GenerarMatrizAlternativas(Criterio Criterio)
        { 

            var dimension = Proyecto.Alternativas.Count;
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
                    matriz[comp.Fila, comp.Columna] = comp.ValorAHP;
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
            List<double[,]> listaMatrizAlternativas = new List<double[,]>();
            /*
            foreach (var AlternativasPorCriterioExperto in ValoracionAlternativasPorCriterioExperto)
            {
                listaMatrizAlternativas.Add(AlternativasPorCriterioExperto.Matriz);
            }*/
            return listaMatrizAlternativas;
        }

        public List<double[,]> ListaCriterioAlternativas()
        {
            List<double[,]> listaCriterioAlternativas = new List<double[,]>();
            /*
            foreach (var valoracionCriteriosPorExperto in this.ValoracionCriteriosPorExperto)
            {
                listaCriterioAlternativas.Add(valoracionCriteriosPorExperto.Matriz);
            }
           */
            listaCriterioAlternativas.AddRange(ListaMatrizAlternativas());
            return listaCriterioAlternativas;

        }

        public double[,] CalcularMiRanking()
        {
            if (TodasMisValoracionesConsistentes())
            {
                return FachadaCalculos.Instance.calcularRanking(this.ListaCriterioAlternativas());
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
            bool flag= false;
            /*
            foreach (var valoracionCriteriosPorExperto in ValoracionCriteriosPorExperto)
            {
                flag = (valoracionCriteriosPorExperto.Consistencia == true) ? true : false;
            }
            */
            return flag;
        }
        
        private bool MisAlternativasConsistentes()
        {
            /*
            var cantidadCriterios = ValoracionAlternativasPorCriterioExperto.Count();

            var listaAlternativasConsistente = from e in ValoracionAlternativasPorCriterioExperto
                                               where e.Consistencia = true
                                               select e;
            return cantidadCriterios == listaAlternativasConsistente.Count();*/
            return true;
        }

    }
}
