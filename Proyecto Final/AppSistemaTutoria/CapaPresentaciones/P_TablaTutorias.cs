using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_TablaTutorias : Form
    {
        public P_TablaTutorias()
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
        public void AccionesTabla()
        {
            /*dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[4].Visible = false;
            dgvTabla.Columns[5].Visible = false;
            dgvTabla.Columns[10].Visible = false;
            dgvTabla.Columns[15].Visible = false;
            dgvTabla.Columns[16].Visible = false;

            dgvTabla.Columns[1].HeaderText = "";
            dgvTabla.Columns[2].HeaderText = "Cod. Estudiante";
            dgvTabla.Columns[6].HeaderText = "Estudiante";
            dgvTabla.Columns[7].HeaderText = "Email";
            
            dgvTabla.Columns[8].HeaderText = "Dirección";
            dgvTabla.Columns[9].HeaderText = "Teléfono";
            dgvTabla.Columns[11].HeaderText = "Escuela Profesional";
            dgvTabla.Columns[12].HeaderText = "Persona de Ref.";
            dgvTabla.Columns[13].HeaderText = "Teléfono de Ref.";
            dgvTabla.Columns[14].HeaderText = "Información Personal";*/
            dgvTabla.Columns[0].HeaderText = "Cod. Tutoria";
            
            
        }

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Tutoria.MostrarRegistros();
            AccionesTabla();
        }

        private void P_TablaTutorias_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
    }
}
