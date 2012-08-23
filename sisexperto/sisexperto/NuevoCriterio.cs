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
    public partial class NuevoCriterio : Form
    {
        private DALDatos dato;
        private int id_proyecto;
        public NuevoCriterio(int id)
        {
            InitializeComponent();
            id_proyecto = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dato = new DALDatos();
            dato.altaCriterio(id_proyecto, txt1.Text, txt2.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
