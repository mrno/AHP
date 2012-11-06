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

        public bool PosibleEjecutarAHP()
        {
            return true;
        }

        public void GuardarPonderaciones(Entidades.Proyecto _proyecto, List<ExpertoEnProyecto> _ExpertosConPonderacion)
        {
            foreach (var item in _ExpertosConPonderacion)
            {
                var expEnProyecto = (from ex in _context.ExpertosEnProyectos
                                     where ex.Proyecto == _proyecto && ex.Experto == item.Experto
                                     select ex).FirstOrDefault();
                if (expEnProyecto == null)
                    _proyecto.ExpertosAsignados.Add(item);
                else expEnProyecto.Ponderacion = item.Ponderacion;
            }
            _context.SaveChanges();
        }
    }
}
