using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_TablaTutorias : Form
    {
        readonly E_FichaTutoria ObjEntidad = new E_FichaTutoria();
        readonly N_FichaTutoria ObjNegocio = new N_FichaTutoria();
        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public P_TablaTutorias()
        {
            InitializeComponent();
        }
        public void AccionesTabla()
        {
            dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[4].Visible = false;
            dgvTabla.Columns[5].Visible = false;
            dgvTabla.Columns[13].Visible = false;

            dgvTabla.Columns[1].HeaderText = "";
            dgvTabla.Columns[2].HeaderText = "Cod. Docente";
            dgvTabla.Columns[6].HeaderText = "Docente";
            dgvTabla.Columns[7].HeaderText = "Email";
            dgvTabla.Columns[8].HeaderText = "Dirección";
            dgvTabla.Columns[9].HeaderText = "Teléfono";
            dgvTabla.Columns[10].HeaderText = "Categoría";
            dgvTabla.Columns[11].HeaderText = "Subcategoría";
            dgvTabla.Columns[12].HeaderText = "Régimen";
            dgvTabla.Columns[14].HeaderText = "Escuela Profesional";
            dgvTabla.Columns[15].HeaderText = "Horario";
        }
        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_FichaTutoria.MostrarRegistros(E_InicioSesion.Usuario);
            //AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvTabla.DataSource = N_Docente.BuscarRegistros(E_InicioSesion.Usuario, txtBuscar.Text);
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        private void P_TablaTutorias_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
            
        }
    }
}
