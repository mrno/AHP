using System;
using System.Windows.Forms;
using sisExperto.Entidades;

namespace sisExperto
{
    public partial class LogExperto : Form
    {
        #region Delegates

        public delegate void InicioSesion(Experto exp);

        #endregion

        private readonly FachadaProyectosExpertos _fachada;
        private string pass;
        private string user;


        public LogExperto(FachadaProyectosExpertos Fachada)
        {
            InitializeComponent();
            _fachada = Fachada;
        }

        public event InicioSesion InicioCorrecto;

        private void button1_Click(object sender, EventArgs e)
        {
            user = textBoxUsuario.Text;
            pass = textBoxContrasena.Text;
            entrar();
        }

        private void entrar()
        {
            Experto Experto = _fachada.ObtenerExpertoValido(user, pass);
            if (Experto == null)
            {
                labelSesionInv.Visible = true;
            }
            else
            {
                InicioCorrecto(Experto);
                Close();
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Close();
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