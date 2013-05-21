using sisexperto.UI.Clases;
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
    public partial class TransferirProyectos : Form
    {
        #region Delegados y Eventos

        public delegate void Proyectos();
        public event Proyectos ProyectosTransferidos;

        #endregion

        private FachadaProyectosExpertos _fachada;
        private List<Experto> _expertos; 
        private Experto _origen;
        private Experto _destino;

        private List<ProyectoTransferibleViewModel> _proyectos; 

        public TransferirProyectos(Experto origen, Experto destino, FachadaProyectosExpertos fachada)
        {
            InitializeComponent();
            _origen = origen;
            _destino = destino;
            _fachada = fachada;
            _expertos = fachada.ObtenerExpertos().Where(x => x.Administrador).ToList();
            ActualizarGridProyectos();
        }

        private void TransferirProyectos_Load(object sender, EventArgs e)
        {
            comboBoxOrigen.DataSource = _expertos.ToList();
            comboBoxDestino.DataSource = _expertos.ToList();

            comboBoxOrigen.SelectedItem = _origen;
            comboBoxDestino.SelectedItem = _destino;

            comboBoxOrigen.SelectedIndexChanged += (o, args) =>
                                                       {
                                                           _origen = comboBoxOrigen.SelectedItem as Experto;
                                                           ActualizarGridProyectos();
                                                       };
            comboBoxDestino.SelectedIndexChanged += (o, args) =>
                                                        {
                                                            _destino = comboBoxDestino.SelectedItem as Experto;
                                                        };
        }

        private void ActualizarGridProyectos()
        {
            _proyectos = (from c in _origen.ProyectosCreados.ToList()
                          select new ProyectoTransferibleViewModel {Proyecto = c, Seleccionado = true}).ToList();

            proyectoTransferibleViewModelBindingSource.DataSource = null;
            proyectoTransferibleViewModelBindingSource.DataSource = _proyectos;
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Transferir();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTranferirYSalir_Click(object sender, EventArgs e)
        {
            Transferir();
            Close();
        }

        private void Transferir()
        {
            if (_origen == _destino)
            {
                MessageBox.Show("El experto origen y el de destino deben ser distintos.");
            }
            else
            {
                var proyectos = from c in _proyectos
                                where c.Seleccionado
                                select c.Proyecto;
                if (proyectos.Count() > 0)
                {
                    _fachada.TransferirProyectos(_origen, _destino, proyectos);
                    ProyectosTransferidos();
                    ActualizarGridProyectos();
                    MessageBox.Show("Proyectos transferidos con éxito.");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar uno o más proyectos para hacer la transferencia.");
                }
            }
        }
    }
}
