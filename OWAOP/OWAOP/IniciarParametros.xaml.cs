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
            MostrarClusters mostrarClusters = new MostrarClusters((Proyectos)cmbProyecto.SelectedItem,Convert.ToDouble(txtAlpha.Text));
            this.NavigationService.Navigate(mostrarClusters);
        }

        private void CargarControles(object sender, RoutedEventArgs e)
        {
            context = new GISIA2013Entities();
            cmbProyecto.ItemsSource = context.Proyectos.ToList();
            cmbProyecto.DisplayMemberPath = "Nombre";
        }

        
    }
}
