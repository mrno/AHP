using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace sisexperto
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new CargarProyecto(3));
           //Application.Run(new CompararCriterios(44,35)); 
           Application.Run(new ProyectosAsignados(27));
            //Application.Run(new CargarProyecto(3));
            

        }
    }
}
