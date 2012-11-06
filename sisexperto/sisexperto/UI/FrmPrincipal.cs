﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using CalcularAHP;
using Consistencia;
using Mejora;
using sisExperto.Fachadas;
using sisExperto.UI;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class FrmPrincipal : Form
    {
        private FachadaProyectosExpertos _fachadaProyectosExpertos = new FachadaProyectosExpertos();
        private FachadaEjecucionProyecto _fachadaEjecucionProyectos = new FachadaEjecucionProyecto();

        private Experto _experto;
        private IEnumerable<Proyecto> _proyectosExperto;

        private Proyecto _proyectoSeleccionado;

        private void LoginCorrecto(Experto expert)
        {
            HabilitarGroupbox(true);
            _experto = expert;
            iniciarSesionToolStripMenuItem.Enabled = false;
            cerrarSesionToolStripMenuItem.Enabled = true;
            ActualizarProyectos(expert);
            ActualizarGridProyectos("");
        }

        private void ActualizarProyectos(Experto expert)
        {
            _proyectosExperto = _fachadaProyectosExpertos.SolicitarProyectosCreados(expert);
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            HabilitarGroupbox(false);
            buttonProyectoEdicion.Enabled = false;
            //id_Experto = id_exp;
        }

        private void EjecutarLogin()
        {
            var ventanaLogin = new LogExperto(_fachadaProyectosExpertos);
            ventanaLogin.InicioCorrecto += (LoginCorrecto);
            ventanaLogin.ShowDialog();
        }

        private void NuevoProyecto()
        {
            var ventanaNuevoProyecto = new NuevoProyecto(_fachadaProyectosExpertos, _experto);
            ventanaNuevoProyecto.ProyectoCreado += (ActualizarGridPorProyectoNuevo);
            ventanaNuevoProyecto.ShowDialog();
        }

        private void HabilitarGroupbox(bool bandera)
        {
            groupBoxProyectos.Visible = bandera;
            groupBoxDetalleProyecto.Visible = bandera;
        }

        private void ActualizarGridPorProyectoNuevo()
        {
            ActualizarProyectos(_experto);
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                ActualizarGridProyectos("");
            else
                ActualizarGridProyectos(filtroProyecto.Text);
        }

        private void ActualizarGridProyectos(string filtro)
        {
            var lista1 = (from p in _proyectosExperto
                            where p.Nombre.Contains(filtro) && p.Objetivo.Contains(filtro)
                            select p).ToList();
            var lista2 = (from p in _proyectosExperto
                         where p.Nombre.Contains(filtro) && !p.Objetivo.Contains(filtro)
                         select p).ToList();
            var lista3 = (from p in _proyectosExperto
                          where !p.Nombre.Contains(filtro) && p.Objetivo.Contains(filtro)
                          select p).ToList();

            var lista = lista1;
            lista.AddRange(lista2);
            lista.AddRange(lista3);
            dataGridProyectos.DataSource = lista;

            //dataGridProyectos.Columns["ProyectoId"].Visible = false;
            //dataGridProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridProyectos.BackgroundColor = Color.LightGray;
            //dataGridProyectos.Columns["Nombre"].Width = 150;
            //dataGridProyectos.Columns["Objetivo"].Width = 200;
        }

        /*
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProyecto frmNuevoProyecto = new NuevoProyecto(id_Experto);
            frmNuevoProyecto.ShowDialog();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosCreados frmProyectosCreados = new ProyectosCreados(id_Experto);
            frmProyectosCreados.ShowDialog();
        }

        private void proyectosAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(id_Experto);
            frmProyectosAsignados.ShowDialog();
        }
        */
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            EjecutarLogin();
            dataGridAlternativas.DataSource = new List<Alternativa>();
            dataGridCriterios.DataSource = new List<Criterio>();
            dataGridProyectos.RowEnter += (ActualizarDetalle);
            
            //una forma rebuscada para cargar las dll.
            // con LoadAssembly no lo pude hacer funcionar.

            //var foo1 = new  CalculoAHP();
            //var foo3 = new   Consistencia.Consistencia();
            //var foo4 = new   Mejora.Consistencia();


        }

        private void groupBoxProyectos_Enter(object sender, EventArgs e)
        {
            
        }

        private void filtroProyecto_Leave(object sender, EventArgs e)
        {
            if (filtroProyecto.Text == "")
                filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";            
        }

        private void filtroProyecto_Enter(object sender, EventArgs e)
        {
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                filtroProyecto.Text = "";
        }

        private void filtroProyecto_KeyUp(object sender, KeyEventArgs e)
        {
            ActualizarGridProyectos(filtroProyecto.Text);
            if (filtroProyecto.Text.Length == 0)
            {
                filtroProyecto.Text = "Ingrese los filtros de búsqueda aquí";   
            }
        }

        private void filtroProyecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (filtroProyecto.Text == "Ingrese los filtros de búsqueda aquí")
                filtroProyecto.Text = "";
        }

        private void buttonProyectoNuevo_Click(object sender, EventArgs e)
        {
            NuevoProyecto();
        }

        private void buttonProyectoEdicion_Click(object sender, EventArgs e)
        {
            EditarProyecto _ventanaCargarProyecto = new EditarProyecto(_proyectoSeleccionado, _experto, _fachadaProyectosExpertos);
            _ventanaCargarProyecto.ProyectoModificado += (ActualizarGridPorProyectoNuevo);
            _ventanaCargarProyecto.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(_Experto.ExpertoId);
            //frmProyectosAsignados.ShowDialog();
        }
        
        private void iniciarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EjecutarLogin();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarGroupbox(false);
            _fachadaProyectosExpertos.Experto = null;
            cerrarSesionToolStripMenuItem.Enabled = false;
            iniciarSesionToolStripMenuItem.Enabled = true;
        }

        private void ActualizarDetalle(object sender, DataGridViewCellEventArgs e)
        {
            //int proyecto = 0;
            try
            {                
                _proyectoSeleccionado = (Proyecto)dataGridProyectos.Rows[e.RowIndex].DataBoundItem;

                labelEstadoProyecto.Text = _proyectoSeleccionado.Estado;

                if (_proyectoSeleccionado.Estado == "Creado") buttonProyectoEdicion.Enabled = true;
                else buttonProyectoEdicion.Enabled = false;
            }
            catch (Exception)
            {
                
            }

            try
            {
                dataGridAlternativas.DataSource = (from a in _fachadaProyectosExpertos.SolicitarAlternativas(_proyectoSeleccionado)
                                                   select a).ToList();
            }
            catch (Exception) { dataGridAlternativas.DataSource = new List<Alternativa>(); }

            try
            {
                dataGridCriterios.DataSource = (from c in _fachadaProyectosExpertos.SolicitarCriterios(_proyectoSeleccionado)
                                                select c).ToList();
            }
            catch (Exception) {dataGridCriterios.DataSource = new List<Criterio>();}

            try
            {
                dataGridExpertosAsignados.DataSource = (from ex in _fachadaProyectosExpertos.ExpertosAsignados(_proyectoSeleccionado)
                                                        select ex).ToList();
            }
            catch (Exception) { dataGridExpertosAsignados.DataSource = new List<Experto>(); }            
        }


        private void aHPPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var ventanaPonderacion = new PonderacionExpertos(_fachadaEjecucionProyectos, _proyectoSeleccionado);
            //ventanaPonderacion.ShowDialog();
        }

        private void aHPNoPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }        
    }
}