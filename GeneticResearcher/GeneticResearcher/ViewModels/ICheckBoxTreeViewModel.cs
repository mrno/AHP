using System.Collections.Generic;
using System.ComponentModel;

namespace GeneticResearcher.ViewModels
{
    public interface ICheckBoxTreeViewModel : INotifyPropertyChanged
    {
        List<CheckBoxTreeViewModel> Children { get; }
        bool? IsChecked { get; set; }
        bool IsInitiallySelected { get; }
        string Name { get; }
    }
}
