using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticResearcher.Graphs.ViewModels
{
    public interface ICheckBoxTreeViewModel : INotifyPropertyChanged
    {
        List<CheckBoxTreeViewModel> Children { get; }
        bool? IsChecked { get; set; }
        bool IsInitiallySelected { get; }
        string Name { get; }
    }
}
