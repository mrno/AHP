using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using probaAHP;
using sisexperto.Entidades;
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

        public int Tipo { //1=AHP, 2=IL, 3=AMBOS
            get; set; }

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
                                                   select p;
             
            Int32 denominador = 0;
            foreach (ExpertoEnProyecto expertoEnProyecto in lista)
            {
                denominador += Convert.ToInt32(expertoEnProyecto.Peso);
            }

            foreach (ExpertoEnProyecto expertoEnProyecto in lista)
            {
                expertoEnProyecto.Ponderacion = (double) expertoEnProyecto.Peso/denominador;
            }
            return lista;
        }




        public double[,] CalcularRankingAHPNoPonderado()
        {
            var utils = new Utils();
            var listaCompleta = new List<double[,]>();
            var listaAlternativas = new List<double[,]>();
            int k;
            int kk = 0;

            var matrizCriterio = new double[Criterios.Count,Criterios.Count];
            utils.Unar(matrizCriterio, Criterios.Count);


            for (int i = 0; i < Criterios.Count; i++)
            {
                var AlternativasAgregada = new double[Alternativas.Count,Alternativas.Count];
                utils.Unar(AlternativasAgregada, Alternativas.Count);
                listaAlternativas.Add(AlternativasAgregada);
            }



            foreach (ExpertoEnProyecto expertoEnProyecto in ExpertosAsignados)
            {
                if (expertoEnProyecto.TodasMisValoracionesConsistentes())
                {
                    utils.Productoria(matrizCriterio, expertoEnProyecto.CriterioMatriz.Matriz);

                    k = 0;
                    foreach (AlternativaMatriz d in expertoEnProyecto.AlternativasMatrices)
                    {
                        utils.Productoria(listaAlternativas[k], d.Matriz);
                        k++;
                    }
                    kk++;
                }
            }

            listaCompleta.Add(matrizCriterio);
            listaCompleta.AddRange(listaAlternativas);
           
            double exponente = (double)1/kk;
            foreach (double[,] doublese in listaCompleta)
            {

                for (int i = 0; i < doublese.GetLength(0); i++)
                {
                    for (int j = 0; j < doublese.GetLength(0); j++)
                    {
                        doublese[i, j] = Math.Pow(doublese[i, j], exponente);
                    }
                    
                }
                
            }




            double[,] ranking = FachadaCalculos.Instance.calcularRanking(listaCompleta);

            return ranking;
            //MostrarRanking mostrarRanking = new MostrarRanking(ranking, this, 1);
            //mostrarRanking.ShowDialog();
        }


        public double[,] CalcularRankinAHPPonderado()
        {
            var utils = new Utils();

            int dimension = Alternativas.Count;
            var rankAgregado = new double[dimension,1];
            utils.Cerar(rankAgregado, 1);
            foreach (ExpertoEnProyecto d in ObtenerExpertosProyectoConsistente())
            {
                double[,] matriz = d.CalcularMiRankingAHP();
                for (int i = 0; i < dimension; i++)
                {
                    rankAgregado[i, 0] += matriz[i, 0]*d.Ponderacion;
                }
            }
            return rankAgregado;
            //MostrarRanking mostrarRanking = new MostrarRanking(rankAgregado, this, 2);
            //mostrarRanking.ShowDialog();
        }
        //1=media geometrica 2=ponderada
        public double[,] CalcularRankingILNoPonderado(int TipoAgregacion)
    {

        var utils = new Utils();

        int dimension = Alternativas.Count;
        var rankAgregado = new double[dimension, 1];
        utils.Cerar(rankAgregado, 1);
        Utils util = new Utils();
        ValoracionIL resultado = util.ObtenerEstructuraRdo(ExpertosAsignados.First().ValoracionIl);
        int k = 0;



            int cardinalidadCEN = ObtenerCardinalidadCEN();

        foreach (var exp in ExpertosAsignados)
        {
          
            exp.CalcularMiRankingIL(resultado, cardinalidadCEN);

            k++;
        }

            
            Boolean res = TipoAgregacion == 2 ? true : false;

        util.AgregacionMediaGeometricaKExpertos(resultado, ExpertosAsignados.Count);
            foreach (AlternativaIL alternativaIl in resultado.AlternativasIL)
            {
              //  utils.MultiplicarWCriterios(alternativaIl.ValorCriterios);    
            }
            

        utils.AgregacionCriterios(resultado, rankAgregado);
          
           return utils.NormalizarIlFinal((rankAgregado));
    }
        public int ObtenerCardinalidadCEN()
        {
            Utils util = new Utils();
            List<int> lista = new List<int>();

            foreach (var exp in ExpertosAsignados)
            {
                lista.Add(exp.ValoracionIl.ConjuntoEtiquetas.Cantidad - 1);
            }
           return util.Mcm(lista.ToArray());
        }

        public void MultiplicarPorExpPesos(ValoracionIL resultado)
        {


            foreach (ExpertoEnProyecto expertoEnProyecto    in ExpertosAsignados   )
            {


                foreach (AlternativaIL alternativaIl in resultado.AlternativasIL)
                {
                    


                }
            }
        }




        public  int ArmarConjuntoEtiquetasNormalizado()
        {
            Utils utils = new Utils();
            List<Int32> listaCardinalidadEtiquetasK = new List<int>();
            foreach (ExpertoEnProyecto expertoEnProyecto in ExpertosAsignados)
            {
                listaCardinalidadEtiquetasK.Add(expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Cantidad-1);
            }
            Int32 cardinalidadCEN = utils.Mcm(listaCardinalidadEtiquetasK.ToArray());
            return cardinalidadCEN;
        }



    }
}