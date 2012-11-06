using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisexperto.Entidades;

namespace sisexperto.Fachadas
{
    public class FachadaEjecucionProyecto
    {
        private DALDatos datos = new DALDatos();
        private GisiaExpertoContext _context = new GisiaExpertoContext();

        public experto Proyecto { get; set; }


        //ASI SERIA EL NUEVO
        //Esto accede a la nueva DB
        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyecto(Proyecto _proyecto)
        {
            return _proyecto.ExpertosAsignados;
        }

        //Esto accede a la vieja DB
        public List<experto_proyecto> ObtenerExpertosProyecto(proyecto _proyecto)
        {
            return datos.expertosPorProyecto2(_proyecto.id_proyecto);
        }

        public void GuardarCambios(List<experto_proyecto> _expertosConPonderacion)
        {
            throw new NotImplementedException();
        }

        public bool PosibleEjecutarAHP()
        {
            return true;
        }
    }
}
