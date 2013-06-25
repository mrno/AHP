﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sisExperto;
using sisExperto.Entidades;

namespace sisexperto.UI.WPFUserControls
{
    public partial class ValorarProyectos : Form
    {
        private Experto _experto;
        private FachadaProyectosExpertos _fachada;
        private List<Proyecto> _listaProyectos = new List<Proyecto>();
        private ExpertoEnProyecto _expertoEnProyecto;
        private Proyecto _proyectoSeleccionado;

        public ValorarProyectos(Experto experto,  Proyecto proyectoSeleccionado, FachadaProyectosExpertos fachada)
        {
            _fachada = fachada;
            InitializeComponent();
            _proyectoSeleccionado = proyectoSeleccionado;
            _experto = experto;
            _expertoEnProyecto = _fachada.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);
            _listaProyectos = _fachada.SolicitarProyectosAsignados(_experto).ToList();
        }

        private void ValorarProyectos_Load(object sender, EventArgs e)
        {
            comboBoxProyectos.DataSource = _listaProyectos;
            comboBoxProyectos.SelectedItem = _proyectoSeleccionado;
            comboBoxProyectos.SelectedIndexChanged += (comboBoxProyectos_SelectedIndexChanged);
            //CargarMatricesYPestanias();
            (elementHost1.Child as ValoracionControl).CargarValoraciones(_proyectoSeleccionado,
                                                                         _expertoEnProyecto.ValoracionAHP,
                                                                         _expertoEnProyecto.ValoracionIL);
        }

        private void comboBoxProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proyectoSeleccionado = (Proyecto)comboBoxProyectos.SelectedItem;
            _expertoEnProyecto = _fachada.SolicitarExpertoProyectoActual(_proyectoSeleccionado, _experto);
            
            (elementHost1.Child as ValoracionControl).CargarValoraciones(_proyectoSeleccionado,
                                                                         _expertoEnProyecto.ValoracionAHP,
                                                                         _expertoEnProyecto.ValoracionIL);
        }
    }
}
