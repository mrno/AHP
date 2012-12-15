using System.Collections.Generic;
using System.Linq;
using sisExperto.Entidades;

namespace sisExperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private readonly GisiaExpertoContext _context = new GisiaExpertoContext();

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
                                                       ex.ProyectoId == _proyecto.ProyectoId &&
                                                       ex.ExpertoId == item.Experto.ExpertoId
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

        internal double[,] CalcularRankingAHP(Proyecto _proyecto, int tipoAgregacion)
        {
            switch (tipoAgregacion)
            {
                case 1:
                    return _proyecto.CalcularRankingAHPNoPonderado();
                case 2:
                    return _proyecto.CalcularRankinAHPPonderado();
                default:
                    return new double[_proyecto.Alternativas.Count,1];
            }
        }

        internal double[,] CalcularRankingIL(Proyecto _proyecto, int tipoAgregacion)
        {
            switch (tipoAgregacion)
            {
                case 1:
                    return _proyecto.CalcularRankingILNoPonderado();
                case 2:
                    //return _proyecto.CalcularRankinAHPPonderado();
                default:
                    return new double[_proyecto.Alternativas.Count, 1];
            }
        }
    }
}