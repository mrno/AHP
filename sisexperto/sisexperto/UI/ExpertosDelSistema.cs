using sisExperto;
using sisExperto.Entidades;
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
    public partial class ExpertosDelSistema : Form
    {
        FachadaProyectosExpertos _fachada = new FachadaProyectosExpertos();
        List<Experto> _expertos;

        public ExpertosDelSistema()
        {
            InitializeComponent();
        }

        private void ExpertosDelSistema_Load(object sender, EventArgs e)
        {
            _expertos = _fachada.ObtenerExpertos().ToList();
            CargarGrid();
        }

        private void CargarGrid()
        {
            expertoBindingSource.DataSource = null;
            expertoBindingSource.DataSource = _expertos;

            dataGridExpertos.Refresh();

            dataGridExpertos.Rows[0].Selected = true;
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            var ventanaCreacion = new CrearExperto(_fachada);
            ventanaCreacion.ExpertoAgregado += ventanaCreacion_ExpertoAgregado;
            ventanaCreacion.ShowDialog();
        }

        void ventanaCreacion_ExpertoAgregado(Experto experto)
        {
            _expertos.Add(experto);
            CargarGrid();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar el experto seleccionado?", "Atención", MessageBoxButtons.YesNo);
            if (mensaje.ToString() == "Yes")
            {
                var experto = dataGridExpertos.SelectedRows[0].DataBoundItem as Experto;
                _expertos.Remove(experto);
                _fachada.EliminarExperto(experto);
                CargarGrid();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
