using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using sisExperto.Entidades;
using sisexperto.Entidades;
using sisexperto.Fachadas;
using sisexperto.UI;
using sisexperto.Entidades.AHP;

namespace sisExperto
{
    public partial class CompararCriterios : Comparacion
    {

        public CompararCriterios(CriterioMatriz matriz, FachadaProyectosExpertos facha, Proyecto proy) : base(matriz, facha, proy)
        {
            _listaElementosAComparar = proy.Criterios;
        }

        
        public override void MoverTrack(object sender, EventArgs e)
        {
            var track = (TrackBar) sender;
            var _matrizCriterio = (CriterioMatriz)_matriz;
            foreach (Control miLabel in panelComparacion.Controls)
            {
                if (miLabel is Label)
                {
                    if (miLabel.Name == track.Name)
                    {
                        string[] posicion = track.Name.Split('x');
                        var l = (Label) miLabel;
                        l.Text = valorarPalabra(track.Value);

                        foreach (CriterioFila fila in _matrizCriterio.FilasCriterio)
                        {
                            foreach (CriterioCelda celda in fila.CeldasCriterios)
                            {
                                if ((celda.Fila == Convert.ToInt32(posicion[0])) &&
                                    (celda.Columna == Convert.ToInt32(posicion[1])))
                                {
                                    //1
                                    celda.Valor = valorarNumero(track.Value);

                                    //2
                                    //GuardarConsistencia();    puede ser esa opción también.
                                    _matrizCriterio.Consistencia = false;

                                    _fachada.GuardarValoracion();
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void OnLoad(object sender, EventArgs e)
        {
            label19.Text = "Comparación de Criterios";

            int y = 140;
            var matrizCriterio = (CriterioMatriz)_matriz;

            foreach (CriterioFila fila in matrizCriterio.FilasCriterio)
            {
                foreach (CriterioCelda celda in fila.CeldasCriterios)
                {
                    GenerarTracks(fila.Criterio, celda.Fila, celda.Criterio, celda.Columna, celda.Valor, y);
                    y += 90;
                }
            }
        }            
    }
}