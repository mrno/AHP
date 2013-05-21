using System.Collections.Generic;
using System.Linq;
using sisExperto.Entidades;

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
    }
}