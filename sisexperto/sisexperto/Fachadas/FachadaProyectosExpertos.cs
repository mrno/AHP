using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisExperto;
using sisExperto.Entidades;

namespace sisExperto
{    
    public class FachadaProyectosExpertos
    {
        private GisiaExpertoContext _context = new GisiaExpertoContext();

        public Experto Experto { get; set; }

        public Experto ObtenerExpertoValido(string usuario, string password)
        {
            //using (var asd = new GisiaExpertoContext()) { }
            Experto = (from exp in _context.Expertos
                       where exp.Usuario == usuario && exp.Clave == password
                       select exp).FirstOrDefault();
            return Experto;
        }

        public IEnumerable<Proyecto> SolicitarProyectosAsignados(Experto e)
        {
            return (from expEnProyecto in e.ProyectosAsignados
                    select expEnProyecto.Proyecto);
        }

        public IEnumerable<Proyecto> SolicitarProyectosCreados(Experto e)
        {
            return e.ProyectosCreados;
        }

        public IEnumerable<Alternativa> SolicitarAlternativas(Proyecto p)
        {
            return p.Alternativas;
        }

        public IEnumerable<Criterio> SolicitarCriterios(Proyecto p)
        {
            return p.Criterios;
        }

        public void AltaProyecto(Proyecto proyecto)
        {
            _context.Proyectos.Add(proyecto);
            _context.SaveChanges();
        }

        public void AltaExperto(Experto Experto)
        {
            _context.Expertos.Add(Experto);
            _context.SaveChanges();
        }

        public bool ExisteExperto(string NombreUsuario)
        {
            var valor = _context.Expertos.Where(x => x.Usuario == NombreUsuario).Count();
            return 0 < valor;
        }
        
        public IEnumerable<Experto> ObtenerExpertos()
        {
            return _context.Expertos;
        }

        public IEnumerable<ExpertoEnProyecto> ObtenerExpertosProyectoConsistente(Proyecto Proyecto)
        {
            var lista = from p in Proyecto.ExpertosAsignados
                            where TodasValoracionesConsistentes(p)
                            select p
                            ;


            return lista;
        }

        private bool TodasValoracionesConsistentes(ExpertoEnProyecto ExpertoEnProyecto) {

            bool CriteriosConsistentes = ExpertoEnProyecto.ValoracionCriteriosPorExperto.Consistencia=true;
            
            var cantidadCriterios = ExpertoEnProyecto.ValoracionAlternativasPorCriterioExperto.Count();
            
            var listaAlternativasConsistente = from e in ExpertoEnProyecto.ValoracionAlternativasPorCriterioExperto
                                               where e.Consistencia = true
                                               select e;


            return CriteriosConsistentes || cantidadCriterios == listaAlternativasConsistente.ToList().Count();
        }

        public void AsignarExpertosAlProyecto(Proyecto Proyecto, IEnumerable<Experto> Expertos)
        {
            foreach (var Experto in Expertos)
            {
                var lista = from exp in Expertos
                            select new ExpertoEnProyecto { Proyecto = Proyecto, Experto = exp };
                Proyecto.ExpertosAsignados = lista.ToList();
                _context.SaveChanges();
            }
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

        internal IEnumerable<Proyecto> ProyectosNoValorados(Entidades.Experto _experto)
        {
            return (from p in SolicitarProyectosCreados(_experto)
                        where p.Estado == "Creado"
                    select p);
        }

        public void GuardarAlternativas(Proyecto Proyecto, List<Alternativa> Alternativas)
        {
            //if (Proyecto.Alternativas == null) Proyecto.Alternativas = new List<Alternativa>();
            /*
            foreach (var item in Alternativas)
            {
                Proyecto.Alternativas.Add(item);
            }*/
            Proyecto.Alternativas = Alternativas;
            _context.SaveChanges();
        }

        public void GuardarCriterios(Proyecto Proyecto, List<Criterio> Criterios)
        {/*
            if (Proyecto.Criterios == null) Proyecto.Criterios = new List<Criterio>();
            foreach (var item in Criterios)
            {
                Proyecto.Criterios.Add(item);
            }*/
            Proyecto.Criterios = Criterios;
            _context.SaveChanges();
        }

        public void CerrarEdicionProyecto(Proyecto P)
        {
            P.Estado = "Modificado";
            _context.SaveChanges();
        }
    }
}
