using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sisExperto
{
    public partial class NuevaAlternativa : Form
    {
        private DALDatos dato;
        private int id_proyecto;
        public NuevaAlternativa(int id)
        {
            InitializeComponent();
            id_proyecto = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dato = new DALDatos();
            dato.altaAlternativa(id_proyecto,txt1.Text, txt2.Text);
            this.Close();
        }
    }
}
