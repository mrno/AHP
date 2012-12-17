using System;
using System.Collections.Generic;
using System.Linq;
using sisExperto.Entidades;
using sisexperto.Entidades;

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
            return p.Alternativas;
        }

        public IEnumerable<AlternativaIL> SolicitarAlternativasIL(ExpertoEnProyecto exp)
        {
            return exp.ValoracionIl.AlternativasIL;
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
                                                 select expenproy.CriterioMatriz);
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
            return matriz.AlternativasMatrices;
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
                                        ValoracionIl = new ValoracionIL
                                        {
                                            ConjuntoEtiquetas = Etiquetas.ElementAt(i)
                                        },
                                        Peso = 1
                                    });
            }
                       

            Proyecto.ExpertosAsignados = listaExpertos.ToList();
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

        public IEnumerable<Proyecto> ProyectosNoValorados(Experto _experto)
        {
            return (from p in SolicitarProyectosCreados(_experto)
                    where p.Estado == "Creado"
                    select p);
        }

        public void GuardarAlternativas(Proyecto Proyecto, List<Alternativa> Alternativas)
        {
            if (Proyecto.Alternativas == null) Proyecto.Alternativas = new List<Alternativa>();

            foreach (Alternativa item in Alternativas)
            {
                Proyecto.Alternativas.Add(item);
            }
            //Proyecto.Alternativas = Alternativas;
            _context.SaveChanges();
        }

        public void GuardarCriterios(Proyecto Proyecto, List<Criterio> Criterios)
        {
            if (Proyecto.Criterios == null) Proyecto.Criterios = new List<Criterio>();
            foreach (Criterio item in Criterios)
            {
                Proyecto.Criterios.Add(item);
            }
            Proyecto.Criterios = Criterios;
            _context.SaveChanges();
        }

        public void CerrarEdicionProyecto(Proyecto P)
        {
            P.Estado = "Listo";
            _context.SaveChanges();
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
                                       where c.ValoracionIl.ConjuntoEtiquetas != null
                                       select c.ValoracionIl.ConjuntoEtiquetas).ToList();

            List<ConjuntoEtiquetas> listaCompletaCE = _context.ConjuntoEtiquetas.ToList();

            List<ConjuntoEtiquetas> lista = listaCompletaCE.Except(listaProyectosConCE).ToList();
            return lista;



        }

        public List<ConjuntoEtiquetas> SolicitarConjuntoEtiquetas()
        {
            List<ConjuntoEtiquetas> lista = _context.ConjuntoEtiquetas.ToList();
            return lista;
        }

        public void CargarMatrizCriterios(ExpertoEnProyecto ExpertoEP, double[,] MatrizCriterio)
        {
            //ExpertoEP.CriterioMatriz = new CriterioMatriz
             //                              {ExpertoEnProyecto = ExpertoEP, MatrizCriterioAHP = MatrizCriterio};

            _context.CriteriosMatrices.Add(new CriterioMatriz { ExpertoEnProyecto = ExpertoEP, Matriz = MatrizCriterio });
            _context.SaveChanges();
        }

        public void CargarMatrizAlterntivas(ExpertoEnProyecto ExpertoEP, Criterio Criterio, double[,] MatrizAlternativa)
        {
            AlternativaMatriz matrizAlternativa = null;

            try
            {
                matrizAlternativa = (from mat in ExpertoEP.AlternativasMatrices
                                     where mat.CriterioId == Criterio.CriterioId
                                     select mat).FirstOrDefault();
            }
            catch (Exception)
            {
                ExpertoEP.AlternativasMatrices = new List<AlternativaMatriz>();
            }

            if (matrizAlternativa == null)
            {
                ExpertoEP.AlternativasMatrices.Add(
                    new AlternativaMatriz
                        {
                            Criterio = Criterio,
                            ExpertoEnProyecto = ExpertoEP,
                            Matriz = MatrizAlternativa,
                            Consistencia = false
                        });
            }
            else matrizAlternativa.Matriz = MatrizAlternativa;
            _context.SaveChanges();
        }

        public void InicializarMatricesExpertos(Proyecto ProyectoSeleccionado, List<Alternativa> ListaAlternativas,
                                                List<Criterio> ListaCriterios)
        {
            int dimensionCriterio = ListaCriterios.Count;
            int dimensionAlternativa = ListaAlternativas.Count;

            double[,] matrizCriterio = GenerarMatriz(dimensionCriterio);
            double[,] matrizAlternativa = GenerarMatriz(dimensionAlternativa);

            foreach (ExpertoEnProyecto expertoEnProyecto in ProyectoSeleccionado.ExpertosAsignados)
            {
                CargarMatrizCriterios(expertoEnProyecto, matrizCriterio);

                foreach (Criterio criterio in ListaCriterios)
                {
                    CargarMatrizAlterntivas(expertoEnProyecto, criterio, matrizAlternativa);
                }
            }
        }

        //TODO ver todo esto
        public void InicializarILExpertos(Proyecto ProyectoSeleccionado, List<Alternativa> ListaAlternativas,
                                                List<Criterio> ListaCriterios)
        {


            foreach (var expertoEnProyecto in ProyectoSeleccionado.ExpertosAsignados)
            {
                ValoracionIL valoracionIl = expertoEnProyecto.ValoracionIl;
 
                List<AlternativaIL> listaAlternativaIL = new List<AlternativaIL>();
               
                foreach (Alternativa Alternativa in ListaAlternativas)
                {

                    AlternativaIL alternativaIl = new AlternativaIL();
                    alternativaIl.Nombre = Alternativa.Nombre;
                    alternativaIl.Descripcion = Alternativa.Descripcion;
                   
                   
                    
                    List<ValorCriterio> listValorCriterioIL = new List<ValorCriterio>();
                    foreach (Criterio criterio in ListaCriterios)
                    {
                        ValorCriterio valorCriterio = new ValorCriterio();
                        valorCriterio.Nombre = criterio.Nombre;
                        valorCriterio.Descripcion = criterio.Descripcion;
                        valorCriterio.ValorILNumerico = (expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Etiquetas.Count + 1) / 2;
                        valorCriterio.ValorILLinguistico = expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Etiquetas[((expertoEnProyecto.ValoracionIl.ConjuntoEtiquetas.Etiquetas.Count + 1) / 2) - 1].Nombre;
                        listValorCriterioIL.Add(valorCriterio);
                    }

                    alternativaIl.ValorCriterios = listValorCriterioIL;

                    listaAlternativaIL.Add(alternativaIl);
                }

                valoracionIl.AlternativasIL = listaAlternativaIL;

            }

            _context.SaveChanges();


        }

        private double[,] GenerarMatriz(int Dimension)
        {
            var matriz = new double[Dimension,Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    matriz[i, j] = 1;
                }
            }
            return matriz;
        }
    }
}