using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_DatosTutoria : Form
    {
        //readonly E_Estudiante ObjEntidad = new E_Estudiante();
        //readonly N_Estudiante ObjNegocio = new N_Estudiante();
        private DataTable DTTutorias;
        
        readonly N_Tutoria ObjNegocio = new N_Tutoria();
        readonly E_Tutoria ObjEntidad = new E_Tutoria();
        public P_DatosTutoria()
        {
            InitializeComponent();
        }
        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LlenarComboBox()
        {
            cxtEscuela.SelectedIndex = 0;
        }
        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            LlenarComboBox();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }
    }
}
