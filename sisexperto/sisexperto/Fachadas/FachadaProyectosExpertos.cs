using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sisExperto;
using sisExperto.Entidades;
using sisexperto.Entidades;

namespace sisExperto
{    
    public class FachadaProyectosExpertos
    {
        private GisiaExpertoContext _context = new GisiaExpertoContext();

        public Experto Experto { get; set; }

        public Experto ObtenerExpertoValido(string usuario, string password)
        {
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

        public List<CriterioFila> matrizCriterio(Proyecto proy, Experto exp)
        {

            //TODO hay que ver todo esto, se descajeto todo con el tema del cambio de las matrices.

            //var matriz = (from expenproy in _context.ExpertosEnProyectos
            //              where expenproy.Proyecto.ProyectoId == proy.ProyectoId && expenproy.Experto.ExpertoId == exp.ExpertoId
            //              select expenproy.ValoracionCriteriosPorExperto).ToList<ValoracionCriteriosPorExperto>();
            //return matriz;
            return null;
        }

        //ESTE MÉTODO DE ABAJO NO ME GUSTA MUCHO, SI ALGUIÉN TIENE UNA IDEA MÁS PIOLA, QUE LE META.

        public List<CriterioFila> matrizAlternativa(Proyecto proy, Experto exp)
        {
            /*
            var salida = new List<ValoracionAlternativasPorCriterioExperto>();
            var matriz = (from val in _context.ValoracionAlternativasPorCriterioExperto
                          where val.Experto.ExpertoId == exp.ExpertoId
                          select val).ToList<ValoracionAlternativasPorCriterioExperto>();

            foreach (ValoracionAlternativasPorCriterioExperto valor in matriz)
            {
                foreach (Alternativa alt in proy.Alternativas)
                    if (valor.Alternativa == alt)
                        salida.Add(valor);
            }*/
            return null;
        }
       
        public IEnumerable<ExpertoEnProyecto> AsignarExpertosAlProyecto(Proyecto Proyecto, IEnumerable<Experto> Expertos)
        {           
            var lista1 = from exp in Expertos
                        select new ExpertoEnProyecto { Proyecto = Proyecto, Experto = exp, CriterioMatriz = new CriterioMatriz() };
            Proyecto.ExpertosAsignados = lista1.ToList();
            _context.SaveChanges();
            return Proyecto.ExpertosAsignados;
        }

        public void AsignarConjuntoEquiquetasAlExperto(IEnumerable<ExpertoEnProyecto> expertoEnProyectos, IEnumerable<ConjuntoEtiquetas> Conjunto)
        {
            var listaExpertos = from exp in expertoEnProyectos 
                                select exp ;
            int k = 0;
            foreach (ExpertoEnProyecto expertoEnProyecto in listaExpertos)
            {
                expertoEnProyecto.ConjuntoEtiquetas = Conjunto.ToList()[k];
                k++;
                }
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

        internal IEnumerable<Proyecto> ProyectosNoValorados(Entidades.Experto _experto)
        {
            return (from p in SolicitarProyectosCreados(_experto)
                        where p.Estado == "Creado"
                    select p);
        }

        public void GuardarAlternativas(Proyecto Proyecto, List<Alternativa> Alternativas)
        {
            if (Proyecto.Alternativas == null) Proyecto.Alternativas = new List<Alternativa>();
            
            foreach (var item in Alternativas)
            {
                Proyecto.Alternativas.Add(item);
            }
            Proyecto.Alternativas = Alternativas;
            _context.SaveChanges();
        }

        public void GuardarCriterios(Proyecto Proyecto, List<Criterio> Criterios)
        {
            if (Proyecto.Criterios == null) Proyecto.Criterios = new List<Criterio>();
            foreach (var item in Criterios)
            {
                Proyecto.Criterios.Add(item);
            }
            Proyecto.Criterios = Criterios;
            _context.SaveChanges();
        }

        public void CrearValoracionCriteriosPorExperto(Proyecto Proyecto, List<Criterio> Criterios)
        {
            List<CriterioFila> lista = new List<CriterioFila>();

            foreach(ExpertoEnProyecto exp in Proyecto.ExpertosAsignados)
            {
                
            }
        }
      
        public void CerrarEdicionProyecto(Proyecto P)
        {
            P.Estado = "Modificado";
            _context.SaveChanges();
        }

        public void GuardarConjuntoEtiquetas(ConjuntoEtiquetas ConjuntoEtiquetas)
        {

            _context.ConjuntoEtiquetas.Add(ConjuntoEtiquetas);
            _context.SaveChanges();
        }

        public void GuardarEtiqueta(Etiqueta Etiqueta)
        {
            _context.Etiqueta.Add(Etiqueta);
            _context.SaveChanges();
        }

        public IEnumerable<Etiqueta> SolicitarEtiquetas(ConjuntoEtiquetas ce)
        {
            return ce.Etiquetas;
        }

        public IEnumerable<ConjuntoEtiquetas> SolicitarConjuntoEtiquetas()
        {
            return _context.ConjuntoEtiquetas;
        }

        public void CargarValoracionCriteriosPorExperto(Experto Experto, Proyecto Proyecto, double[,] MatrizCriterio)
        {
            var matriz = new double[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = 1;
                }
            }

            var expertoEnProyecto = (from expP in _context.ExpertosEnProyectos
                                     where expP.ExpertoId == Experto.ExpertoId
                                     && expP.ProyectoId == Proyecto.ProyectoId
                                     select expP).FirstOrDefault();

            expertoEnProyecto.CriterioMatriz = new CriterioMatriz() { ExpertoEnProyecto = expertoEnProyecto, MatrizCriterioAHP = matriz };
            //double[,] matriza = expertoEnProyecto.CriterioMatriz.MatrizCriterioAHP;
            _context.SaveChanges();
        }
    }
}
