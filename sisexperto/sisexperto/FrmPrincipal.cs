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
using sisexperto.Fachadas;
using sisexperto.UI;

namespace sisexperto
{
    public partial class FrmPrincipal : Form
    {
        private FachadaProyectosExpertos _fachadaProyectosExpertos = new FachadaProyectosExpertos();
        private FachadaEjecucionProyecto _fachadaEjecucionProyectos = new FachadaEjecucionProyecto();

        private experto _experto;
        private IEnumerable<proyecto> _proyectosExperto;

        private proyecto _proyectoSeleccionado;

        private void LoginCorrecto(experto expert)
        {
            HabilitarGroupbox(true);
            _experto = expert;
            iniciarSesionToolStripMenuItem.Enabled = false;
            cerrarSesionToolStripMenuItem.Enabled = true;
            ActualizarProyectos(expert);
            ActualizarGridProyectos("");
        }

        private void ActualizarProyectos(experto expert)
        {
            _proyectosExperto = _fachadaProyectosExpertos.SolicitarProyectos(expert);
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            HabilitarGroupbox(false);
            //id_experto = id_exp;
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
                            where p.nombre.Contains(filtro) && p.objetivo.Contains(filtro)
                            select new
                            {
                                ProyectoId = p.id_proyecto,
                                Nombre = p.nombre,
                                Objetivo = p.objetivo
                            }).ToList();
            var lista2 = (from p in _proyectosExperto
                         where p.nombre.Contains(filtro) && !p.objetivo.Contains(filtro)
                         select new
                         {
                             ProyectoId = p.id_proyecto,
                             Nombre = p.nombre,
                             Objetivo = p.objetivo
                         }).ToList();
            var lista3 = (from p in _proyectosExperto
                          where !p.nombre.Contains(filtro) && p.objetivo.Contains(filtro)
                          select new
                          {
                              ProyectoId = p.id_proyecto,
                              Nombre = p.nombre,
                              Objetivo = p.objetivo
                          }).ToList();

            var lista = lista1;
            lista.AddRange(lista2);
            lista.AddRange(lista3);
            dataGridProyectos.DataSource = lista;

            dataGridProyectos.Columns["ProyectoId"].Visible = false;
            //dataGridProyectos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridProyectos.BackgroundColor = Color.LightGray;
            //dataGridProyectos.Columns["Nombre"].Width = 150;
            //dataGridProyectos.Columns["Objetivo"].Width = 200;
        }

        /*
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProyecto frmNuevoProyecto = new NuevoProyecto(id_experto);
            frmNuevoProyecto.ShowDialog();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosCreados frmProyectosCreados = new ProyectosCreados(id_experto);
            frmProyectosCreados.ShowDialog();
        }

        private void proyectosAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(id_experto);
            frmProyectosAsignados.ShowDialog();
        }
        */
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            EjecutarLogin();
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
            CargarProyecto frmCargarProyecto = new CargarProyecto(_proyectoSeleccionado);
            frmCargarProyecto.ShowDialog();
            /*
            dataGridProyectos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ProyectosCreados frmProyectosCreados = new ProyectosCreados(_experto.id_experto);
            frmProyectosCreados.ShowDialog();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProyectosAsignados frmProyectosAsignados = new ProyectosAsignados(_experto.id_experto);
            frmProyectosAsignados.ShowDialog();
        }
        
        private void iniciarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            EjecutarLogin();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarGroupbox(false);
            _fachadaProyectosExpertos.experto = null;
            cerrarSesionToolStripMenuItem.Enabled = false;
            iniciarSesionToolStripMenuItem.Enabled = true;
        }

        private void ActualizarDetalle(object sender, DataGridViewCellEventArgs  e)
        {
            int proyecto = 0;
            try
            {
                proyecto = int.Parse(dataGridProyectos.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                
            }
            _proyectoSeleccionado = (from p in _proyectosExperto
                                        where p.id_proyecto == proyecto
                                        select p).FirstOrDefault();

            labelEstadoProyecto.Text = _proyectoSeleccionado.nombre;


            dataGridAlternativas.DataSource = (from a in _fachadaProyectosExpertos.SolicitarAlternativas(_proyectoSeleccionado.id_proyecto)
                                              select new { Nombre = a.nombre, Descripcion = a.descripcion })
                                                  .ToList();
            dataGridCriterios.DataSource = (from a in _fachadaProyectosExpertos.SolicitarCriterios(_proyectoSeleccionado.id_proyecto)
                                            select new { Nombre = a.nombre, Descripcion = a.descripcion })
                                                  .ToList();

            var lista = (from pro in _fachadaProyectosExpertos.ExpertosAsignados(_proyectoSeleccionado)
                         select new { Id = pro.id_experto, Apellido = pro.apellido, Nombre = pro.nombre })
                                                    .ToList();

            dataGridExpertosAsignados.DataSource = lista;
            dataGridExpertosAsignados.Columns["Id"].Visible = false;
        }


        private void aHPPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ventanaPonderacion = new PonderacionExpertos(_fachadaEjecucionProyectos, _proyectoSeleccionado);
            ventanaPonderacion.ShowDialog();
        }

        private void aHPNoPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
