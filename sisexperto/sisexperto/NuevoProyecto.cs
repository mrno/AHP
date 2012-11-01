using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisexperto
{
    public partial class NuevoProyecto : Form
    {
        public delegate void Proyectos();
        public event Proyectos ProyectoCreado;
        
        private List<experto> _expertosAsignados = new List<experto>();
        private List<experto> _todosExpertos = new List<experto>();

        private int _experto;

        private FachadaSistema _fachada;

        public NuevoProyecto(FachadaSistema Fachada, experto experto)
        {
            InitializeComponent();
            labelNombreExperto.Text = string.Format("{0}, {1}", experto.apellido.ToUpper(), experto.nombre);
            _experto = experto.id_experto;
            _fachada = Fachada;
        }

        private void AsignarExperto(experto exp)
        {
            _expertosAsignados.Add(exp);
            ActualizarGridExpertosAsignados();
        }

        private void ActualizarGridExpertosAsignados()
        {
            dataGridExpertosAsignados.DataSource = null;
            var lista = _expertosAsignados;
            lista.Reverse();
            dataGridExpertosAsignados.DataSource = lista; 
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //groupBox2.Visible = true;
            //dataGridView2.Visible = false;
            var ventanaCrearExperto = new CrearExperto(_fachada);
            ventanaCrearExperto.ExpertoAgregado += (AsignarExperto);
            ventanaCrearExperto.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_todosExpertos.Count > 0)
            {
                experto exp = (experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem;
                _todosExpertos.Remove((experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem);

                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                AsignarExperto(exp);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_expertosAsignados.Count != 0)
            {
                _todosExpertos.Add((experto)dataGridExpertosAsignados.CurrentRow.DataBoundItem);
                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                _expertosAsignados.Remove((experto)dataGridExpertosAsignados.CurrentRow.DataBoundItem);
                dataGridExpertosAsignados.DataSource = null;
                dataGridExpertosAsignados.DataSource = _expertosAsignados;
            }
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
           // dataGridExpertosDisponibles.Visible = true;
            
            _todosExpertos = _fachada.ObtenerExpertos().ToList();
            dataGridExpertosDisponibles.DataSource = _todosExpertos;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCrearYContinuar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private bool Guardar()
        {
            var bandera = false;
            if ((textBoxNombreProyecto.Text != "") && (textBoxObjetivoProyecto.Text != ""))
            {
                if (_expertosAsignados.Count != 0)
                {
                    proyecto _proyecto = new proyecto { nombre = textBoxNombreProyecto.Text, objetivo = textBoxObjetivoProyecto.Text, id_creador = _experto };
                    proyecto _proyectoAgregado = _fachada.AltaProyecto(_proyecto);

                    _fachada.AsignarExpertosAlProyecto(_proyectoAgregado, _expertosAsignados);

                    ProyectoCreado();

                    MessageBox.Show("El proyecto se ha creado satisfactoriamente.");
                    bandera = true;
                }
                else
                    MessageBox.Show("Debe asignar por lo menos un experto al proyecto.");
            }
            else
                MessageBox.Show("Debe completar los campos Nombre y Objetivo.");

            return bandera;
        }

        private void btnCrearYSalir_Click(object sender, EventArgs e)
        {
            if (Guardar())  
                this.Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombreProyecto.Text = "";
            textBoxObjetivoProyecto.Text = "";
            _todosExpertos.AddRange(_expertosAsignados);

            _expertosAsignados.Clear();
            dataGridExpertosAsignados.DataSource = null;

            dataGridExpertosDisponibles.DataSource = null;
            dataGridExpertosDisponibles.DataSource = _todosExpertos;
        }
    }
}
