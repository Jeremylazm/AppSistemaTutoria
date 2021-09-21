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
            dgvTabla.Columns[6].Visible = false;

            dgvTabla.Columns[1].HeaderText = "Cod. Ficha";
            dgvTabla.Columns[2].HeaderText = "Fecha";
            dgvTabla.Columns[3].HeaderText = "Codigo Estudiante";
            dgvTabla.Columns[4].HeaderText = "Estudiante";
            dgvTabla.Columns[5].HeaderText = "Semestre";
            dgvTabla.Columns[7].HeaderText = "Dimensión";
            dgvTabla.Columns[8].HeaderText = "Descripción";
            dgvTabla.Columns[9].HeaderText = "Referencia";
            dgvTabla.Columns[10].HeaderText = "Observciones";
            
        }
        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_FichaTutoria.MostrarRegistros(E_InicioSesion.Usuario);
            AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvTabla.DataSource = N_FichaTutoria.BuscarRegistros(E_InicioSesion.Usuario, txtBuscar.Text);
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        private void P_TablaTutorias_Load(object sender, EventArgs e)
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
                    ObjEntidad.CodTutoria = dgvTabla.CurrentRow.Cells[0].Value.ToString();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }
    }
}
