using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
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
        public int Peso { get; set; }


        //public int ValoracionCriteriosPorExpertoId { get; set; }
        public virtual ICollection<ValoracionCriteriosPorExperto> ValoracionCriteriosPorExperto { get; set; }

        public virtual ICollection<ValoracionAlternativasPorCriterioExperto> ValoracionAlternativasPorCriterioExperto { get; set; }

        private double[,] MatrizCriterio()
        {
            //AGREGAR DEFINICION
            return this.ValoracionCriteriosPorExperto.Matriz;
        }

        public double[,] MatrizCriterioAHP
        {
            get
            {
                var matriz = new double[Proyecto.Criterios.Count,Proyecto.Criterios.Count];

                foreach (var val in ValoracionCriteriosPorExperto)
                {
                    foreach (var comp in val.ComparacionCriterios)
                    {
                        matriz[comp.Fila, comp.Columna] = comp.ValorAHP;
                    }
                    
                }
                for (int i = 0; i < Proyecto.Criterios.Count; i++)
                {
                    for (int j = 0; j < Proyecto.Criterios.Count; j++)
                    {
                        if (i==j)
                            matriz[i, j] = 1;
                        if (i>j)
                            matriz[i, j] = (double)1.0/matriz[j, i];
                    }
                }
                return matriz;
            } 
            set
            {
                if(ValoracionCriteriosPorExperto.Count == 0)
                {
                    var listaC = Proyecto.Criterios;
                    var j = 0;
                    for (int i = 0; i < Proyecto.Criterios.Count - 1; i++)
                    {
                        listaC.Remove(listaC.First());
                        var k = j;
                        var compC = from c in listaC
                                    select new ComparacionCriterio()
                                               {
                                                   Fila = i,
                                                   Columna = ++k,
                                                   Criterio = listaC.ElementAt(k - j - 1),
                                                   ValorAHP = 0,
                                                   ValorIL = 0
                                               };

                        ValoracionCriteriosPorExperto.Add(
                            new ValoracionCriteriosPorExperto()
                                {
                                    Consistencia = false,
                                    Criterio = Proyecto.Criterios.ElementAt(i),
                                    ComparacionCriterios = compC.ToList()
                                });
                        j++;
                    }
                }
                else
                {
                    var listaC = new List<ComparacionCriterio>();

                    foreach (var val in ValoracionCriteriosPorExperto)
                    {
                        listaC.AddRange(val.ComparacionCriterios);
                    }

                    for (int i = 0; i < value.GetLength(0) - 1; i++)
                    {
                        for (int j = i + 1; j < value.GetLength(1); j++)
                        {
                            var celda = (from item in listaC
                                         where item.Columna == j && item.Fila == i
                                         select item).FirstOrDefault();
                            celda.ValorAHP = value[i, j];
                        }
                    }
                }
            }
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


       

    }

}
