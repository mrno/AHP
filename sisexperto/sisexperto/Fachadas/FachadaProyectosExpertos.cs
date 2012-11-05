using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisexperto;
using sisexperto.Entidades;

namespace sisexperto
{    
    public class FachadaProyectosExpertos
    {
        private DALDatos datos = new DALDatos();

        //private GisiaExpertoContext _context = new GisiaExpertoContext();

        public experto experto { get; set; }

        public experto ValidarExperto(string usuario, string password)
        {
            //using (var asd = new GisiaExpertoContext()) { }
            return datos.validarExperto(usuario, password);
        }

        public IEnumerable<proyecto> SolicitarProyectos(experto e)
        {
            return datos.proyectosPorCreador(e.id_experto);
        }

        public IEnumerable<alternativa> SolicitarAlternativas(int proyecto)
        {
            try
            {
                return datos.alternativasPorProyecto(proyecto);
            }
            catch (Exception)
            {
                return new List<alternativa>();
            }
            
        }

        public IEnumerable<criterio> SolicitarCriterios(int proyecto)
        {
            try
            {
                return datos.criteriosPorProyecto(proyecto);
            }
            catch (Exception)
            {
                return new List<criterio>();
            }

        }

        public proyecto AltaProyecto(proyecto proyecto)
        {
            return datos.altaProyecto(proyecto.id_creador, proyecto.nombre, proyecto.objetivo);
        }

        public experto AltaExperto(experto experto)
        {
            return datos.altaExperto(experto.nombre, experto.apellido, experto.nom_usuario, experto.clave);
        }

        public bool ExisteExperto(string NombreUsuario)
        {
            return datos.ExisteUsuario(NombreUsuario);
        }

        public void AsignarProyecto(proyecto proyecto, experto experto)
        {
            datos.asignarProyecto(proyecto.id_proyecto, experto.id_experto);
        }

        public IEnumerable<experto> ObtenerExpertos()
        {
            return datos.todosExpertos();
        }

        public void AsignarExpertosAlProyecto(proyecto Proyecto, IEnumerable<experto> Expertos)
        {
            foreach (experto experto in Expertos)
            {
                AsignarProyecto(Proyecto, experto);
            }
        }

        public IEnumerable<experto> ExpertosAsignados(proyecto Proyecto)
        {
            try
            {
                return datos.expertosPorProyecto(Proyecto.id_proyecto);
            }
            catch (Exception)
            {

                return new List<experto>();
            }
            
        }
    }
}
