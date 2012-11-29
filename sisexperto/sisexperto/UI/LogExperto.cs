using System;
using System.ComponentModel;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Fachadas;

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
            hacerLog();
        }

        private void hacerLog()
        {

            user = textBoxUsuario.Text;
            pass = textBoxContrasena.Text;
            entrar();
        }


        private void CargaProgress(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
   
            progressBar1.TabIndex = 0;
            progressBar1.Maximum = 5;
            progressBar1.Minimum = 1;
            progressBar1.Step = 1;
            
            
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
           // backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.RunWorkerAsync();


        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        

            //foreach (DataRow row in mainTable.Rows)
            //{
            //    auxTable.ImportRow(row);
            //    backgroundWorker1.
            //    backgroundWorker1.ReportProgress(mainTable.Rows.IndexOf(row));
            //}
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //hacerLog();
            progressBar1.Visible = false;

        }


















        private void entrar()
        {

            Object obj = FachadaCalculos.Instance;
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