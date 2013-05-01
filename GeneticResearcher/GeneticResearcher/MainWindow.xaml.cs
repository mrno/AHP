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


namespace GeneticResearcher
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //private void ConjuntoMatricesExpanded(object sender, RoutedEventArgs e)
        //{
        //    ordenMatrices.ItemsSource = Fachada.ObtenerConjuntoDimensiones();
        //    nivelInconsistencia.ItemsSource = Fachada.ObtenerNivelesInconsistencia();
            
        //    //ordenMatrices.AddHandler();

        //    conjuntosDisponibles.ItemsSource = Fachada.ConjuntosDisponibles(5, "alto");
        //}

        //private void AgregarAConjuntoPersonalizado(object sender, RoutedEventArgs e)
        //{
        //    conjuntoPersonalizado.IsEnabled = (bool)(sender as CheckBox).IsChecked;
        //}
        
        //private void MatrizIndividualExpanded(object sender, RoutedEventArgs e)
        //{
        //    dimensionMatriz.ItemsSource = Fachada.ObtenerConjuntoDimensiones();
        //    dimensionMatriz.SelectedIndex = 0;
        //    conjuntosPersonalizados.ItemsSource = Fachada.ObtenerConjuntosPersonalizados();
        //}

        //private void ComboBoxDimensionMatrizChanged(object sender, RoutedEventArgs e)
        //{
        //    int dimension = (int) (sender as ComboBox).SelectedValue;
        //    panelMatrizIndividual.Children.Clear();

        //    var grid = new Grid();
        //    for (int j = 0; j < dimension; j++)
        //    {
        //        grid.RowDefinitions.Add(new RowDefinition());
        //        grid.ColumnDefinitions.Add(new ColumnDefinition());
        //    }
        //    panelMatrizIndividual.Children.Add(grid);
            
        //    for (int i = 0; i < dimension; i++)
        //    {
        //        for (int j = 0; j < dimension; j++)
        //        {
        //            var textBox = new TextBox() { Name = "celdaMatriz" + j.ToString() + "x" + i.ToString() };
        //            if(i > j)
        //            {
        //                textBox.TextChanged += (o, args) =>
        //                                           {
        //                                               var posicion = textBox.Name.Replace("celdaMatriz", "").Split('x');
        //                                               var fila = int.Parse(posicion[0]);
        //                                               var columna = int.Parse(posicion[1]);
        //                                               var inverso = (grid.Children[fila * dimension + columna] as TextBox);
        //                                               inverso.Text = Utils.InvertirTexto(textBox.Text);
        //                                           };
        //            }
        //            else
        //            {
        //                if(i == j)
        //                {
        //                    textBox.Text = "1";
        //                }
        //                textBox.IsEnabled = false;
        //            }
        //            textBox.TabIndex = j*dimension + i;
        //            grid.Children.Add(textBox);

        //            Grid.SetColumn(textBox, i);
        //            Grid.SetRow(textBox, j);
        //        }
        //    }
        //}
        private void StartExperimentWizard(object sender, RoutedEventArgs e)
        {
            var wizard = new NewExperimentWindow();
            wizard.Show();
        }
    }
}
