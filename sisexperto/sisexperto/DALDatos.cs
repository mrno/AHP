using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
    class DALDatos
    {
        private gisiabaseEntities gisiaContexto;

        public List<alternativa> todasAlternativas()
        {
            gisiaContexto = new gisiabaseEntities();
            List<alternativa> lista = (from a in gisiaContexto.alternativa select a).ToList<alternativa>();
            gisiaContexto.Dispose();
            return lista;
        }

        public List<experto> todosExpertos()
        {
            gisiaContexto = new gisiabaseEntities();
            List<experto> lista = (from e in gisiaContexto.experto select e).ToList<experto>();
            gisiaContexto.Dispose();
            return lista;
        }

        public List<criterio> todosCriterios()
        {
            gisiaContexto = new gisiabaseEntities();
            List<criterio> lista = (from c in gisiaContexto.criterio select c).ToList<criterio>();
            gisiaContexto.Dispose();
            return lista;
        }

        public void altaAlternativa(int id_proyecto, string nombre, string descripcion)
        {
            gisiaContexto = new gisiabaseEntities();
            alternativa miAlternativa = new alternativa();
            miAlternativa.nombre = nombre;
            miAlternativa.descripcion = descripcion;
            miAlternativa.id_proyecto = id_proyecto;
            gisiaContexto.AddToalternativa(miAlternativa);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void altaProyecto(string nombre, string objetivo)
        {
            gisiaContexto = new gisiabaseEntities();
            proyecto miProyecto = new proyecto();
            miProyecto.nombre = nombre;
            miProyecto.objetivo = objetivo;
            gisiaContexto.AddToproyecto(miProyecto);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public int ultimoProyecto()
        {
            gisiaContexto = new gisiabaseEntities();
            List<proyecto> lista = (from p in gisiaContexto.proyecto select p).ToList<proyecto>();
            gisiaContexto.Dispose();
            int id;
            id = lista.AsQueryable().Last<proyecto>().id_proyecto;
            return id;
        }

        public int ultimoExperto()
        {
            gisiaContexto = new gisiabaseEntities();
            List<experto> lista = (from e in gisiaContexto.experto select e).ToList<experto>();
            gisiaContexto.Dispose();
            int id;
            id = lista.AsQueryable().Last<experto>().id_experto;
            return id;
        }

        public void altaExperto(string nombre, string apellido, string usuario, string clave)
        {
            gisiaContexto = new gisiabaseEntities();
            experto miExperto = new experto();
            miExperto.nombre = nombre;
            miExperto.apellido = apellido;
            miExperto.nom_usuario = usuario;
            miExperto.clave = clave;
            gisiaContexto.AddToexperto(miExperto);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void altaCriterio(int id_proyecto, string nombre, string descripcion)
        {
            gisiaContexto = new gisiabaseEntities();
            criterio miCriterio = new criterio();
            miCriterio.id_proyecto = id_proyecto;
            miCriterio.nombre = nombre;
            miCriterio.descripcion = descripcion;
            gisiaContexto.AddTocriterio(miCriterio);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void asignarProyecto(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities();
            experto_proyecto asignacion = new experto_proyecto();
            asignacion.id_proyecto = id_proyecto;
            asignacion.id_experto = id_experto;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public Queue<criterio> colaCriterios()
        {
            gisiaContexto = new gisiabaseEntities();
            List<criterio> lista = (from c in gisiaContexto.criterio select c).ToList<criterio>();
            Queue<criterio> cola = new Queue<criterio>();
            foreach(criterio c in lista)
            {
                cola.Enqueue(c);
                
            }
            gisiaContexto.Dispose();
            return cola;
        }

        public string valorarPalabra(int valor)
        {
            if (valor == 0)
                return "es Extremadamente Importante comparado con";
            if (valor == 1)
                return "es Muy Importante comparado con";
            if (valor == 2)
                return "es Importante comparado con";
            if (valor == 3)
                return "es Moderadamente Importante comparado con";
            if (valor == 4)
                return "es Meadianamente Importante comparado con";
            if (valor == 5)
                return "es Igual comparado con";
            if (valor == 6)
                return "es Medianamente Menos Importante comparado con";
            if (valor == 7)
                return "es Moderadamente Menos Importante comparado con";
            if (valor == 8)
                return "es Poco Importate comparado con";
            if (valor == 9)
                return "es Muy Poco Importante comparado con";
            if (valor == 10)
                return "es Extremadamente Menos Importante comparado con";
            return "";
        }
    }
}
