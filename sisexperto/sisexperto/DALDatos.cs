using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sisexperto
{
    class DALDatos
    {
        private gisiabaseEntities2 gisiaContexto;

        public List<alternativa> todasAlternativas()
        {
            gisiaContexto = new gisiabaseEntities2();
            List<alternativa> lista = (from a in gisiaContexto.alternativa select a).ToList<alternativa>();
            gisiaContexto.Dispose();
            return lista;
        }
       
        public List<criterio> criteriosPorProyecto(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<criterio> lista = (from c in gisiaContexto.criterio
                                    where c.id_proyecto == id_proyecto
                                    select c).ToList<criterio>();
            gisiaContexto.Dispose();
            return lista;
        }

        public bool existeCriterios(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            var flag = (from c in gisiaContexto.criterio
                                    where c.id_proyecto == id_proyecto
                                    select c).ToList<criterio>().Any();
            gisiaContexto.Dispose();
            return flag;
        }
        
        public bool existeAlternativas(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            var flag = (from c in gisiaContexto.criterio
                                    where c.id_proyecto == id_proyecto
                                    select c).ToList<criterio>().Any();
            gisiaContexto.Dispose();
            return flag;
        }

        public bool agregaPonderado(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            var flag  = (from ep in gisiaContexto.experto_proyecto
                         where ep.id_proyecto == id_proyecto && ep.ponderacion != 0
                         select ep).Any();
                        return flag;
        }

        public List<alternativa> alternativasPorProyecto(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<alternativa> lista = (from a in gisiaContexto.alternativa
                                       where a.id_proyecto == id_proyecto
                                       select a).ToList<alternativa>();
            gisiaContexto.Dispose();
            return lista;
        }

        public List<comparacion_alternativa> compAlternativaPorExpertoCriterio(int id_proyecto, int id_experto, int id_criterio)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<comparacion_alternativa> lista = (from c in gisiaContexto.comparacion_alternativa
                                                   where (c.id_proyecto == id_proyecto && c.id_experto == id_experto && c.id_criterio == id_criterio)
                                                   select c).ToList<comparacion_alternativa>();
            gisiaContexto.Dispose();
            return lista;
        }

        public List<experto> todosExpertos()
        {
            gisiaContexto = new gisiabaseEntities2();
            List<experto> lista = (from e in gisiaContexto.experto select e).ToList<experto>();
            gisiaContexto.Dispose();
            return lista;
        }

        public List<criterio> todosCriterios()
        {
            gisiaContexto = new gisiabaseEntities2();
            List<criterio> lista = (from c in gisiaContexto.criterio select c).ToList<criterio>();
            gisiaContexto.Dispose();
            return lista;
        }

        public string criterioNombre(int id_criterio)
        {
            gisiaContexto = new gisiabaseEntities2();
            criterio cri = (from c in gisiaContexto.criterio
                            where c.id_criterio == id_criterio
                            select c).FirstOrDefault<criterio>();
            gisiaContexto.Dispose();
            return cri.nombre.ToString();
        }

        public string alternativaNombre(int id_alternativa)
        {
            gisiaContexto = new gisiabaseEntities2();
            alternativa alt = (from a in gisiaContexto.alternativa
                            where a.id_alternativa == id_alternativa
                            select a).FirstOrDefault<alternativa>();
            gisiaContexto.Dispose();
            return alt.nombre.ToString();
        }

        public bool logExperto(string usuario, string password)
        {
            bool respuesta = false;
            gisiaContexto = new gisiabaseEntities2();
            foreach (experto exp in gisiaContexto.experto)
            {
                if(exp.nom_usuario == usuario && exp.clave == password)
                    respuesta = true;
            }
            return respuesta;
        }

        public experto validarExperto(string usuario, string password)
        {
            experto respuesta = new experto();
            gisiaContexto = new gisiabaseEntities2();
            foreach (experto exp in gisiaContexto.experto)
            {
                if (exp.nom_usuario == usuario && exp.clave == password)
                    respuesta = exp;
            }
            return respuesta;
        }

        public experto buscarExperto(int id_experto)
        {
            experto respuesta = new experto();
            gisiaContexto = new gisiabaseEntities2();
            foreach (experto exp in gisiaContexto.experto)
            {
                if (exp.id_experto == id_experto)
                    respuesta = exp;
            }
            return respuesta;
        }

        public List<proyecto> proyectosExperto(int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<experto_proyecto> listaExpp = (from expp in gisiaContexto.experto_proyecto
                                    where expp.id_experto == id_experto
                                    select expp).ToList<experto_proyecto>();
            List<proyecto> listaProyectos = new List<proyecto>();
            foreach (experto_proyecto expp in listaExpp)
            {
               proyecto proy = (from p in gisiaContexto.proyecto where p.id_proyecto == expp.id_proyecto select p).FirstOrDefault<proyecto>();
               listaProyectos.Add(proy);
            }
            return listaProyectos;
        }

        public List<comparacion_criterio> comparacionCriterioPorExperto(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<comparacion_criterio> lista = (from c in gisiaContexto.comparacion_criterio
                                                where (c.id_proyecto == id_proyecto && c.id_experto == id_experto)
                                                select c).ToList<comparacion_criterio>();
            gisiaContexto.Dispose();
            return lista;
        }

        public List<comparacion_alternativa> comparacionAlternativaPorExperto(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<comparacion_alternativa> lista = (from c in gisiaContexto.comparacion_alternativa
                                                where (c.id_proyecto == id_proyecto && c.id_experto == id_experto)
                                                select c).ToList<comparacion_alternativa>();
            gisiaContexto.Dispose();
            return lista;
        }

        public void altaAlternativa(int id_proyecto, string nombre, string descripcion)
        {
            gisiaContexto = new gisiabaseEntities2();
            alternativa miAlternativa = new alternativa();
            miAlternativa.nombre = nombre;
            miAlternativa.descripcion = descripcion;
            miAlternativa.id_proyecto = id_proyecto;
            gisiaContexto.AddToalternativa(miAlternativa);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public proyecto altaProyecto(int id_creador, string nombre, string objetivo)
        {
            gisiaContexto = new gisiabaseEntities2();
            proyecto miProyecto = new proyecto();
            miProyecto.id_creador = id_creador;
            miProyecto.nombre = nombre;
            miProyecto.objetivo = objetivo;
            gisiaContexto.AddToproyecto(miProyecto);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
            return miProyecto;
        }

        public int ultimoProyecto()
        {
            gisiaContexto = new gisiabaseEntities2();
            List<proyecto> lista = (from p in gisiaContexto.proyecto select p).ToList<proyecto>();
            gisiaContexto.Dispose();
            int id;
            id = lista.AsQueryable().Last<proyecto>().id_proyecto;
            return id;
        }

        public List<proyecto> proyectosPorCreador(int id_creador)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<proyecto> lista = (from p in gisiaContexto.proyecto
                                    where p.id_creador == id_creador 
                                    select p).ToList<proyecto>();
            //foreach(proyecto proy in lista)
            //{
            //    List<comparacion_alternativa> listaAlt = (from a in gisiaContexto.comparacion_alternativa
            //                                              where a.id_proyecto == proy.id_proyecto
            //                                              select a).ToList<comparacion_alternativa>();
            //    if (listaAlt.Count != 0)
            //        lista.Remove(proy);
            //}
            gisiaContexto.Dispose();
            return lista;
        }

        public int ultimoExperto()
        {
            gisiaContexto = new gisiabaseEntities2();
            List<experto> lista = (from e in gisiaContexto.experto select e).ToList<experto>();
            gisiaContexto.Dispose();
            int id;
            id = lista.AsQueryable().Last<experto>().id_experto;
            return id;
        }

        public experto altaExperto(string nombre, string apellido, string usuario, string clave)
        {
            gisiaContexto = new gisiabaseEntities2();
            experto miExperto = new experto();
            miExperto.nombre = nombre;
            miExperto.apellido = apellido;
            miExperto.nom_usuario = usuario;
            miExperto.clave = clave;
            gisiaContexto.AddToexperto(miExperto);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
            return miExperto;
            
        }

        public List<experto> expertosPorProyecto(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            var lista = (from ep in gisiaContexto.experto_proyecto
                         where ep.id_proyecto == id_proyecto
                         select ep);
            List<experto> listaExpertos = (from e in gisiaContexto.experto
                                           join ep in lista on e.id_experto equals ep.id_experto
                                           select e).ToList<experto>();
            return listaExpertos;

        }

        public List<experto_proyecto> expertosPorProyecto2(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            var lista = (from ep in gisiaContexto.experto_proyecto
                         where ep.id_proyecto == id_proyecto
                         select ep).ToList<experto_proyecto>();

            return lista;

        }

        public List<experto> expeProyConsistente(int id_proy)
        {

            int cont;
            int consistetnes;

            gisiaContexto = new gisiabaseEntities2();
            List<experto> devolver = new List<experto>();
            List<experto> exp_proy = expertosPorProyecto(id_proy);

            foreach (experto expp in exp_proy)
            {
                consistetnes = 0;
                var listaContarMat = obtenerMatrizCriterio(id_proy, expp.id_experto);
                foreach (matriz_criterio m in listaContarMat)
                {
                    if (m.consistente.Value)
                        consistetnes++;
                }
                var listaContarAlt = obtenerMatrizAlternativa(id_proy, expp.id_experto);
                foreach (matriz_alternativa m in listaContarAlt)
                {
                    if (m.consistente.Value)
                        consistetnes++;
                }
                cont = listaContarAlt.Count + listaContarMat.Count;

                if (cont == consistetnes)
                {
                    experto miExperto = (from e in gisiaContexto.experto
                                         where e.id_experto == expp.id_experto
                                         select e).FirstOrDefault<experto>();

                    devolver.Add(miExperto);
                }
            }
            return devolver;
        }

        public List<experto_proyecto> expePorProyConsistente(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            var lista = (from ep in gisiaContexto.experto_proyecto
                         where ep.id_proyecto == id_proyecto && ep.valoracion_consistente == true
                         select ep).ToList<experto_proyecto>();
            return lista;

        }

        public void altaCriterio(int id_proyecto, string nombre, string descripcion)
        {
            gisiaContexto = new gisiabaseEntities2();
            criterio miCriterio = new criterio();
            miCriterio.id_proyecto = id_proyecto;
            miCriterio.nombre = nombre;
            miCriterio.descripcion = descripcion;
            miCriterio.ILPonderacion = 0;
            gisiaContexto.AddTocriterio(miCriterio);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void asignarProyecto(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();
            experto_proyecto asignacion = new experto_proyecto();
            asignacion.id_proyecto = id_proyecto;
            asignacion.id_experto = id_experto;
            asignacion.valoracion_consistente = false;
            asignacion.ILPonderacion = 0;
            gisiaContexto.AddToexperto_proyecto(asignacion);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void actualizarConsistenciaProyecto(int id_proyecto, int id_experto, bool consistencia)
        {
            gisiaContexto = new gisiabaseEntities2();

            experto_proyecto asignacion = (from exp_proy in gisiaContexto.experto_proyecto
                                           where exp_proy.id_proyecto == id_proyecto && exp_proy.id_experto == id_experto
                                           select exp_proy).FirstOrDefault<experto_proyecto>();
            
            asignacion.valoracion_consistente = consistencia;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public Queue<criterio> colaCriterios(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<criterio> lista = (from c in gisiaContexto.criterio 
                                    where c.id_proyecto == id_proyecto
                                    select c).ToList<criterio>();
            Queue<criterio> cola = new Queue<criterio>();
            foreach(criterio c in lista)
            {
                cola.Enqueue(c);
            }
            gisiaContexto.Dispose();
            return cola;
        }

        public Queue<alternativa> colaAlternativas(int id_proyecto)
        {
            gisiaContexto = new gisiabaseEntities2();
            List<alternativa> lista = (from a in gisiaContexto.alternativa
                                       where a.id_proyecto == id_proyecto
                                       select a).ToList<alternativa>();
            Queue<alternativa> cola = new Queue<alternativa>();
            foreach (alternativa a in lista)
            {
                cola.Enqueue(a);
            }
            gisiaContexto.Dispose();
            return cola;
            
        }

        public void guardarComparacionCriterios(int id_proyecto, int id_experto, int id_criterio1, int id_criterio2, int pos_fila, int pos_columna, float valor)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_criterio comp = new comparacion_criterio();
            comp.id_proyecto = id_proyecto;
            comp.id_experto = id_experto;
            comp.id_criterio1 = id_criterio1;
            comp.id_criterio2 = id_criterio2;
            comp.pos_fila = pos_fila;
            comp.pos_columna = pos_columna;
            comp.valor = valor;
            gisiaContexto.AddTocomparacion_criterio(comp);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
 
        }

        public void guardarComparacionAlternativas(int id_proyecto, int id_experto, int id_criterio, int id_alternativa1, int id_alternativa2, int pos_fila, int pos_columna, float valor)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_alternativa comp = new comparacion_alternativa();
            comp.id_proyecto = id_proyecto;
            comp.id_experto = id_experto;
            comp.id_criterio = id_criterio;
            comp.id_alternativa1 = id_alternativa1;
            comp.id_alternativa2 = id_alternativa2;
            comp.pos_fila = pos_fila;
            comp.pos_columna = pos_columna;
            comp.valor = valor;
            gisiaContexto.AddTocomparacion_alternativa(comp);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void modificarComparacionCriterios(int id_proyecto, int id_experto, int pos_fila, int pos_columna, float valor)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_criterio comp = (from c in gisiaContexto.comparacion_criterio
                                         where (c.id_proyecto == id_proyecto && c.id_experto == id_experto && c.pos_fila == pos_fila && c.pos_columna == pos_columna)
                                         select c).FirstOrDefault<comparacion_criterio>();
            comp.valor = valor;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void modificarComparacionAlternativa(int id_proyecto, int id_experto, int id_criterio, int pos_fila, int pos_columna, float valor)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_alternativa comp = (from c in gisiaContexto.comparacion_alternativa
                                         where (c.id_proyecto == id_proyecto 
                                                && c.id_experto == id_experto 
                                                && c.id_criterio == id_criterio
                                                && c.pos_fila == pos_fila 
                                                && c.pos_columna == pos_columna)
                                         select c).FirstOrDefault<comparacion_alternativa>();
            comp.valor = valor;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }
       
        public void modificarPonderacionExpertoProyectoAHP(int id_proyecto, int id_experto, int poderacion)
        {
            gisiaContexto = new gisiabaseEntities2();
            experto_proyecto comp = (from c in gisiaContexto.experto_proyecto
                                            where (c.id_proyecto == id_proyecto
                                                   && c.id_experto == id_experto)
                                                   
                                            select c).FirstOrDefault<experto_proyecto>();
            comp.ponderacion = poderacion;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void altaMatrizCriterio(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();
            matriz_criterio matriz = new matriz_criterio();
            matriz.id_proyecto = id_proyecto;
            matriz.id_experto = id_experto;
            gisiaContexto.AddTomatriz_criterio(matriz);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void altaMatrizAlternativa(int id_proyecto, int id_experto, int id_criterio)
        {
            gisiaContexto = new gisiabaseEntities2();
            matriz_alternativa matriz = new matriz_alternativa();
            matriz.id_proyecto = id_proyecto;
            matriz.id_experto = id_experto;
            matriz.id_criterio = id_criterio;
            gisiaContexto.AddTomatriz_alternativa(matriz);
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void actualizarMatrizCriterio(int id_proyecto, int id_experto, bool consistente)
        {
            gisiaContexto = new gisiabaseEntities2();

            matriz_criterio matriz = (from m in gisiaContexto.matriz_criterio
                                          where m.id_proyecto == id_proyecto && m.id_experto == id_experto
                                          select m).FirstOrDefault<matriz_criterio>();

            matriz.consistente = consistente;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }

        public void actualizarMatrizAlternativa(int id_proyecto, int id_experto, int id_criterio, bool consistente)
        {
            gisiaContexto = new gisiabaseEntities2();

            matriz_alternativa matriz = (from m in gisiaContexto.matriz_alternativa
                                         where m.id_proyecto == id_proyecto && m.id_experto == id_experto && m.id_criterio == id_criterio
                                         select m).FirstOrDefault<matriz_alternativa>();

            matriz.consistente = consistente;
            gisiaContexto.SaveChanges();
            gisiaContexto.Dispose();
        }
        
        public List<matriz_criterio> obtenerMatrizCriterio(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();

            List<matriz_criterio> matriz = (from m in gisiaContexto.matriz_criterio
                                            where m.id_proyecto == id_proyecto && m.id_experto == id_experto
                                            select m).ToList<matriz_criterio>();
            gisiaContexto.Dispose();
            return matriz;
        }

        public List<matriz_alternativa> obtenerMatrizAlternativa(int id_proyecto, int id_experto)
        {
            gisiaContexto = new gisiabaseEntities2();

            List<matriz_alternativa> listaMatriz = (from m in gisiaContexto.matriz_alternativa
                                                    where m.id_proyecto == id_proyecto && m.id_experto == id_experto
                                                    select m).ToList<matriz_alternativa>();
            gisiaContexto.Dispose();
            return listaMatriz;
        }
        
        public string valorarPalabra(int valor)
        {
            if (valor == 1)//corresponde a 9
                return "[9] es extremadamente más importante que ";
            if (valor == 2)//corresponde a 8
                return "[8] ";
            if (valor == 3)//corresponde a 7
                return "[7] es muy fuertemente más importante que ";
            if (valor == 4)//corresponde a 6
                return "[6] ";
            if (valor == 5)//corresponde a 5
                return "[5] es fuertemente más importante que ";
            if (valor == 6)//corresponde a 4
                return "[4] ";
            if (valor == 7)//corresponde a 3
                return "[3] es moderadamente más importante que ";
            if (valor == 8)//corresponde a 2
                return "[2] ";
            if (valor == 9)//corresponde a 1
                return "[1] es igual de importante que ";
            if (valor == 10)//corresponde a 1/2
                return "[1/2] ";
            if (valor == 11)//corresponde a 1/3
                return "[1/3]es moderadamente menos importante que ";
            if (valor == 12)//corresponde a 1/4
                return "[1/4] ";
            if (valor == 13)//corresponde a 1/5
                return "[1/5] es fuertemente menos importante que ";
            if (valor == 14)//corresponde a 1/6
                return "[1/6] ";
            if (valor == 15)//corresponde a 1/7
                return "[1/7] es muy fuertemente menos importante que ";
            if (valor == 16)//corresponde a 1/8
                return "[1/8] ";
            if (valor == 17)//corresponde a 1/9
                return "[1/9] es extremadamente menos importante que ";
     
            return "";
        }

        public float valorarNumero(int valor)
        {
            if (valor == 1)//corresponde a 1/9
                //return (float)1 / (float)9;
                return (float)9;
            if (valor == 2)//corresponde a 1/8
                //return (float)1 / (float)8;
                return (float)8;
            if (valor == 3)//corresponde a 1/7
                //return (float)1 / (float)7;
                return (float)7;
            if (valor == 4)//corresponde a 1/6
                //return (float)1 / (float)6;
                return (float)6;
            if (valor == 5)//corresponde a 1/5
                //return (float)1 / (float)5;
                return (float)5;
            if (valor == 6)//corresponde a 1/4
                //return (float)1 / (float)4;
                return (float)4;
            if (valor == 7)//corresponde a 1/3
                //return (float)1 / (float)3;
                return (float)3;
            if (valor == 8)//corresponde a 1/2
                //return (float)1 / (float)2;
                return (float)2;
            if (valor == 9)//corresponde a 1
                return 1;
            if (valor == 10)//corresponde a 2
                //return 2;
                return (float)1 / (float)2;
            if (valor == 11)//corresponde a 3
                //return 3;
                return (float)1 / (float)3;
            if (valor == 12)//corresponde a 4
                //return 4;
                return (float)1 / (float)4;
            if (valor == 13)//corresponde a 5
                //return 5;
                return (float)1 / (float)5;
            if (valor == 14)//corresponde a 6
                //return 6;
                return (float)1 / (float)6;
            if (valor == 15)//corresponde a 7
                //return 7;
                return (float)1 / (float)7;
            if (valor == 16)//corresponde a 8
                //return 8;
                return (float)1 / (float)8;
            if (valor == 17)//corresponde a 9
                //return 9;
                return (float)1 / (float)9;

            return 0;
        }

        public int valorarFlotante(float valor)
        {
            if( valor == (float)9)
                    return 1;

            if( valor == (float)8)
                    return 2;
                    
            if( valor == (float)7)
                    return 3;
                    
            if( valor == (float)6)
                    return 4;

            if( valor == (float)5)
                    return 5;
                   
            if( valor == (float)4)
                    return 6;
                    
            if( valor == (float)3)
                    return 7;
                   
            if( valor == (float)2)
                    return 8;

            if( valor == (float)1)
                    return 9;
                    
            if( valor == (float)1/(float)2)
                    return 10;
                    
            if( valor == (float)1 / (float)3)
                    return 11;
                    
            if( valor == (float)1 / (float)4)
                    return 12;
                    
            if( valor == (float)1 / (float)5)
                    return 13;
                    
            if( valor == (float)1 / (float)6)
                    return 14;
                    
            if( valor == (float)1 / (float)7)
                    return 15;
                    
            if( valor == (float)1 / (float)8)
                    return 16;
                    
            if( valor == (float)1 / (float)9)
                    return 17;
            
            return 9;
        }

        public string obtenerDescripcion(double valor)
        {
            if (valor == (float)1)
                return "[1] es igual de importante que ";

            if (valor == (float)2)
                return "[2] ";

            if (valor == (float)3)
                return "[3] es moderadamente más importante que ";

            if (valor == (float)4)
                return "[4] ";

            if (valor == (float)5)
                return "[5] es fuertemente más importante que ";

            if (valor == (float)6)
                return "[6] ";

            if (valor == (float)7)
                return "[7] es muy fuertemente más importante que ";

            if (valor == (float)8)
                return "[8] ";

            if (valor == (float)9)
                return "[9] es extremadamente más importante que ";

            if (valor == (float)1 / (float)2)
                return "[1/2] ";

            if (valor == (float)1 / (float)3)
                return "[1/3]es moderadamente menos importante que ";

            if (valor == (float)1 / (float)4)
                return "[1/4] ";

            if (valor == (float)1 / (float)5)
                return "[1/5] es fuertemente menos importante que ";

            if (valor == (float)1 / (float)6)
                return "[1/6] ";

            if (valor == (float)1 / (float)7)
                return "[1/7] es muy fuertemente menos importante que ";

            if (valor == (float)1 / (float)8)
                return "[1/8] ";

            if (valor == (float)1 / (float)9)
                return "[1/9] es extremadamente menos importante que ";

            return "";
        }

        public int obtenerEnteroCompAlternativa(int id_proyecto, int id_experto, int id_criterio, int pos_fila, int pos_columna)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_alternativa comp = (from c in gisiaContexto.comparacion_alternativa
                                            where (c.id_proyecto == id_proyecto
                                                   && c.id_experto == id_experto
                                                   && c.id_criterio == id_criterio
                                                   && c.pos_fila == pos_fila
                                                   && c.pos_columna == pos_columna)
                                            select c).FirstOrDefault<comparacion_alternativa>();

            return valorarFlotante((float)comp.valor);
        }
       
        public double obtenerValorCompAlternativa(int id_proyecto, int id_experto, int id_criterio, int pos_fila, int pos_columna)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_alternativa comp = (from c in gisiaContexto.comparacion_alternativa
                                            where (c.id_proyecto == id_proyecto
                                                   && c.id_experto == id_experto
                                                   && c.id_criterio == id_criterio
                                                   && c.pos_fila == pos_fila
                                                   && c.pos_columna == pos_columna)
                                            select c).FirstOrDefault<comparacion_alternativa>();

            return (float)comp.valor;
        }
        
        public double obtenerValorCompCriterio(int id_proyecto, int id_experto, int pos_fila, int pos_columna)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_criterio comp = (from c in gisiaContexto.comparacion_criterio
                                         where (c.id_proyecto == id_proyecto &&
                                                c.id_experto == id_experto &&
                                                c.pos_fila == pos_fila &&
                                                c.pos_columna == pos_columna)
                                         select c).FirstOrDefault<comparacion_criterio>();

            return (float)comp.valor;
        }
        
        public int obtenerEnteroCompCriterio(int id_proyecto, int id_experto, int pos_fila, int pos_columna)
        {
            gisiaContexto = new gisiabaseEntities2();
            comparacion_criterio comp = (from c in gisiaContexto.comparacion_criterio
                                         where (c.id_proyecto == id_proyecto && 
                                                c.id_experto == id_experto && 
                                                c.pos_fila == pos_fila && 
                                                c.pos_columna == pos_columna)
                                         select c).FirstOrDefault<comparacion_criterio>();

            return valorarFlotante((float)comp.valor);
        }

        public bool ExisteUsuario(string Usuario)
        {
            gisiaContexto = new gisiabaseEntities2();
            return 0 < (from c in gisiaContexto.experto
                         where c.nom_usuario == Usuario
                         select c).Count();
        }
    }
}
