using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_SolicitudCita : Form
    {
        
        public P_SolicitudCita()
        {
            InitializeComponent();
        }

        public string Usuario = "";
        public P_SolicitudCita(string pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
            CargarDatosEstudiante();
        }
        public void CargarDatosEstudiante()
        {
            DataTable Datos = N_Estudiante.BuscarRegistro(Usuario);
            object[] Fila = Datos.Rows[0].ItemArray;

            txtCodigo.Text = Fila[2].ToString();
            txtEstudiante.Text = Fila[6].ToString();
            txtDireccion.Text = Fila[8].ToString();
            txtTelefono.Text = Fila[9].ToString();
            txtEscuelaP.Text = Fila[11].ToString();
            txtPReferencia.Text = Fila[12].ToString();
            txtTReferencia.Text = Fila[13].ToString();
        }
    }
}
