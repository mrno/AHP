using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class OrdenImportanciaAHPViewModel
    {
        public OrdenImportanciaAHPViewModel(List<string> elementos)
        {
            var elementosAPriorizar = (from c in elementos
                                        select new ElementoPriorizadoAHPViewModel(elementos)).ToList();
            ElementosPriorizados = new ReadOnlyCollection<ElementoPriorizadoAHPViewModel>(elementosAPriorizar);
        }

        public ReadOnlyCollection<ElementoPriorizadoAHPViewModel> ElementosPriorizados { get; set; }
    }

    public class ElementoPriorizadoAHPViewModel
    {
        public IEnumerable<string> ElementosDisponibles { get; private set; }
        public string ElementoSeleccionado { get; set; }

        public ElementoPriorizadoAHPViewModel(IEnumerable<string> elementos)
        {
            ElementosDisponibles = elementos;
            ElementoSeleccionado = elementos.First();
        }
    }
}
