using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisExperto.Entidades;

namespace sisExperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private GisiaExpertoContext _context = new GisiaExpertoContext();

        public Experto Proyecto { get; set; }

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyecto(Proyecto _proyecto)
        {
            return _proyecto.ExpertosAsignados;
        }

        public void GuardarCambios(List<ExpertoEnProyecto> _ExpertosConPonderacion)
        {
            foreach (var Experto in _ExpertosConPonderacion)
            {
                
            }
        }

        public bool PosibleEjecutarAHP()
        {
            return true;
        }
    }
}
