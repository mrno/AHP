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
<<<<<<< HEAD
            
            Application.Run(new LogExperto());
=======
           //Application.Run(new CompararCriterios(44,35)); 
           //Application.Run(new ProyectosAsignados(35));
            //Application.Run(new CargarProyecto(3));
            Application.Run(new FrmPrincipal());
          //  Application.Run(new ComparacionAlternativas(4, 49));
>>>>>>> d391684372151a03e4006dbcfc305285925322da
           
           

        }
    }
}
