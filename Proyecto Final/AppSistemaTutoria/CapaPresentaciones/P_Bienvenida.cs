using System;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_Bienvenida : Form
    {
        public P_Bienvenida()
        {
            InitializeComponent();
        }

        private void TiempoAparicion_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;
            ProgresoCircular.Value += 1;
            ProgresoCircular.Text = ProgresoCircular.Value.ToString();
            if (ProgresoCircular.Value == 100)
            {
                TiempoAparicion.Stop();
                TiempoDesaparicion.Start();
            }
        }

        private void TiempoDesaparicion_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                TiempoDesaparicion.Stop();
                this.Close();
            }
        }

        private void P_Bienvenida_Load(object sender, EventArgs e)
        {
            lblDatos.Text = E_InicioSesion.Datos;
            this.Opacity = 0.0;
            ProgresoCircular.Value = 0;
            ProgresoCircular.Minimum = 0;
            ProgresoCircular.Maximum = 100;
            TiempoAparicion.Start();
        }
    }
}
