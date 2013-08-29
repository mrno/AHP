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
    /// Interaction logic for IniciarParametros.xaml
    /// </summary>
    public partial class IniciarParametros : Page
    {
        GISIA2013Entities context;
        ObservableCollection<ValorVectorViewModel> lista;
        double[] vector;

        public IniciarParametros()
        {
            InitializeComponent();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            vector = new double[lista.Count];
            vector = lista.Select(x => x.valor).ToArray();
            
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
            lista = new ObservableCollection<ValorVectorViewModel>(miProyecto.ExpertosEnProyecto.Select(x => new ValorVectorViewModel()));
            
            
            gridVector.ItemsSource = lista;
        }

        



        
    }
}
