
using System.Collections.Generic;

using sisexperto;
using sisexperto.Entidades;

namespace sisExperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private GisiaExpertoContext _context = new GisiaExpertoContext();
        private FachadaProyectosExpertos _fachadaProyectosExpertos = new FachadaProyectosExpertos();
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


      

        public IEnumerable<ExpertoEnProyecto> ExpertoProyectoConsistentes(Proyecto _proyecto)
        {
            return null;
        }
    }
}
