using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using sisExperto.Entidades;
using sisexperto.Entidades.AHP;

namespace sisexperto.UI.WPFUserControls.ViewModels
{
    public class ValoracionAHPViewModel
    {
        #region Atributos
        
        private MatrizAHPViewModel _matrizAHPCriterio;
        private ReadOnlyCollection<MatrizAHPViewModel> _matricesAHPAlternativas;

        #endregion

        #region Constructores

        public ValoracionAHPViewModel()
        {
        }

        public ValoracionAHPViewModel(IEnumerable<Criterio> criterios, CriterioMatriz matrizCriterio,
                                      IEnumerable<Alternativa> alternativas,
                                      IEnumerable<AlternativaMatriz> matricesAlternativas)
        {
            _matrizAHPCriterio = new MatrizAHPViewModel("Comparación de Criterios",
                                                       criterios.Select(x => x.Nombre).ToList())
            {
                Matriz = matrizCriterio.Matriz,
                Completa = matrizCriterio.Completa,
                Consistente = matrizCriterio.Consistencia
            };

            var matricesAlternativasModels =
                criterios.Select(
                    criterio =>
                    new MatrizAHPViewModel("Comparando alternativas por criterio: " + criterio.Nombre,
                                           alternativas.Select(x => x.Nombre).ToList())
                                           {
                                               Matriz = matricesAlternativas.ElementAt(criterios.ToList().IndexOf(criterio)).Matriz,
                                               Completa = matrizCriterio.Completa,
                                               Consistente = matrizCriterio.Consistencia
                                           }).ToList();

            _matricesAHPAlternativas = new ReadOnlyCollection<MatrizAHPViewModel>(matricesAlternativasModels);
        }

        #endregion

        #region Propiedades

        public IEnumerable<MatrizAHPViewModel> ComparacionAlternativasPorCriterio
        {
            get { return _matricesAHPAlternativas; }
        }

        public MatrizAHPViewModel MatrizSeleccionada { get { return new MatrizAHPViewModel("Prueba", new List<string>() {"uno", "dos", "tres"}); } }

        #endregion
    }
}
