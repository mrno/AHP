using sisexperto.UI.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto.UI
{
    public partial class Sugerencias : Form
    {
        #region Delegates and Events

        public delegate void SugerenciaDelegate(IEnumerable<SugerenciaViewModel> sugerencia);
        public event SugerenciaDelegate ComunicarSugerencia;

        #endregion

        private List<SugerenciaViewModel> _sugerencias;

        public Sugerencias(IEnumerable<SugerenciaViewModel> sugerencias)
        {
            InitializeComponent();

            ActualizarSugerencias(sugerencias);
            ActualizarGridConUnaSugerencia(_sugerencias.First());
        }

        public void ActualizarSugerencias(IEnumerable<SugerenciaViewModel> sugerencias)
        {
            _sugerencias = sugerencias.ToList();
            ActualizarGridConUnaSugerencia(_sugerencias.First());
        }

        public void ActualizarGridSugerencias()
        {
            sugerenciaViewModelBindingSource.DataSource = null;
            sugerenciaViewModelBindingSource.DataSource = _sugerencias;

            dataGridSugerencias.Refresh();
        }

        public void ActualizarGridConUnaSugerencia(SugerenciaViewModel sugerencia)
        {
            var sugerencias = new List<SugerenciaViewModel>() { sugerencia };
            sugerenciaViewModelBindingSource.DataSource = null;
            sugerenciaViewModelBindingSource.DataSource = sugerencias;

            dataGridSugerencias.Refresh();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            var sugerenciasSeleccionadas = new List<SugerenciaViewModel>();

            /* quizás se puede hacer con un foreach o linq */
            for (int i = 0; i < dataGridSugerencias.SelectedRows.Count; i++)
            {
                sugerenciasSeleccionadas.Add(dataGridSugerencias.SelectedRows[i].DataBoundItem as SugerenciaViewModel);
            }
            ComunicarSugerencia(sugerenciasSeleccionadas);
        }

        private void buttonOtraSugerencia_Click(object sender, EventArgs e)
        {
            if (_sugerencias.Count > 1)
            {
                _sugerencias.RemoveAt(0);
                ActualizarGridConUnaSugerencia(_sugerencias.First());
            }
            else 
            {
                ComunicarSugerencia(new List<SugerenciaViewModel>());
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
