using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GALibrary.Persistencia;
using GeneticResearcher.Common;
using GeneticResearcher.Graphs.ViewModels;

namespace GeneticResearcher.ViewModels
{
    public class ExperimentResultsViewModel: INotifyPropertyChanged
    {
        #region Fields

        private ReadOnlyCollection<ExperimentViewModel> _experiments;
        private ReadOnlyCollection<OptionViewModel<string>> _experimentOptionList;
        
        #endregion // Fields

        #region Constructor

        public ExperimentResultsViewModel()
        {
            //TODO: buscar en BD
            SelectedExperiment = new ExperimentViewModel(new SesionExperimentacion());
            Graphic = new GraphicViewModel();
        }

        #endregion // Constructor

        #region Properties

        public IEnumerable<OptionViewModel<string>> Experiments
        {
            get
            {
                if (_experimentOptionList == null)
                {
                    var models = new List<OptionViewModel<string>>
                                     {
                                         new OptionViewModel<string>("Experimento 1", "asd"),
                                         new OptionViewModel<string>("Experimento 2", "asdf"),
                                         new OptionViewModel<string>("Experimento 3", "asdfg"),
                                         new OptionViewModel<string>("Experimento 4", "asdfh"),
                                         new OptionViewModel<string>("Experimento 5", "asdfi"),
                                         new OptionViewModel<string>("Experimento 6", "asdfj"),
                                         new OptionViewModel<string>("Experimento 7", "asdfk"),
                                         new OptionViewModel<string>("Experimento 8", "asdfl"),
                                         new OptionViewModel<string>("Experimento 9", "asdfm"),
                                         new OptionViewModel<string>("Experimento 10", "asdfn")
                                     };

                    _experimentOptionList = new ReadOnlyCollection<OptionViewModel<string>>(models);
                }
                return _experimentOptionList;
            }
        }

        public ExperimentViewModel SelectedExperiment { get; private set; }

        public GraphicViewModel Graphic { get; private set; }

        #endregion // Properties

        #region Methods

        #endregion // Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
