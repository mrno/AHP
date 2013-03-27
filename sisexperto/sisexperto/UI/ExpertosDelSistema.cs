﻿using sisExperto;
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
        public event Proyectos ProyectoModificado;

        #endregion

        FachadaProyectosExpertos _fachada = new FachadaProyectosExpertos();
        Experto _experto;
        List<Experto> _expertos;

        public ExpertosDelSistema(Experto experto)
        {
            InitializeComponent();
            _experto = experto;
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
            
            
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar el experto seleccionado y todas sus valoraciones?", "Atención", MessageBoxButtons.YesNo);
            if (mensaje.ToString() == "Yes")
            {
                if(experto.Administrador || experto.ProyectosCreados.Count == 0)
                {                
                    var mensaje2 = MessageBox.Show("Está a punto de eliminar un administrador y sus proyectos deben estar a cargo de otro administrador. ¿Desea transferir los proyectos y continuar?", "Atención", MessageBoxButtons.YesNo);
                    switch(mensaje2.ToString())
                    {
                        case "Yes":
                            {
                                // transfiere los proyectos al experto actual
                                _fachada.TransferirProyectos(experto, _experto);
                                if (experto.ProyectosCreados.Count == 0)
                                {
                                    _expertos.Remove(experto);
                                    _fachada.EliminarValoracion(experto);
                                }
                                break; 
                            }
                        case "No": break;
                    }
                    //_expertos.Remove(experto);
                    //_fachada.EliminarValoracion(experto);                    
                }
                else
                {
                    _expertos.Remove(experto);
                    _fachada.EliminarValoracion(experto);
                    _fachada.EliminarExperto(experto);
                    ProyectoModificado();
                    CargarGrid();
                }
            }           
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEliminarValoraciones_Click(object sender, EventArgs e)
        {
            var mensaje = MessageBox.Show("¿Está seguro que desea eliminar todas las valoraciones del experto seleccionado?", "Atención", MessageBoxButtons.YesNo);
            if (mensaje.ToString() == "Yes")
            {
                var experto = dataGridExpertos.SelectedRows[0].DataBoundItem as Experto;
                _fachada.EliminarValoracion(experto);
                ProyectoModificado();
            }
        }
    }
}