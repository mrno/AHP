using System;
using System.Collections.Generic;
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
    /// Interaction logic for IniciarParametros.xaml
    /// </summary>
    public partial class IniciarParametros : Page
    {
        GISIA2013Entities context;
        public IniciarParametros()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            double [] vector = {
                            Convert.ToDouble(txt1.Text), 
                            Convert.ToDouble(txt2.Text),
                            Convert.ToDouble(txt3.Text),
                            Convert.ToDouble(txt4.Text),
                            Convert.ToDouble(txt5.Text),
                            Convert.ToDouble(txt6.Text)
                        };
            MostrarClusters mostrarClusters = new MostrarClusters((Proyectos)cmbProyecto.SelectedItem,Convert.ToDouble(txtAlpha.Text), vector);
            this.NavigationService.Navigate(mostrarClusters);
        }

        private void CargarControles(object sender, RoutedEventArgs e)
        {
            context = new GISIA2013Entities();
            cmbProyecto.ItemsSource = context.Proyectos.ToList();
            cmbProyecto.DisplayMemberPath = "Nombre";
        }

        private void desplegarTextBox(object sender, SelectionChangedEventArgs e)
        {
            Proyectos miProyecto = (Proyectos)cmbProyecto.SelectedItem;
            List<double> lista = new List<double>(miProyecto.ExpertosEnProyecto.Select(x => 0.0));

            //foreach (var item in miProyecto.ExpertosEnProyecto)
            //{
            //    lista.Add(0);
            //}


            DataTable dt = new DataTable();
            dt.Columns.Add("Valor");
            foreach (var item in lista)
            {
                dt.Rows.Add(item);
            }
            gridVector.ItemsSource = dt.DefaultView;
        }

        



        
    }
}
