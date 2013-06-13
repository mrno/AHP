using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class MatrizAHPViewModel
    {
        #region Constructores

        public MatrizAHPViewModel(string nombre, List<string> elementos)
        {
            Nombre = nombre;
            ElementosAComparar = new ReadOnlyCollection<string>(elementos);
            ImportanciaDeElementos = new OrdenImportanciaAHPViewModel(elementos);

            var filas = new List<FilaAHPViewModel>();
            foreach (var elemento in elementos)
            {
                var celdas = new List<CeldaAHPViewModel>();
                foreach (var elem in elementos)
                {
                    celdas.Add(new CeldaAHPViewModel());
                }
                filas.Add(new FilaAHPViewModel() {Celdas = new ObservableCollection<CeldaAHPViewModel>(celdas)});
            }
            Filas = new ObservableCollection<FilaAHPViewModel>(filas);
        }

        #endregion
        
        #region Propiedades

        public string Nombre { get; set; }
        public ObservableCollection<FilaAHPViewModel> Filas { get; set; }
        public ReadOnlyCollection<string> ElementosAComparar { get; private set; }
        public OrdenImportanciaAHPViewModel ImportanciaDeElementos { get; private set; }
        public double[,] Matriz { get; set; }
        public bool Completa { get; set; }
        public bool Consistente { get; set; }

        #endregion
    }

    public class FilaAHPViewModel
    {
        public ObservableCollection<CeldaAHPViewModel> Celdas { get; set; }
    }
    
    public class CeldaAHPViewModel
    {
        public string Valor { get; set; }
    }

}
