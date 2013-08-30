using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        double[] vector;
        List<List<ValorViewModel>> matriz;
        List<List<ValorViewModel>> matrizIntermedia;
        List<List<ValorViewModel>> matrizFinal;
        List<ExpertosEnProyecto> expertos;
        int matrizFilas;
        int matrizColumnas;
        int conteo;

        public MostrarClusters(Proyectos unProyecto, double unAlpha, double[] unVector)
        {
            InitializeComponent();

            proyecto = unProyecto;
            alpha = unAlpha;
            vector = unVector;
            matriz = new List<List<ValorViewModel>>();
            expertos = proyecto.ExpertosEnProyecto.ToList<ExpertosEnProyecto>();
            matrizFilas = expertos.Count;
            matrizColumnas = expertos.First<ExpertosEnProyecto>().ValoracionILs.AlternativaILs.First<AlternativaILs>().ValorCriterios.Count * expertos.First<ExpertosEnProyecto>().ValoracionILs.AlternativaILs.Count;
            
            int columna = 0;
            int fila = 0;

            foreach (var exp in expertos)
            {
                int virtu = ObtenerCardinalidadCEN();
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

                List<List<ValorViewModel>> matrizFinalOrdenada = new List<List<ValorViewModel>>();

                foreach (var item in matrizFinal)
                {
                    var subset = from celda in item orderby celda.valorCluster, celda.valor select celda;
                    conteo=subset.Count<ValorViewModel>();
                    matrizFinalOrdenada.Add(subset.ToList<ValorViewModel>());
                }

                

                double sum;
                List<double> listaSum = new List<double>();

                foreach (var item in matrizFinalOrdenada)
                {
                    sum = 0;   
                    for (int i = 0; i < vector.Length; i++)
                    {
                        item.ElementAt<ValorViewModel>(i).valorFinal = item.ElementAt<ValorViewModel>(i).valor * vector[i];
                        sum += item.ElementAt<ValorViewModel>(i).valorFinal;
                    }

                    listaSum.Add(sum);
                }

                gridResultados.ItemsSource = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("Valor");
                foreach (var item in listaSum)
                {
                    
                    dt.Rows.Add(item);
                }


                gridDetalles.ItemsSource = null;
                DataTable dtR = new DataTable();

                for (int i = 0; i < conteo; i++)
                {
                    dtR.Columns.Add("Posición" + i.ToString());
                }
            
                foreach (var item in matrizFinalOrdenada)
                {
                    int[] miVector = new int[item.Count];

                    for (int i = 0; i < miVector.Length; i++)
                    {
                        miVector[i] = item.ElementAt<ValorViewModel>(i).valorCluster;
                    }
                    
                }
                

                //ObservableCollection<ValorViewModel> listaDetalles = new ObservableCollection<ValorViewModel>();
                //foreach (var item in matrizFinalOrdenada)
                //{
                //    listaDetalles.Add(item);
                //}





                gridDetalles.ItemsSource = dtR.DefaultView;

                gridResultados.ItemsSource = dt.DefaultView;
        }

        private int FuncionSoporte(double val1, double val2)
        {
            if (Math.Abs(val1 - val2) < alpha)
                return 1;
            else
                return 0;
        }

        //Esto del Mcm lo saqué de la clase "Utils.cs" luego, sólo referenciar. También ObtenerEstructurado().

        public int Mcm(params int[] numeros)
        {
            int maximo = 1;
            int tmp = 0;
            foreach (int b in numeros)
            {
                numeros[tmp] = Math.Abs(b);
                maximo = maximo * numeros[tmp];
                tmp++;
            }
            int resultado = 1;
            for (int i = 2; i <= maximo; i++)
            {
                bool a = true;
                foreach (int b in numeros)
                {
                    if (i % b != 0)
                    {
                        a = false;
                    }
                }
                if (a)
                {
                    resultado = i;
                    break;
                }
            }
            return resultado;
        }

        public int ObtenerCardinalidadCEN()
        {
            List<int> lista = new List<int>();

            foreach (var exp in expertos)
            {
                lista.Add(exp.ValoracionILs.ConjuntoEtiquetas.Cantidad - 1);
            }
            return Mcm(lista.ToArray());
        }
    }
}
