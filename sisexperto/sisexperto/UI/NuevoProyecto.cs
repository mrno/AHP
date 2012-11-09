using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class NuevoProyecto : Form
    {
        public delegate void Proyectos();
        public event Proyectos ProyectoCreado;
        
        private List<Experto> _ExpertosAsignados = new List<Experto>();
        private List<Experto> _todosExpertos = new List<Experto>();

        private Experto _Experto;

        private FachadaProyectosExpertos _fachada;

        public NuevoProyecto(FachadaProyectosExpertos Fachada, Experto Experto)
        {
            InitializeComponent();
            labelNombreExperto.Text = string.Format("{0}, {1}", Experto.Apellido.ToUpper(), Experto.Nombre);
            _Experto = Experto;
            _fachada = Fachada;
        }

        private void AsignarExperto(Experto exp)
        {
            _ExpertosAsignados.Add(exp);
            ActualizarGridExpertosAsignados();
        }

        private void ActualizarGridExpertosAsignados()
        {
            dataGridExpertosAsignados.DataSource = null;
            var lista = _ExpertosAsignados;
            lista.Reverse();
            dataGridExpertosAsignados.DataSource = lista; 
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var ventanaCrearExperto = new CrearExperto(_fachada);
            ventanaCrearExperto.ExpertoAgregado += (AsignarExperto);
            ventanaCrearExperto.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_todosExpertos.Count > 0)
            {
                Experto exp = (Experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem;
                //acá puede que vaya exp nomás
                _todosExpertos.Remove((Experto)dataGridExpertosDisponibles.CurrentRow.DataBoundItem);

                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                AsignarExperto(exp);
            }
            btnQuitar.Enabled = true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_ExpertosAsignados.Count != 0)
            {
                _todosExpertos.Add((Experto)dataGridExpertosAsignados.CurrentRow.DataBoundItem);
                dataGridExpertosDisponibles.DataSource = null;
                dataGridExpertosDisponibles.DataSource = _todosExpertos;

                _ExpertosAsignados.Remove((Experto)dataGridExpertosAsignados.CurrentRow.DataBoundItem);
                dataGridExpertosAsignados.DataSource = null;
                dataGridExpertosAsignados.DataSource = _ExpertosAsignados;
            }
            if (_ExpertosAsignados.Count == 0)
                btnQuitar.Enabled = false;
        }

        private void NuevoProyecto_Load(object sender, EventArgs e)
        {
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
                if (_ExpertosAsignados.Count != 0)
                {
                    Proyecto _proyecto = new Proyecto { Nombre = textBoxNombreProyecto.Text, Objetivo = textBoxObjetivoProyecto.Text, Creador = _Experto, Estado = "Creado", TipoProyecto = comboBoxTipoModelo.SelectedIndex};
                    
                    _fachada.AsignarExpertosAlProyecto(_proyecto, _ExpertosAsignados);
                    _fachada.AltaProyecto(_proyecto);
                    ProyectoCreado();

                    MessageBox.Show("El proyecto se ha creado satisfactoriamente.");
                    bandera = true;
                }
                else
                    MessageBox.Show("Debe asignar por lo menos un Experto al proyecto.");
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
            _todosExpertos.AddRange(_ExpertosAsignados);
           // comboBoxTipoModelo.SelectedItem = null;
            _ExpertosAsignados.Clear();
            dataGridExpertosAsignados.DataSource = null;

            dataGridExpertosDisponibles.DataSource = null;
            dataGridExpertosDisponibles.DataSource = _todosExpertos;
        }
    }
}
