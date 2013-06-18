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
using System.Windows.Shapes;

namespace GeneticResearcher
{
    /// <summary>
    /// Lógica de interacción para ComparisonTestWindow.xaml
    /// </summary>
    public partial class ComparisonTestWindow : Window
    {
        private readonly ComparisonTestViewModel _comparisonTestViewModel;

        public ComparisonTestWindow()
        {
            InitializeComponent();
            _comparisonTestViewModel = new ComparisonTestViewModel();
            base.DataContext = _comparisonTestViewModel;
        }
    }
}
