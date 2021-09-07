using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_TablaDocentes : Form
    {
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();

        public P_TablaDocentes()
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
            dgvTabla.Columns[1].Visible = false;
            dgvTabla.Columns[2].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[11].Visible = false;

            dgvTabla.Columns[0].HeaderText = "Cod. Docente";
            dgvTabla.Columns[4].HeaderText = "Docente";
            dgvTabla.Columns[5].HeaderText = "Email";
            dgvTabla.Columns[6].HeaderText = "Dirección";
            dgvTabla.Columns[7].HeaderText = "Teléfono";
            dgvTabla.Columns[8].HeaderText = "Categoría";
            dgvTabla.Columns[9].HeaderText = "Subcategoría";
            dgvTabla.Columns[10].HeaderText = "Régimen";
            dgvTabla.Columns[12].HeaderText = "Escuela Profesional";
            dgvTabla.Columns[13].HeaderText = "Estado";
        }

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Docente.MostrarRegistros();
            AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvTabla.DataSource = N_Docente.BuscarRegistros(txtBuscar.Text);
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        private void ExportarDatos(DataGridView Datos)
        {
            Microsoft.Office.Interop.Excel.Application ArchivoExcel = new Microsoft.Office.Interop.Excel.Application();
            ArchivoExcel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;

            foreach (DataGridViewColumn Columna in Datos.Columns)
            {
                IndiceColumna++;
                ArchivoExcel.Cells[1, IndiceColumna] = Columna.Name;
            }

            int IndiceFila = 0;

            foreach (DataGridViewRow Fila in Datos.Rows)
            {
                IndiceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn Columna in Datos.Columns)
                {
                    IndiceColumna++;
                    ArchivoExcel.Cells[IndiceFila + 1, IndiceColumna] = Fila.Cells[Columna.Name].Value;
                }
            }

            ArchivoExcel.Visible = true;
        }

        private void P_TablaDocentes_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            P_DatosDocente NuevoRegistro = new P_DatosDocente();
            NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistro.ShowDialog();
            NuevoRegistro.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            P_DatosDocente EditarRegistro = new P_DatosDocente();
            EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

            if (dgvTabla.SelectedRows.Count > 0)
            {
                Program.Evento = 1;
                EditarRegistro.txtCodigo.Text = dgvTabla.CurrentRow.Cells[0].Value.ToString();
                EditarRegistro.txtAPaterno.Text = dgvTabla.CurrentRow.Cells[1].Value.ToString();
                EditarRegistro.txtAMaterno.Text = dgvTabla.CurrentRow.Cells[2].Value.ToString();
                EditarRegistro.txtNombre.Text = dgvTabla.CurrentRow.Cells[3].Value.ToString();
                EditarRegistro.txtEmail.Text = dgvTabla.CurrentRow.Cells[5].Value.ToString().Substring(0, dgvTabla.CurrentRow.Cells[5].Value.ToString().Length - 14);
                EditarRegistro.txtDireccion.Text = dgvTabla.CurrentRow.Cells[6].Value.ToString();
                EditarRegistro.txtTelefono.Text = dgvTabla.CurrentRow.Cells[7].Value.ToString();
                EditarRegistro.cxtCategoria.SelectedValue = dgvTabla.CurrentRow.Cells[8].Value.ToString();
                EditarRegistro.cxtSubcategoria.SelectedValue = dgvTabla.CurrentRow.Cells[9].Value.ToString();
                EditarRegistro.cxtRegimen.SelectedValue = dgvTabla.CurrentRow.Cells[10].Value.ToString();
                EditarRegistro.cxtEscuela.SelectedValue = dgvTabla.CurrentRow.Cells[11].Value.ToString();
                EditarRegistro.cxtEstado.SelectedValue = dgvTabla.CurrentRow.Cells[13].Value.ToString();

                EditarRegistro.ShowDialog();
            }
            else
            {
                MensajeError("Debe seleccionar una fila");
            }
            EditarRegistro.Dispose();
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatos(dgvTabla);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }
    }
}
