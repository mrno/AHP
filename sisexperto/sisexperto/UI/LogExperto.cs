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
    public partial class LogExperto : Form
    {
        private FrmPrincipal ventanaOrigen;

        public delegate void InicioSesion(Experto exp);
        public event InicioSesion InicioCorrecto;

        private FachadaProyectosExpertos _fachada;

        public LogExperto(FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _fachada = Fachada;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Experto = _fachada.ObtenerExpertoValido(textBoxUsuario.Text, textBoxContrasena.Text);
            if (Experto == null)
            {
                labelSesionInv.Visible = true;
            }
            else
            {
                InicioCorrecto(Experto);
                this.Close();
            }
        }
        
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxContrasena_Enter(object sender, EventArgs e)
        {
            labelSesionInv.Visible = false;
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            labelSesionInv.Visible = false;
        }

    }
}
