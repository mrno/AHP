using sisexperto.Entidades.IL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValorarAlternativaILViewModel
    {
        public string Nombre { get; private set; }
        public ReadOnlyCollection<CriterioILViewModel> CriteriosIL { get; private set; }
        //public int CantidadCriterios { get { return CriteriosIL.Count; } }

        public ValorarAlternativaILViewModel(string nombre, IEnumerable<ValorCriterio> criteriosIL, int cantidadEtiquetas)
        {
            Nombre = nombre;
            CriteriosIL =
                new ReadOnlyCollection<CriterioILViewModel>(
                    criteriosIL.Select(
                        x => new CriterioILViewModel(x.Nombre, (int) x.ValorILNumerico, cantidadEtiquetas)).ToList());
        }
    }
}
