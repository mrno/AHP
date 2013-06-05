using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticResearcher.ViewModels;

namespace GeneticResearcher.ComparisonTest.ViewModels
{
    public class MatrixViewModel : INotifyPropertyChanged
    {
        private double? _cr;
        public ObservableCollection<RowViewModel> Rows { get; set; }

        public double[,] Matrix
        {
            get
            {
                if (Rows == null)
                {
                    return new double[0,0];
                }
                //else
                var dimension = Rows.Count;
                var matrix = new double[dimension,dimension];
                foreach (var row in Rows)
                {
                    var rowIndex = Rows.IndexOf(row);
                    foreach (var cell in row.Cells)
                    {
                        var cellIndex = row.Cells.IndexOf(cell);
                        matrix[rowIndex, cellIndex] = cell.Value;
                    }
                }
                return matrix;
            }
            set
            {
                var dimension = value.GetLength(0);

                if (Rows == null)// || dimension != Rows.Count)
                {
                    Rows = new ObservableCollection<RowViewModel>();
                    for (int i = 0; i < dimension; i++)
                    {
                        var row = new RowViewModel {Cells = new ObservableCollection<CellViewModel>()};
                        for (int j = 0; j < dimension; j++)
                        {
                            row.Cells.Add(new CellViewModel());
                        }
                        Rows.Add(row);
                    }
                }

                if(dimension > Rows.Count)
                {
                    for (int i = Rows.Count; i < dimension; i++)
                    {
                        Rows.Add(new RowViewModel {Cells = new ObservableCollection<CellViewModel>()});
                    }

                    foreach (var row in Rows)
                    {
                        for (int i = row.Cells.Count; i < dimension; i++)
                        {
                            row.Cells.Add(new CellViewModel());
                        }
                    }
                }
                else
                {
                    if (dimension < Rows.Count)
                    {
                        var oldOrder = Rows.Count;
                        for (int i = dimension; i < oldOrder; i++)
                        {
                            Rows.RemoveAt(dimension);
                        }
                        foreach (var row in Rows)
                        {
                            for (int i = dimension; i < oldOrder; i++)
                            {
                                row.Cells.RemoveAt(dimension);   
                            }
                        }
                    }
                }

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        var celda = Rows.ElementAt(i).Cells.ElementAt(j);
                        celda.Value = value[i, j];
                        celda.PosX = i;
                        celda.PosY = j;
                    }
                }
                OnPropertyChanged("Rows");
            }
        }

        public string CR
        {
            get { return _cr != null ? _cr.ToString() : " - "; }
        }

        public MatrixViewModel(int dimension)
        {
            Matrix = new double[dimension,dimension];
        }

        private ReadOnlyCollection<OptionViewModel<int>> _dimensions;
        public IEnumerable<OptionViewModel<int>> Dimensions
        {
            get
            {
                if (_dimensions == null)
                {
                    var dimension = new List<OptionViewModel<int>>
                                     {
                                         new OptionViewModel<int>("4", 4),
                                         new OptionViewModel<int>("5", 5),
                                         new OptionViewModel<int>("6", 6),
                                         new OptionViewModel<int>("7", 7),
                                         new OptionViewModel<int>("8", 8),
                                         new OptionViewModel<int>("9", 9)
                                     };

                    _dimensions = new ReadOnlyCollection<OptionViewModel<int>>(dimension);
                }
                return _dimensions;
            }
        }

        private int _dimension;
        public OptionViewModel<int> SelectedDimension
        {
            get { return new OptionViewModel<int>(_dimension.ToString(CultureInfo.InvariantCulture), _dimension); }
            set
            {
                var selectedDimension = value.GetValue();
                if(_dimension != selectedDimension)
                {
                    _dimension = selectedDimension;
                    Matrix = new double[_dimension, _dimension];
                    OnPropertyChanged("Matriz");
                    OnPropertyChanged("Rows");
                }
            }
        }
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class RowViewModel
    {
        public ObservableCollection<CellViewModel> Cells { get; set; }
    }

    public class CellViewModel : INotifyPropertyChanged
    {
        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; 
                OnPropertyChanged("TextValue"); }
        }

        public string TextValue
        {
            get {
                if (_value >= 1)
                {
                    return TextValue.ToString();
                }
                return "1/" + Math.Ceiling(_value).ToString();
            }
            set {
                if (value.Contains("/"))
                {
                    _value = int.Parse(value.Split('/').ElementAt(1));
                }
                else
                {
                    _value = int.Parse(value);
                }
                OnPropertyChanged("Value");
            }
        }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public bool IsEnabled
        {
            get { return PosY > PosX; }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
