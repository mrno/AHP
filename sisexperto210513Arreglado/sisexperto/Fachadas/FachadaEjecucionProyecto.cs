using System.Collections.Generic;
using System.Linq;
using probaAHP;
using sisExperto.Entidades;
using sisexperto.Entidades.IL;

namespace sisExperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private readonly GisiaExpertoContext _context = GisiaExpertoContext.Instance;

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyecto(Proyecto _proyecto)
        {
            return _proyecto.ExpertosAsignados;
        }

        public bool PosibleEjecutarAHP()
        {
            return true;
        }

        public void GuardarPesosExpertosEnProyecto(Proyecto _proyecto, List<ExpertoEnProyecto> _ExpertosConPonderacion)
        {
            foreach (ExpertoEnProyecto item in _ExpertosConPonderacion)
            {
                ExpertoEnProyecto expEnProyecto = (from ex in _context.ExpertosEnProyectos
                                                   where
                                                       ex.Proyecto.ProyectoId == _proyecto.ProyectoId &&
                                                       ex.Experto.ExpertoId == item.Experto.ExpertoId
                                                   select ex).FirstOrDefault();
                if (expEnProyecto == null)
                    _proyecto.ExpertosAsignados.Add(item);
                else
                {
                    expEnProyecto.Peso = item.Peso;
                }
            }
            _context.SaveChanges();
        }
        
        internal double[,] CalcularRankingAHP(ExpertoEnProyecto expertoEnProyecto)
        {
            using (var context = new GisiaExpertoContext())
            {
                var expertoEnProy = context.ExpertosEnProyectos
                    .First(x => x.ExpertoEnProyectoId == expertoEnProyecto.ExpertoEnProyectoId);
                return expertoEnProy.CalcularMiRankingAHP();
            }
        }

        internal double[,] CalcularRankingAHP(Proyecto proyecto, int tipoAgregacion)
        {
            using (var context = new GisiaExpertoContext())
            {
                var _proyecto = context.Proyectos.First(x => x.ProyectoId == proyecto.ProyectoId);

                switch (tipoAgregacion)
                {
                    case 1:
                        return _proyecto.CalcularRankingAHPNoPonderado();
                    case 2:
                        return _proyecto.CalcularRankinAHPPonderado();
                    default:
                        return new double[_proyecto.Alternativas.Count, 1];
                }
            }
        }

        public double[,] CalcularRankingIL(ExpertoEnProyecto expertoEnProyecto)
        {
            using (var context = new GisiaExpertoContext())
            {
                var _expertoEnProyecto = context.ExpertosEnProyectos
                    .First(x => x.ExpertoEnProyectoId == expertoEnProyecto.ExpertoEnProyectoId);

                var util = new Utils();
                var dimension = _expertoEnProyecto.Proyecto.Alternativas.Count;
                var rankingFinal = new double[dimension,1];
                util.Cerar(rankingFinal, 1);

                double acumulador;
                double promedio;

                int posicion = 0;

                foreach (AlternativaIL alt in _expertoEnProyecto.ValoracionIL.AlternativasIL)
                {

                    //para obtener el vector de pesos en IL, quedo obsoleto 
                    //util.MultiplicarWCriterios(alt.ValorCriterios);
                    promedio = 0;
                    acumulador = 0;
                    foreach (var cri in alt.ValorCriterios)
                    {
                        acumulador += cri.ValorILNumerico;
                    }
                    promedio = acumulador/alt.ValorCriterios.Count;
                    rankingFinal[posicion, 0] = promedio;
                    posicion++;
                }
                util.NormalizarIlFinal(rankingFinal);

                return rankingFinal;
            }
        }
        
        internal double[,] CalcularRankingIL(Proyecto proyecto, int tipoAgregacion, double[,] vectorCriteriosAHP)
        {
            using (var context = new GisiaExpertoContext())
            {
                var _proyecto = context.Proyectos.First(x => x.ProyectoId == proyecto.ProyectoId);

                if (tipoAgregacion == 1)
                {
                    return _proyecto.CalcularRankingIL(false, vectorCriteriosAHP);
                }
                else
                {
                    return _proyecto.CalcularRankingIL(true, vectorCriteriosAHP);
                }
            }
        }

        internal double[,] CalcularRankingIL(Proyecto proyecto, int tipoAgregacion)
        {
            using (var context = new GisiaExpertoContext())
            {
                var _proyecto = context.Proyectos.First(x => x.ProyectoId == proyecto.ProyectoId);

                if (tipoAgregacion == 1)
                {
                    return _proyecto.CalcularRankingIL(false);
                }
                else
                {
                    return _proyecto.CalcularRankingIL(true);
                }
            }
        }

        internal double[,] CalcularRankingILTuplas(ExpertoEnProyecto expertoEnProyecto, bool ponderado)
        {
            using (var context = new GisiaExpertoContext())
            {
                var _proyecto = context.Proyectos
                    .First(x => x.ProyectoId == expertoEnProyecto.Proyecto.ProyectoId);

                return _proyecto.CalcularRankingILTuplas(expertoEnProyecto, ponderado);
            }
        }
    }
}