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

        public LogExperto(FrmPrincipal ventana)
        {
            InitializeComponent();
            ventanaOrigen = ventana;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var experto = ventanaOrigen.Fachada.ValidarExperto(textBoxUsuario.Text, textBoxContrasena.Text);
            if (experto == null)
            {

            }
            else
            {
                ventanaOrigen.Experto = experto;
                this.Close();
            }
        }


        private void LogExperto_FormClosed(object sender, FormClosedEventArgs e)
        {/*
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ventanaOrigen.Dispose();
            }
            else
            {
                
            }*/
        }
    }
}
