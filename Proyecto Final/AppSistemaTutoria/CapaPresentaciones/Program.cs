using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapaPresentaciones
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        public static int Evento = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new P_InicioSesion());
            //Application.Run(new P_Menu());

            //string Ruta = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath));
            //MessageBox.Show(Ruta);
        }
    }
}