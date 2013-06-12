using System.Linq;
using System.Threading.Tasks;
using GALibrary;
using GALibrary.Persistencia;
using GeneticResearcher.Graphs.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;

namespace GeneticResearcher.ViewModels
{
    public class ConjuntoMatrizViewModel : CheckBoxTreeViewModel
    {
        protected ConjuntoMatrizViewModel(string name) : base(name)
        {
        }

        public ConjuntoMatrizViewModel() : this("Conjuntos")
        {
            LoadChildren();
        }

        #region Overrides of CheckBoxTreeViewModel

        public async override void LoadChildren()
        {
            await Task.Run(() =>
                               {

                                   var dimensions = FacadeGAModule.ObtenerDimensiones();
                                   var inconsistencies = FacadeGAModule.ObtenerNivelesInconsistencia();

                                   var children = new List<ConjuntoMatrizViewModel>();
                                   foreach (var dimensionChildren in dimensions
                                       .Select(dimension =>
                                               new ConjuntoMatrizViewModel("Dimension: " + dimension)
                                                   {
                                                       Children = new List<CheckBoxTreeViewModel>()
                                                   }))
                                   {
                                       children.Add(dimensionChildren);

                                       foreach (var inconsistencyChildren in inconsistencies
                                           .Select(nivelInconsistencia =>
                                                   new ConjuntoMatrizViewModel("Nivel Inconsistencia: " +
                                                                               nivelInconsistencia)))
                                       {
                                           dimensionChildren.Children.Add(inconsistencyChildren);
                                       }
                                   }

                                   var root = new ConjuntoMatrizViewModel(Name)
                                                  {
                                                      IsInitiallySelected = true,
                                                      Children = children.ToList<CheckBoxTreeViewModel>()
                                                  };
                                   root.Initialize();
                                   Children = new List<CheckBoxTreeViewModel> {root};
                                   ChildrenLoaded = true;
                               });
            OnPropertyChanged("Children");
            OnPropertyChanged("ChildrenLoaded");
        }

        #endregion
    }
}