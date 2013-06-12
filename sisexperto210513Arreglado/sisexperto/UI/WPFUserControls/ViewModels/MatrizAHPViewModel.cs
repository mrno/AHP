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
        public int Valor { get; set; }
    }

}
