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
        private readonly ValoracionILViewModel _valoracionIL;

        public ValorarAlternativaILViewModel(ValoracionILViewModel valoracionIL, string nombre, IEnumerable<ValorCriterio> criteriosIL, int cantidadEtiquetas)
        {
            _valoracionIL = valoracionIL;
            Nombre = nombre;
            CriteriosIL =
                new ReadOnlyCollection<CriterioILViewModel>(
                    criteriosIL.Select(
                        x => new CriterioILViewModel(this, x.Nombre, (int) x.ValorILNumerico, cantidadEtiquetas)).ToList());
        }

        public void GuardarCambioCriterio(CriterioILViewModel criterioILViewModel)
        {
            var criterio = CriteriosIL.IndexOf(criterioILViewModel);
            _valoracionIL.ValoracionTrackModificada(criterio);
        }
    }
}
