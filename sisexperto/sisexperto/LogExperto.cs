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
    public partial class LogExperto : Form
    {
        private FrmPrincipal ventanaOrigen;

        public event FrmPrincipal.InicioSesion InicioCorrecto;

        private FachadaSistema _fachada;

        public LogExperto(FachadaSistema Fachada)
        {
            InitializeComponent();
            _fachada = Fachada;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var experto = _fachada.ValidarExperto(textBoxUsuario.Text, textBoxContrasena.Text);
            if (experto.nom_usuario == null)
            {
                labelSesionInv.Visible = true;
            }
            else
            {
                InicioCorrecto(experto);
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
