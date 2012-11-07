using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using sisexperto.Fachadas;

namespace sisExperto.Entidades
{
    [Table("ExpertosPonderadosEnProyectos")]
    public class ExpertoEnProyecto
    {
        [Key, Column(Order = 0)]
        public int ProyectoId { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        [Key, Column(Order = 1)]
        public int ExpertoId { get; set; }

        public virtual Experto Experto { get; set; }

        public double Ponderacion { get; set; }
        public double Peso { get; set; }

        public virtual ValoracionCriteriosPorExperto ValoracionCriteriosPorExperto { get; set; }
        public virtual ICollection<ValoracionAlternativasPorCriterioExperto> ValoracionAlternativasPorCriterioExperto { get; set; }





        private double[,] MatrizCriterio()
        {
            return this.ValoracionCriteriosPorExperto.Matriz;
        }

        private List<double[,]> ListaMatrizAlternativas()
        {

            List<double[,]> listaMatrizAlternativas = new List<double[,]>();

            foreach (var AlternativasPorCriterioExperto in ValoracionAlternativasPorCriterioExperto)
            {
                listaMatrizAlternativas.Add(AlternativasPorCriterioExperto.Matriz);
            }
            return listaMatrizAlternativas;
        }

        public List<double[,]> ListaCriterioAlternativas()
        {
            List<double[,]> listaCriterioAlternativas = new List<double[,]>();
            listaCriterioAlternativas.Add(MatrizCriterio());
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

            bool CriteriosConsistentes = ValoracionCriteriosPorExperto.Consistencia = true;

            var cantidadCriterios = ValoracionAlternativasPorCriterioExperto.Count();

            var listaAlternativasConsistente = from e in ValoracionAlternativasPorCriterioExperto
                                               where e.Consistencia = true
                                               select e;
            return CriteriosConsistentes || cantidadCriterios == listaAlternativasConsistente.ToList().Count();
        }


        public void EstablecerMiPoderacion()
        {
            



        }

    }

}
