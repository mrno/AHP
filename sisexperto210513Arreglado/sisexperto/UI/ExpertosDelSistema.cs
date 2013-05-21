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
        #region Delegados y Eventos

        public delegate void Proyectos();
        public event Proyectos ProyectosModificado;

        #endregion

        private FachadaProyectosExpertos _fachada;
        private Experto _experto;
        private List<Experto> _expertos;

        public ExpertosDelSistema(Experto experto, FachadaProyectosExpertos fachada)
        {
            InitializeComponent();
            _experto = experto;
            _fachada = fachada;
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
            var experto = dataGridExpertos.SelectedRows[0].DataBoundItem as Experto;

            if (_experto != experto)
            {
                var mensaje =
                    MessageBox.Show(
                        "¿Está seguro que desea eliminar el experto seleccionado y todas sus valoraciones?", "Atención",
                        MessageBoxButtons.YesNo);
                if (mensaje.ToString() == "Yes")
                {
                    if (experto.Administrador && experto.ProyectosCreados.Count != 0)
                    {
                        var mensaje2 =
                            MessageBox.Show(
                                "Está a punto de eliminar un administrador y sus proyectos deben estar a cargo de otro administrador. ¿Desea transferir los proyectos y continuar?",
                                "Atención", MessageBoxButtons.YesNo);
                        switch (mensaje2.ToString())
                        {
                            case "Yes":
                                {
                                    // transfiere los proyectos al experto actual
                                    var ventanaTransferencia = new TransferirProyectos(experto, _experto, _fachada);
                                    ventanaTransferencia.ProyectosTransferidos += () => ProyectosModificado();
                                    ventanaTransferencia.ShowDialog();

                                    //_fachada.TransferirProyectos(experto, _experto);
                                    if (experto.ProyectosCreados.Count == 0)
                                    {
                                        _expertos.Remove(experto);
                                        _fachada.EliminarExperto(experto);
                                        MessageBox.Show("Experto eliminado con éxito.");
                                        CargarGrid();
                                    }
                                    else
                                    {
                                        MessageBox.Show(
                                            "No se puede eliminar el experto mientras tenga proyectos creados a su cargo.");
                                    }
                                    break;
                                }
                            case "No":
                                break;
                        }
                        //_expertos.Remove(experto);
                        //_fachada.EliminarValoracion(experto);                    
                    }
                    else
                    {
                        _expertos.Remove(experto);
                        _fachada.EliminarExperto(experto);
                        ProyectosModificado();
                        CargarGrid();
                    }
                }
            }
            else MessageBox.Show("Un administrador no puede ser eliminado por él mismo.");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDesactivarValoraciones_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar todas las valoraciones del experto seleccionado?", "Atención", MessageBoxButtons.YesNo);
            if (mensaje.ToString() == "Yes")
            {
                var experto = dataGridExpertos.SelectedRows[0].DataBoundItem as Experto;
                _fachada.DesactivarValoracion(experto);
                ProyectosModificado();
            }
        }

        private void buttonTranferir_Click(object sender, EventArgs e)
        {
            var experto = dataGridExpertos.SelectedRows[0].DataBoundItem as Experto;

            if(!experto.Administrador)
            {
                MessageBox.Show("No se pueden tranferir proyectos a un experto que no sea administrador.");
            }
            else
            {
                // transfiere los proyectos al experto actual
                var ventanaTransferencia = new TransferirProyectos(_experto, experto, _fachada);
                ventanaTransferencia.ProyectosTransferidos += () => ProyectosModificado();
                ventanaTransferencia.ShowDialog();
            }
            
        }
    }
}
