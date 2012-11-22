using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using probaAHP;
using sisexperto.Fachadas;

namespace sisExperto.Entidades
{
    [Table("Proyectos")]
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }

        public string Estado { get; set; }
        
        public int Tipo
        {//1=AHP, 2=IL, 3=AMBOS
            get;
            set;
        }

        public int CreadorId { get; set; }
        public virtual Experto Creador { get; set; }

        public virtual ICollection<ExpertoEnProyecto> ExpertosAsignados { get; set; }

        public virtual ICollection<Criterio> Criterios { get; set; }

        public virtual ICollection<Alternativa> Alternativas { get; set; }

        ////cambiar esto: sacar
        //public virtual ICollection<CriterioFila> CriteriosValoradosPorExpertos { get; set; }

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyectoConsistente()
        {
            IEnumerable<ExpertoEnProyecto> lista = from p in ExpertosAsignados
                                                   where p.TodasMisValoracionesConsistentes()
                                                   select p
                ;
            Int32 denominador = 0;
            foreach (ExpertoEnProyecto expertoEnProyecto in lista)
            {
                denominador += Convert.ToInt32(expertoEnProyecto.Peso);
            }

            foreach (ExpertoEnProyecto expertoEnProyecto in lista)
            {
                expertoEnProyecto.Ponderacion = (double) 1/denominador;
            }
            return lista;
        }

        public void CalcularRankingNoPonderado()
        {
            var utils = new Utils();
            var listaCompleta = new List<double[,]>();
            var listaAlternativas = new List<double[,]>();


            var matrizCriterio = new double[Criterios.Count,Criterios.Count];
            utils.Cerar(matrizCriterio, Criterios.Count);


            for (int i = 0; i < Alternativas.Count; i++)
            {
                var AlternativasAgregada = new double[Alternativas.Count,Alternativas.Count];
                utils.Unar(AlternativasAgregada, Alternativas.Count);
                listaAlternativas.Add(AlternativasAgregada);
            }

            foreach (var expertoEnProyecto in ExpertosAsignados)
            {               
                if(expertoEnProyecto.TodasMisValoracionesConsistentes())
                {
                    utils.Productoria(matrizCriterio, expertoEnProyecto.CriterioMatriz.MatrizCriterioAHP);

                    int k = 0;
                    foreach (var d in expertoEnProyecto.AlternativasMatrices)
                    {
                        utils.Productoria(listaAlternativas[k], d.MatrizAlternativaAHP);
                        k++;
                    }
                }
            }
            listaCompleta.Add(matrizCriterio);
            listaCompleta.AddRange(listaAlternativas);


            double[,] ranking =  FachadaCalculos.Instance.calcularRanking(listaCompleta);

            MostrarRanking mostrarRanking = new MostrarRanking(ranking, this, 1);
            mostrarRanking.ShowDialog();
        }


        public void CalcularRankinPonderado()
        {
            var utils = new Utils();

            int dimension = Alternativas.Count;
            var rankAgregado = new double[dimension,1];
            utils.Cerar(rankAgregado,1);
            foreach (ExpertoEnProyecto d in ObtenerExpertosProyectoConsistente())
            {
                double[,] matriz = d.CalcularMiRanking();
                for (int i = 0; i < dimension; i++)
                {
                    rankAgregado[i, 0] += matriz[i, 0]*d.Ponderacion;
                }
            }

            MostrarRanking mostrarRanking = new MostrarRanking(rankAgregado, this, 2);
            mostrarRanking.ShowDialog();
        }
    }
}