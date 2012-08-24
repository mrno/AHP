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
            if (valor == 0)//corresponde a 1/9
                return "es Extremadamente menos importante que";
            if (valor == 1)//corresponde a 1/8
                return "";
            if (valor == 2)//corresponde a 1/7
                return "es bastante menos importante que";
            if (valor == 3)//corresponde a 1/6
                return "";
            if (valor == 4)//corresponde a 1/5
                return "es Meadianamente Importante comparado con";
            if (valor == 5)//corresponde a 1/4
                return "";
            if (valor == 6)//corresponde a 1/3
                return "es levemente menos importante que";
            if (valor == 7)//corresponde a 1/2
                return "";
            if (valor == 8)//corresponde a 1
                return "es Igual de importante que";
            if (valor == 9)//corresponde a 2
                return "";
            if (valor == 10)//corresponde a 3
                return "es levemente mas importante que";
            if (valor == 11)//corresponde a 4
                return "";
            if (valor == 12)//corresponde a 5
                return "es medianamente mas importante que";
            if (valor == 13)//corresponde a 6
                return "";
            if (valor == 14)//corresponde a 7
                return "es Extremadamente mas importante que";
            if (valor == 15)//corresponde a 8
                return "";
            if (valor == 16)//corresponde a 9
                return "es Extremadamente mas importante";
     
            return "";
        }
    }
}
