using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_TablaTutorias : Form
    {
        readonly N_Tutoria ObjNegocio = new N_Tutoria();
        readonly E_Tutoria ObjEntidad = new E_Tutoria();
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

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Tutoria.MostrarRegistros();
            
        }

        public void BuscarRegistros()
        {
            dgvTabla.DataSource = N_Tutoria.BuscarRegistros(txtBuscar.Text);
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            P_DatosTutoria FichaTutoria = new P_DatosTutoria();
            FichaTutoria.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            FichaTutoria.ShowDialog();
        }

        private void P_TablaTutorias_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTabla.SelectedRows.Count > 0)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    ObjEntidad.CodDocente = dgvTabla.CurrentRow.Cells[0].Value.ToString();
                    ObjNegocio.EliminarRegistros(ObjEntidad);
                    MensajeConfirmacion("Registro eliminado exitosamente");
                    MostrarRegistros();
                }
            }
            else
            {
                MensajeError("Debe seleccionar una fila");
            }
        }
    }
}
