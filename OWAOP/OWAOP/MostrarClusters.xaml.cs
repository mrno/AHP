using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OWAOP
{
    /// <summary>
    /// Interaction logic for MostrarClusters.xaml
    /// </summary>
    public partial class MostrarClusters : Page
    {
        Proyectos proyecto;
        double alpha;
        List<List<ValorViewModel>> matriz;
        List<List<ValorViewModel>> matrizIntermedia;
        List<ExpertosEnProyecto> expertos;

        public MostrarClusters(Proyectos unProyecto, double unAlpha)
        {
            InitializeComponent();

            proyecto = unProyecto;
            alpha = unAlpha;
            matriz = new List<List<ValorViewModel>>();
            expertos = proyecto.ExpertosEnProyecto.ToList<ExpertosEnProyecto>();

            lblProyecto.Content = unProyecto.Nombre.ToString();
            int pos = 0;

            foreach (var exp in expertos)
            {
                double virtu = 12; // ver como lo saco
                double real = exp.ValoracionILs.ConjuntoEtiquetas.Cantidad - 1;
                
                int posm = 0;
                foreach (var alt in exp.ValoracionILs.AlternativaILs)
                {
                   
                    
                    List<ValorViewModel> lista = new List<ValorViewModel>();

                        foreach (var cri in alt.ValorCriterios)
                        {
                            
                            
                            ValorViewModel celda = new ValorViewModel();
                            celda.valor = ((cri.ValorILNumerico * virtu) / real) / virtu;
                            celda.posicionFila = pos;
                            celda.posicionColumna = posm;
                            pos++;
                            lista.Add(celda);
                            
                        }

                        matriz.Add(lista);
                }
            }

            matrizIntermedia = new List<List<ValorViewModel>>();

            foreach (var exp in expertos)
            {
                List<ValorViewModel> lista = new List<ValorViewModel>();
                int columna = 0;

                foreach (var alt in exp.ValoracionILs.AlternativaILs)
                {
                    foreach (var cri in alt.ValorCriterios)
                    {
                        foreach (var item in matriz)
                        {
                            foreach (var celda in item)
	                            {
                                    if (columna == celda.posicionColumna)
                                    {
                                        ValorViewModel elemento = new ValorViewModel();
                                        elemento.valor =
                                        elemento.posicion =
                                        elemento.posicionMatriz =

                                        lista.Add(elemento);
                                    }
	                            }
                            
                        }
                    }
                }

                matrizIntermedia.Add(lista);
            }

            //for (int i = 0; i < exp.ValoracionILs.AlternativaILs.Count; i++)
            //{
            //    int b = 0;
            //if (i != b)
            //{
            //}
            //}

            //int a = matriz.Count;
        }

        private int FuncionSoporte(double val1, double val2)
        {
            if (Math.Abs(val1 - val2) < alpha)
                return 1;
            else
                return 0;
        }

        

    }
}
