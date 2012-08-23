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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mostrar(object sender, EventArgs e)
        {
            TrackBar track = (TrackBar)sender;
            if(track.Name == trackBar1.Name)
                label1.Text = trackBar1.Value.ToString();
            if (track.Name == trackBar2.Name)
                label2.Text = trackBar2.Value.ToString();
            if (track.Name == trackBar3.Name)
                label3.Text = trackBar3.Value.ToString();
            if (track.Name == trackBar4.Name)
                label4.Text = trackBar4.Value.ToString();
            if (track.Name == trackBar5.Name)
                label5.Text = trackBar5.Value.ToString();
            if (track.Name == trackBar6.Name)
                label6.Text = trackBar6.Value.ToString();
            if (track.Name == trackBar7.Name)
                label7.Text = trackBar7.Value.ToString();
            if (track.Name == trackBar8.Name)
                label8.Text = trackBar8.Value.ToString();
            if (track.Name == trackBar9.Name)
                label9.Text = trackBar9.Value.ToString();
            if (track.Name == trackBar10.Name)
                label10.Text = trackBar10.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
