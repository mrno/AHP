using System;
using System.Collections.Generic;
using System.Linq;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.Entidades.AHP;

namespace sisExperto
{
    public class FachadaProyectosExpertos
    {
        private readonly GisiaExpertoContext _context = new GisiaExpertoContext();

        public Experto Experto { get; set; }

        public void GuardarValoracion()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Proyecto> ObtenerProyectosPorTipo(string tipo)
        {
            return from c in _context.Proyectos
                   where c.Tipo == tipo
                   select c;
        }

        public IEnumerable<Experto> ObtenerExpertosFueraDelProyecto(Proyecto proyecto)
        {
            var expertosDelProyecto = new List<int>();

            try
            {
                expertosDelProyecto.AddRange(from c in proyecto.ExpertosAsignados
                                             where c.Activo
                                             select c.Experto.ExpertoId);
            }
            catch (Exception) { }

            return (from c in _context.Expertos
                    where !expertosDelProyecto.Contains(c.ExpertoId)
                    select c).ToList();
        }

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosActivosEnProyecto(Proyecto proyecto)
        {
            return proyecto.ExpertosEnProyectoActivos();
        }

        public void GuardarExpertos(Proyecto proyecto, IEnumerable<ExpertoEnProyecto> expertosEnProyecto)
        {
            proyecto.GuardarExpertos(expertosEnProyecto);
            _context.SaveChanges();
        }

        public Experto ObtenerExpertoValido(string usuario, string password)
        {
            Experto = (from exp in _context.Expertos
                       where exp.Usuario == usuario && exp.Clave == password
                       select exp).FirstOrDefault();
            return Experto;
        }

        public IEnumerable<Proyecto> SolicitarProyectosAsignados(Experto e)
        {
            try
            {
                return (from expEnProyecto in e.ProyectosAsignados
                        select expEnProyecto.Proyecto);
            }
            catch (Exception)
            {
                return new List<Proyecto>();
            }
        }

        public ExpertoEnProyecto SolicitarExpertoProyectoActual (Proyecto _proyecto, Experto _experto)
        {

            return (from expEnProyecto in _experto.ProyectosAsignados
                    where expEnProyecto.Proyecto.ProyectoId == _proyecto.ProyectoId
                    select expEnProyecto

                   ).FirstOrDefault();
        }

        public IEnumerable<Proyecto> SolicitarProyectosCreados(Experto e)
        {
            return e.ProyectosCreados;
        }

        public IEnumerable<Alternativa> SolicitarAlternativas(Proyecto p)
        {
            return p.Alternativas ?? new List<Alternativa>();
        }

        public IEnumerable<AlternativaIL> SolicitarAlternativasIL(ExpertoEnProyecto exp)
        {
            return exp.ValoracionIL.AlternativasIL;
        }

        public IEnumerable<Criterio> SolicitarCriterios(Proyecto p)
        {
            return p.Criterios;
        }

        public Proyecto AltaProyecto(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            _context.SaveChanges();
            return proyecto;
        }

        public void AltaExperto(Experto Experto)
        {
            _context.Expertos.Add(Experto);
            _context.SaveChanges();
        }

        public bool ExisteExperto(string NombreUsuario)
        {
            int valor = _context.Expertos.Where(x => x.Usuario == NombreUsuario).Count();
            return 0 < valor;
        }

        public IEnumerable<Experto> ObtenerExpertos()
        {
            return _context.Expertos;
        }

        public List<CriterioMatriz> matrizCriterio(Proyecto proy, Experto exp)
        {
            //TODO hay que ver todo esto, se descajeto todo con el tema del cambio de las matrices.


            IQueryable<CriterioMatriz> matriz = (from expenproy in _context.ExpertosEnProyectos
                                                 where
                                                     expenproy.Proyecto.ProyectoId == proy.ProyectoId &&
                                                     expenproy.Experto.ExpertoId == exp.ExpertoId
                                                 select expenproy.ValoracionAHP.CriterioMatriz);
            return matriz.ToList();
        }

        //ESTE MÉTODO DE ABAJO NO ME GUSTA MUCHO, SI ALGUIÉN TIENE UNA IDEA MÁS PIOLA, QUE LE META.

        public IEnumerable<AlternativaMatriz> matrizAlternativa(Proyecto proy, Experto exp)
        {
            ExpertoEnProyecto matriz = (from expenproy in _context.ExpertosEnProyectos
                                        where
                                            expenproy.Proyecto.ProyectoId == proy.ProyectoId &&
                                            expenproy.Experto.ExpertoId == exp.ExpertoId
                                        select expenproy).FirstOrDefault();
            return matriz.ValoracionAHP.AlternativasMatrices;
        }

        public void AsignarExpertosAlProyecto(Proyecto Proyecto, IEnumerable<Experto> Expertos, IEnumerable<ConjuntoEtiquetas> Etiquetas)
        {
            List<ExpertoEnProyecto> listaExpertos = new List<ExpertoEnProyecto>();

            for (int i = 0; i < Expertos.Count(); i++)
            {
                listaExpertos.Add(new ExpertoEnProyecto
                                    {
                                        Proyecto = Proyecto,
                                        Experto = Expertos.ElementAt(i),
                                        ValoracionIL = (Proyecto.Tipo != "AHP")
                                        ? new ValoracionIL
                                        {
                                            ConjuntoEtiquetas = Etiquetas.ElementAt(i)
                                        }
                                        : null,
                                        ValoracionAHP = (Proyecto.Tipo != "IL")
                                        ? new ValoracionAHP()
                                        : null,
                                        Peso = 1
                                    });
            }            Proyecto.ExpertosAsignados = listaExpertos.ToList();
            _context.SaveChanges();
        }
        
        public IEnumerable<Experto> ExpertosAsignados(Proyecto Proyecto)
        {
            try
            {
                List<Experto> lista = (from expEnProyecto in Proyecto.ExpertosAsignados
                                       select expEnProyecto.Experto).ToList();
                return lista;
            }
            catch (Exception)
            {
                return new List<Experto>();
            }
        }

        public void ComenzarEdicion(Proyecto proyecto)
        {
            proyecto.Estado = "En Edicion";
            _context.SaveChanges();
        }

        public IEnumerable<Proyecto> ProyectosParaEditar(Experto _experto)
        {
            return (from p in SolicitarProyectosCreados(_experto)
                    where (p.Estado == "Creado") || (p.Estado == "En Edicion")
                    select p);
        }

        public void GuardarAlternativas(Proyecto proyecto, List<Alternativa> alternativas)
        {
            if (proyecto.Alternativas == null)
                proyecto.Alternativas = new List<Alternativa>();
            else proyecto.Alternativas.Clear();

            foreach (Alternativa item in alternativas)
            {
                proyecto.Alternativas.Add(item);
            }
            //Proyecto.Alternativas = Alternativas;
            _context.SaveChanges();
        }

        public void GuardarCriterios(Proyecto proyecto, List<Criterio> criterios)
        {
            if (proyecto.Criterios == null)
                proyecto.Criterios = new List<Criterio>();
            else proyecto.Criterios.Clear();
            
            foreach (Criterio item in criterios)
            {
                proyecto.Criterios.Add(item);
            }
            proyecto.Criterios = criterios;
            _context.SaveChanges();
        }

        public string PublicarProyecto(Proyecto proyecto)
        {
            proyecto.Publicar();
            _context.SaveChanges();
            return proyecto.Estado;
        }
        
        public void GuardarConjuntoEtiquetas(ConjuntoEtiquetas ConjuntoEtiquetas)
        {
            
            _context.ConjuntoEtiquetas.Add(ConjuntoEtiquetas);
            foreach (var item in ConjuntoEtiquetas.Etiquetas)
            {
                _context.Etiqueta.Add(item);
            }
            
            _context.SaveChanges();
        }

        public IEnumerable<Etiqueta> SolicitarEtiquetas(ConjuntoEtiquetas ce)
        {
            return ce.Etiquetas;
        }

        //public ConjuntoEtiquetas SolicitarConjuntoEtiquetasDelExperto(ValoracionIL valoracionIl)
        //{

        //  return (from c in _context.ConjuntoEtiquetas
        //                            where c == valoracionIl.ConjuntoEtiquetas
        //                            select c).FirstOrDefault();
        //}   
     
        
        //public ValoracionIL SolicitarValoracionILDelExpertoEnProycto(ExpertoEnProyecto expertoEnProyecto)
        //{


        //    var algo = solicitarExperProyectoActual();

        //           (from e in _context.ExpertosEnProyectos
        //                where e==expertoEnProyecto
        //                select e.ValoracionIl).FirstOrDefault();

        //       return algo;
        //}



        public List<ConjuntoEtiquetas> SolicitarConjuntoEtiquetasToken(int val)
        {
            IQueryable<ConjuntoEtiquetas> lista = (from c in _context.ConjuntoEtiquetas
                         where c.Token == val
                         select c);
            List<ConjuntoEtiquetas> listaFinal = lista.ToList();
            return listaFinal;
        }

        public List<ConjuntoEtiquetas> SolicitarConjuntoEtiquetasSinAsignar()
        {
            List<ConjuntoEtiquetas> listaProyectosConCE = (from c in _context.ExpertosEnProyectos
                                       where c.ValoracionIL.ConjuntoEtiquetas != null
                                       select c.ValoracionIL.ConjuntoEtiquetas).ToList();

            List<ConjuntoEtiquetas> listaCompletaCE = _context.ConjuntoEtiquetas.ToList();

            List<ConjuntoEtiquetas> lista = listaCompletaCE.Except(listaProyectosConCE).ToList();
            return lista;
        }

        public List<ConjuntoEtiquetas> SolicitarConjuntoEtiquetas()
        {
            List<ConjuntoEtiquetas> lista = _context.ConjuntoEtiquetas.ToList();
            return lista;
        }
    }
}