using System.Collections.ObjectModel;
using GeneticResearcher.ComparisonTest.ViewModels;
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

namespace GeneticResearcher.ComparisonTest.Views
{
    /// <summary>
    /// Lógica de interacción para MatrixView.xaml
    /// </summary>
    public partial class MatrixView : UserControl
    {
        //private MatrixViewModel _matrix = new MatrixViewModel {Matrix = new double[5,5]};

        //public ObservableCollection<RowViewModel> MatrixRows
        //{
        //    get { return _matrix.Rows; }
        //}

        public MatrixView()
        {
            InitializeComponent();
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
