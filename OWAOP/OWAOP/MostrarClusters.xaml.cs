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
        List<List<ValorViewModel>> matrizFinal;
        List<ExpertosEnProyecto> expertos;
        int matrizFilas;
        int matrizColumnas;

        public MostrarClusters(Proyectos unProyecto, double unAlpha)
        {
            InitializeComponent();

            proyecto = unProyecto;
            alpha = unAlpha;
            matriz = new List<List<ValorViewModel>>();
            expertos = proyecto.ExpertosEnProyecto.ToList<ExpertosEnProyecto>();
            matrizFilas = expertos.Count;
            matrizColumnas = expertos.First<ExpertosEnProyecto>().ValoracionILs.AlternativaILs.First<AlternativaILs>().ValorCriterios.Count * expertos.First<ExpertosEnProyecto>().ValoracionILs.AlternativaILs.Count;

            lblProyecto.Content = unProyecto.Nombre.ToString();
            int columna = 0;
            int fila = 0;

            foreach (var exp in expertos)
            {
                double virtu = 12; // ver como lo saco
                double real = exp.ValoracionILs.ConjuntoEtiquetas.Cantidad - 1;
                columna = 0;
                
                foreach (var alt in exp.ValoracionILs.AlternativaILs)
                {
                    List<ValorViewModel> lista = new List<ValorViewModel>();

                        foreach (var cri in alt.ValorCriterios)
                        {
                            ValorViewModel celda = new ValorViewModel();
                            celda.valor = ((cri.ValorILNumerico * virtu) / real) / virtu;
                            celda.posicionFila = fila;
                            celda.posicionColumna = columna;
                            columna++;
                            lista.Add(celda);
                        }
                        matriz.Add(lista);
                }
                fila++;
            }

            matrizIntermedia = new List<List<ValorViewModel>>();

                foreach (var item1 in matriz)
                {
                    List<ValorViewModel> lista2 = new List<ValorViewModel>();
                    foreach (var celda1 in item1)
                    {
                        var acumulador = 0;
                        foreach (var item in matriz)
                        {
                            foreach (var celda in item)
                            {
                                if (celda1.posicionColumna == celda.posicionColumna && celda1.posicionFila != celda.posicionFila)
                                {
                                    acumulador += FuncionSoporte(celda1.valor, celda.valor);
                                }
                            }
                        }
                        
                        ValorViewModel elemento = new ValorViewModel();
                        elemento.valorCluster = acumulador;
                        elemento.valor = celda1.valor;
                        elemento.posicionColumna = celda1.posicionColumna;
                        elemento.posicionFila = celda1.posicionFila;
                        lista2.Add(elemento);
                    }
                                    
                    matrizIntermedia.Add(lista2);
                }

                int a = matrizIntermedia.Count;

                matrizFinal = new List<List<ValorViewModel>>();

                for (int i = 0; i < matrizColumnas; i++)
                {
                    List<ValorViewModel> lista = new List<ValorViewModel>();

                    foreach (var item in matrizIntermedia)
                    {
                        foreach (var celda in item)
                        {
                            if (celda.posicionColumna == i)
                            {
                                lista.Add(celda);
                            }
                        }
                    }

                    matrizFinal.Add(lista);
                }

                int b = matrizFinal.Count;

                foreach (var item in matrizFinal)
                {
                    item.OrderBy(algo => algo.valorCluster);
                }
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
