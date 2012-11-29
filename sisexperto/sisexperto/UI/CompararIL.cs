using System;
using System.Windows.Forms;
using sisExperto;
using sisExperto.Entidades;
using sisexperto.Entidades;


namespace sisexperto.UI
{
    public partial class CompararIL : Form
    {
        private readonly Proyecto _proyecto;
        private readonly Experto _experto;
        private readonly ExpertoEnProyecto _expertoEnProyecto;
        private readonly FachadaProyectosExpertos miFachada;


        public CompararIL(FachadaProyectosExpertos facha, Proyecto proy)
        {
            InitializeComponent();
            miFachada = facha;
            _proyecto = proy;
            _experto = facha.Experto;
            _expertoEnProyecto = miFachada.SolicitarExpertoProyectoActual(_proyecto, _experto);

        }



        public void CompararIL_load(object sender, EventArgs e)
        {
            //    int y = 140;

            //    foreach (CriterioFila fila in matrizCriterio.FilasCriterio)
            //    {
            //        foreach (CriterioCelda celda in fila.CeldasCriterios)
            //        {
            //            //listaCeldas.Add(celda);

            //            var izquierdaTB = new Label();
            //            izquierdaTB.SetBounds(5, y, 75, 50);
            //            izquierdaTB.Text = fila.Criterio.Nombre;
            //            Controls.Add(izquierdaTB);

            //            var track = new TrackBar();
            //            track.SetBounds(75, y, 400, 45);
            //            track.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
            //            track.SetRange(1, 17);
            //            track.Value = valorarDoble(celda.ValorAHP);
            //            track.Scroll += mostrar;
            //            Controls.Add(track);


            //            var derechaTB = new Label();
            //            derechaTB.SetBounds(500, y, 80, 30);
            //            derechaTB.Text = celda.Criterio.Nombre;
            //            Controls.Add(derechaTB);

            //            var miLabel = new Label();
            //            miLabel.SetBounds(150, y + 45, 250, 30);
            //            //    double doble = dato.obtenerValorCompCriterio(comp.id_proyecto, comp.id_Experto, comp.pos_fila,
            //            //                                                  comp.pos_columna);
            //            miLabel.Text = valorarPalabra(track.Value);
            //            miLabel.Name = celda.Fila.ToString() + 'x' + celda.Columna.ToString();
            //            Controls.Add(miLabel);

            //            y += 90;
            //        }
            //    }
            //}
        }
    } 
}
