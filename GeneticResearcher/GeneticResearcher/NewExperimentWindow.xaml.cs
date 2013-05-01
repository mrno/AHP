using GeneticResearcher.ExperimentWizard.ViewModels;
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
    /// Lógica de interacción para NewExperimentWindow.xaml
    /// </summary>
    public partial class NewExperimentWindow : Window
    {
        private readonly ExperimentWizardViewModel _experimentWizardViewModel;

        public NewExperimentWindow()
        {
            InitializeComponent();

            _experimentWizardViewModel = new ExperimentWizardViewModel();
            _experimentWizardViewModel.RequestClose += OnViewModelRequestClose;
            base.DataContext = _experimentWizardViewModel;
        }
        
        /// <summary>
        /// Returns the cup of coffee ordered by the user, 
        /// or null if the user cancelled the order.
        /// </summary>
        public SesionExperimentacion Result
        {
            get { return _experimentWizardViewModel.Sesion; }
        }

        void OnViewModelRequestClose(object sender, EventArgs e)
        {
            base.DialogResult = this.Result != null;
        }
    }
}
