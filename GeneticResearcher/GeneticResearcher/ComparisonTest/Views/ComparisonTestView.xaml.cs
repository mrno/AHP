﻿using System;
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
using GALibrary.Persistencia;

namespace GeneticResearcher.ComparisonTest.Views
{
    /// <summary>
    /// Lógica de interacción para ComparisonTestView.xaml
    /// </summary>
    public partial class ComparisonTestView : UserControl
    {
        public ComparisonTestView()
        {
            InitializeComponent();
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            var wizard = new NewExperimentWindow(new SesionExperimentacion());
            wizard.Show();
        }
    }
}
