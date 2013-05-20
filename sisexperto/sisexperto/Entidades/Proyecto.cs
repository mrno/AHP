using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using probaAHP;
using sisexperto.Entidades;
using sisexperto.Fachadas;
using sisexperto.Entidades.AHP;

namespace sisExperto.Entidades
{
    [Table("Proyectos")]
    public class Proyecto : ICloneable
    {
        #region Propiedades

        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Objetivo { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; } //1=AHP, 2=IL, 3=AMBOS

        public int? ProyectoClonadoId { get; set; }

        public int CreadorId { get; set; }
        public virtual Experto Creador { get; set; }

        public virtual ICollection<ExpertoEnProyecto> ExpertosAsignados { get; set; }
        public virtual ICollection<Criterio> Criterios { get; set; }
        public virtual ICollection<Alternativa> Alternativas { get; set; }
        public virtual ICollection<ConjuntoEtiquetas> ConjuntosDeEtiquetas { get; set; }

        #endregion

        ////cambiar esto: sacar
        //public virtual ICollection<CriterioFila> CriteriosValoradosPorExpertos { get; set; }

        public IEnumerable<ExpertoEnProyecto> ExpertosEnProyectoActivos()
        {
            return from c in ExpertosAsignados ?? new List<ExpertoEnProyecto>()
                   where c.Activo
                   select c;
        }

        public void GuardarExpertos(IEnumerable<ExpertoEnProyecto> expertosEnProyecto)
        {
            if (ExpertosAsignados == null) ExpertosAsignados = new List<ExpertoEnProyecto>();

            ExpertosAsignados.Clear();
            //foreach (var item in ExpertosAsignados)
            //{
            //    if(!expertosEnProyecto.Any(x => x.ExpertoId == item.ExpertoId))
            //    {
            //        ExpertosAsignados.Remove(item);
            //    }
            //} 

            foreach (var item in (expertosEnProyecto.Except(ExpertosAsignados)))
	        {
                ExpertosAsignados.Add(item);
	        }
        }

        public void Publicar()
        {
            Estado = "Listo";
            switch (Tipo)
            {
                case "AHP": InicializarMatricesAHP(); break;
                case "IL": InicializarIL(); break;
                case "Ambos": InicializarMatricesAHP(); InicializarIL(); break;   
            }
        }

        private void InicializarMatricesAHP()
        {
            int dimensionCriterio = Criterios.Count;
            int dimensionAlternativa = Alternativas.Count;

            double[,] matrizCriterio = new double[dimensionCriterio, dimensionCriterio];
            double[,] matrizAlternativa = new double[dimensionAlternativa, dimensionAlternativa];

            foreach (ExpertoEnProyecto expertoEnProyecto in ExpertosAsignados)
            {
                expertoEnProyecto.ValoracionAHP = new ValoracionAHP();
                expertoEnProyecto.ValoracionAHP.CriterioMatriz = new CriterioMatriz() { ExpertoEnProyecto = expertoEnProyecto, Matriz = matrizCriterio, Consistencia = false };

                expertoEnProyecto.ValoracionAHP.AlternativasMatrices = new List<AlternativaMatriz>();
                foreach (Criterio criterio in Criterios)
                {
                    expertoEnProyecto.ValoracionAHP.AlternativasMatrices.Add(new AlternativaMatriz()
                    {
                        ExpertoEnProyecto = expertoEnProyecto,
                        Criterio = criterio,
                        Matriz = matrizAlternativa,
                        Consistencia = false
                    });
                }
            }
        }

        public void InicializarIL()
        {
            foreach (var expertoEnProyecto in ExpertosAsignados)
            {
                expertoEnProyecto.ValoracionIL.AlternativasIL = new List<AlternativaIL>();

                foreach (Alternativa Alternativa in Alternativas)
                {
                    AlternativaIL alternativaIl = new AlternativaIL()
                    {
                        Nombre = Alternativa.Nombre,
                        Descripcion = Alternativa.Descripcion
                    };
                    expertoEnProyecto.ValoracionIL.AlternativasIL.Add(alternativaIl);

                    alternativaIl.ValorCriterios = new List<ValorCriterio>(
                        from c in Criterios
                        select new ValorCriterio
                        {
                            Nombre = c.Nombre,
                            Descripcion = c.Descripcion,
                            ValorILNumerico = (expertoEnProyecto.ValoracionIL.ConjuntoEtiquetas.Etiquetas.Count - 1) / 2,
                            ValorILLinguistico = expertoEnProyecto.ValoracionIL.ConjuntoEtiquetas
                                    .Etiquetas.ElementAt((expertoEnProyecto.ValoracionIL.ConjuntoEtiquetas.Etiquetas.Count - 1) / 2).Nombre // []
                        }
                    );
                }
            }
        }

        public string RequerimientoParaPublicar()
        {
            var cantidadAlternativas = Alternativas.Count;
            var cantidadCriterios = Criterios.Count;
            var cantidadExpertos = ExpertosAsignados.Count;
            var todosConConjuntoEtiquetas = (from c in ExpertosAsignados
                                             select c).All(x => x.ValoracionIL != null
                                                    && x.ValoracionIL.ConjuntoEtiquetas != null);

            var mensaje = "";
            
            if(cantidadExpertos == 0)
            {
                mensaje += "\n- Agregar al menos un experto.";
            }
            if (Tipo == "AHP")
            {
                if (cantidadAlternativas < 3)
                {
                    mensaje += "\n- Agregar al menos " + (3 - cantidadAlternativas) + " alternativas.";
                }
                if (cantidadCriterios < 3)
                {
                    mensaje += "\n- Agregar al menos " + (3 - cantidadCriterios) + " criterios.";
                }
            }
            else
            if (Tipo == "IL")
            {
                if (!todosConConjuntoEtiquetas)
                    mensaje += "\n- Todos los expertos deben tener un conjunto de etiquetas asignado.";

                if (cantidadAlternativas < 2)
                {
                    mensaje += "\n- Agregar al menos " + (2 - cantidadAlternativas) + " alternativas.";
                }
                if (cantidadCriterios < 1)
                {
                    mensaje += "\n- Agregar al menos " + (1 - cantidadCriterios) + " criterios.";
                }
            }
            else
            if (Tipo == "Ambos")
            {
                if (!todosConConjuntoEtiquetas)
                    mensaje += "\n- Todos los expertos deben tener un conjunto de etiquetas asignado.";

                if (cantidadAlternativas < 3)
                {
                    mensaje += "\n- Agregar al menos " + (3 - cantidadAlternativas) + " alternativas.";
                }
                if (cantidadCriterios < 3)
                {
                    mensaje += "\n- Agregar al menos " + (3 - cantidadCriterios) + " criterios.";
                }
            }
            
            if (mensaje.Length > 0)
                return "Si desea publicar el proyecto debe:" + mensaje;
            else
                return "El proyecto está en condiciones de publicarse.";
        }

        public bool PosiblePublicar()
        {
            var cantidadAlternativas = Alternativas.Count;
            var cantidadCriterios = Criterios.Count;
            var cantidadExpertos = ExpertosAsignados.Count;
            var todosConConjuntoEtiquetas = (from c in ExpertosAsignados
                                             select c).All(x => x.ValoracionIL != null
                                                    && x.ValoracionIL.ConjuntoEtiquetas != null);
            switch (Tipo)
            {
                case "AHP": 
                    {
                        return cantidadAlternativas > 2 && cantidadCriterios > 2 && cantidadExpertos > 0;
                    }
                case "IL":
                    {
                        return cantidadAlternativas > 1 && cantidadCriterios > 0 && cantidadExpertos > 0 && todosConConjuntoEtiquetas;
                    }
                case "Ambos":
                    {
                        return cantidadAlternativas > 2 && cantidadCriterios > 2 && cantidadExpertos > 0 && todosConConjuntoEtiquetas;
                    }
                default: return false;
            }
        }

        public bool TodosLosExpertosPonderados()
        {
            return ExpertosAsignados.Any(x => x.Activo && x.Peso != 0);
        }

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyectoConsistenteAHP()
        {
            IEnumerable<ExpertoEnProyecto> lista = from p in ExpertosAsignados
                                                   where p.Activo && p.ValoracionAHP.TodasMisValoracionesConsistentes()
                                                   select p;
             
           PonderarExpertos(lista);
            return lista;
        }

        public void PonderarExpertos(IEnumerable<ExpertoEnProyecto> lista)
        {             
            Int32 denominador = 0;
            foreach (ExpertoEnProyecto expertoEnProyecto in lista)
            {
                denominador += Convert.ToInt32(expertoEnProyecto.Peso);
            }

            foreach (ExpertoEnProyecto expertoEnProyecto in lista)
            {
                expertoEnProyecto.Ponderacion = (double)expertoEnProyecto.Peso / denominador;
            }
        }

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyectoConsistenteIL()
        {
            //IEnumerable<ExpertoEnProyecto> lista = from p in ExpertosAsignados
            //                                       where p.ValoracionIL.valorada()
            //                                       select p;

            IEnumerable<ExpertoEnProyecto> lista = ExpertosAsignados;
           
            PonderarExpertos(lista);

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
                if (expertoEnProyecto.ValoracionAHP.TodasMisValoracionesConsistentes())
                {
                    utils.Productoria(matrizCriterio, expertoEnProyecto.ValoracionAHP.CriterioMatriz.Matriz);

                    k = 0;
                    foreach (AlternativaMatriz d in expertoEnProyecto.ValoracionAHP.AlternativasMatrices)
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
            foreach (ExpertoEnProyecto d in ObtenerExpertosProyectoConsistenteAHP())
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
        public double[,] CalcularRankingIL(bool ConPeso)
        {

            var utils = new Utils();

            int dimension = Alternativas.Count;
            var rankAgregado = new double[dimension, 1];

            utils.Cerar(rankAgregado, 1);

            Utils util = new Utils();

            ValoracionIL resultado = util.ObtenerEstructuraRdo(ExpertosAsignados.First().ValoracionIL, ConPeso);
            
            int k = 0;

            int cardinalidadCEN = ObtenerCardinalidadCEN();

            foreach (var exp in ObtenerExpertosProyectoConsistenteIL())
            {
                if (ConPeso)
                {
                    exp.CalcularMiRankingIL(resultado, cardinalidadCEN, true);
                }
                else
                {
                    exp.CalcularMiRankingIL(resultado, cardinalidadCEN, false);
                }

                k++;
            }

            if (!ConPeso)
            {
                util.AgregacionMediaGeometricaKExpertos(resultado, ExpertosAsignados.Count);
            }


            utils.AgregacionCriterios(resultado, rankAgregado);

            return utils.NormalizarIlFinal((rankAgregado));
        }

        public ValoracionIL CalcularTuplasExperto(ExpertoEnProyecto expertoEnProyecto, bool ConPeso)
        {
            var utils = new Utils();

            int dimension = Alternativas.Count;
            var rankAgregado = new double[dimension, 1];

            utils.Cerar(rankAgregado, 1);

            Utils util = new Utils();

            ValoracionIL resultado = util.ObtenerEstructuraRdoTuplas(ExpertosAsignados.First().ValoracionIL, ConPeso);

            int k = 0;

            int cardinalidadCEN = ObtenerCardinalidadCEN();

            foreach (var exp in ObtenerExpertosProyectoConsistenteIL())
            {
                if (ConPeso)
                {
                    exp.CalcularMiRankingIL(resultado, cardinalidadCEN, true);
                }
                else
                {
                    exp.CalcularMiRankingIL(resultado, cardinalidadCEN, false);
                }

                k++;
            }

            if (!ConPeso)
            {
                util.AgregacionMediaGeometricaKExpertos(resultado, ExpertosAsignados.Count);
            }

            int cardinalidadEtiquetasExperto = expertoEnProyecto.ValoracionIL.ConjuntoEtiquetas.Cantidad - 1;

            foreach (var item in resultado.AlternativasIL)
            {
                foreach (var cri in item.ValorCriterios)
                {
                    cri.ValorILNumerico = util.VirtualAPersonal(cri.ValorILNumerico, cardinalidadCEN, cardinalidadEtiquetasExperto);
                }
            }


            foreach (var item in resultado.AlternativasIL)
            {
                foreach (var cri in item.ValorCriterios)
                {
                    cri.ValorILNumerico = util.VirtualAPersonal(cri.ValorILNumerico, cardinalidadCEN, cardinalidadEtiquetasExperto);
                    var valorCriterio = cri.ValorILNumerico;
                    int redondeoCriterio = (int)Math.Round(valorCriterio, 0);

                    foreach (var etiqueta in expertoEnProyecto.ValoracionIL.ConjuntoEtiquetas.Etiquetas)
                    {
                        if (etiqueta.Indice == redondeoCriterio)
                        {
                            cri.ValorILLinguistico = etiqueta.Nombre;
                            cri.ValorILNumerico = cri.ValorILNumerico - (double)redondeoCriterio;
                        }
                    }
                }
            }

            return resultado;

            //utils.AgregacionCriterios(resultado, rankAgregado);

            //return rankAgregado;
        }

        //Calcula y devuelve el mínimo común múltiplo de los conjuntos de etiquetas.
        public int ObtenerCardinalidadCEN()
        {
            Utils util = new Utils();
            List<int> lista = new List<int>();

            foreach (var exp in ExpertosAsignados)
            {
                lista.Add(exp.ValoracionIL.ConjuntoEtiquetas.Cantidad - 1);
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
                listaCardinalidadEtiquetasK.Add(expertoEnProyecto.ValoracionIL.ConjuntoEtiquetas.Cantidad-1);
            }
            Int32 cardinalidadCEN = utils.Mcm(listaCardinalidadEtiquetasK.ToArray());
            return cardinalidadCEN;
        }

        #region Implementation of ICloneable

        public object Clone()
        {
            var alternativas = (from c in Alternativas
                                select c.Clone() as Alternativa);

            var criterios = (from c in Criterios
                             select c.Clone() as Criterio);

            var proyecto = new Proyecto
                               {
                                   Tipo = Tipo,
                                   Estado = Estado,
                                   Creador = Creador,
                                   ProyectoClonadoId = ProyectoId,
                                   Alternativas = alternativas.ToList(),
                                   //ConjuntosDeEtiquetas = ConjuntosDeEtiquetas,
                                   Criterios = criterios.ToList(),
                                   ExpertosAsignados = new List<ExpertoEnProyecto>()
                               };

            foreach (var expertoEnProyecto in ExpertosAsignados)
            {
                var nuevoExpertoEnProyecto = expertoEnProyecto.Clone() as ExpertoEnProyecto;

                nuevoExpertoEnProyecto.Proyecto = proyecto;
                proyecto.ExpertosAsignados.Add(nuevoExpertoEnProyecto);
                
                if (expertoEnProyecto.ValoracionAHP != null)
                {
                    int dimensionCriterios = expertoEnProyecto.ValoracionAHP.CriterioMatriz.Matriz.GetLength(0);

                    nuevoExpertoEnProyecto.ValoracionAHP.CriterioMatriz =
                        new CriterioMatriz
                            {
                                ExpertoEnProyecto = nuevoExpertoEnProyecto,
                                Matriz = new double[dimensionCriterios,dimensionCriterios]
                            };
                    
                    foreach (var alternativaMatriz in expertoEnProyecto.ValoracionAHP.AlternativasMatrices)
                    {
                        var alternativa = new AlternativaMatriz
                                              {
                                                  ExpertoEnProyecto = nuevoExpertoEnProyecto,
                                                  Criterio =
                                                      nuevoExpertoEnProyecto.Proyecto.
                                                      Criterios.First(
                                                          x =>
                                                          x.Nombre == alternativaMatriz.Criterio.Nombre),
                                                  Consistencia = alternativaMatriz.Consistencia,
                                                  Matriz = alternativaMatriz.Matriz
                                              };
                        nuevoExpertoEnProyecto.ValoracionAHP.AlternativasMatrices.Add(alternativa);
                    }
                }

                if(expertoEnProyecto.ValoracionIL != null)
                {
                    //TODO: código del código de IL necesario para la clonación
                }
            }

            return proyecto;
        }

        #endregion
    }
}