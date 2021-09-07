using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using System.IO;
using System.Drawing.Drawing2D;

namespace CapaPresentaciones
{
    public partial class P_TablaEstudiantes : Form
    {
        readonly E_Estudiante ObjEntidad = new E_Estudiante();
        readonly N_Estudiante ObjNegocio = new N_Estudiante();

        public P_TablaEstudiantes()
        {
            InitializeComponent();        }

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
            dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[4].Visible = false;
            dgvTabla.Columns[5].Visible = false;
            dgvTabla.Columns[10].Visible = false;

            dgvTabla.Columns[1].HeaderText = "";
            dgvTabla.Columns[2].HeaderText = "Cod. Estudiante";
            dgvTabla.Columns[6].HeaderText = "Estudiante";
            dgvTabla.Columns[7].HeaderText = "Email";
            dgvTabla.Columns[8].HeaderText = "Dirección";
            dgvTabla.Columns[9].HeaderText = "Teléfono";
            dgvTabla.Columns[11].HeaderText = "Escuela Profesional";
            dgvTabla.Columns[12].HeaderText = "Persona de Ref.";
            dgvTabla.Columns[13].HeaderText = "Teléfono de Ref.";
            dgvTabla.Columns[14].HeaderText = "Estado Físico";
            dgvTabla.Columns[15].HeaderText = "Estado Mental";
        }

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Estudiante.MostrarRegistros();
            AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvTabla.DataSource = N_Estudiante.BuscarRegistros(txtBuscar.Text);
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

        public static Image HacerImagenCircular(Image img, Color pColor)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gpImg = new GraphicsPath())
            {

                gpImg.AddEllipse(0, 0, img.Width, img.Height);
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    grp.Clear(pColor);
                    grp.SetClip(gpImg);
                    grp.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }

        private void P_TablaEstudiantes_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            P_DatosEstudiante NuevoRegistro = new P_DatosEstudiante();
            NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            NuevoRegistro.ShowDialog();
            NuevoRegistro.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            P_DatosEstudiante EditarRegistro = new P_DatosEstudiante();
            EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);

            if (dgvTabla.SelectedRows.Count > 0)
            {
                Program.Evento = 1;

                byte[] Perfil = new byte[0];
                Perfil = (byte[])dgvTabla.CurrentRow.Cells[0].Value;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);

                EditarRegistro.imgPerfil.Image = Bitmap.FromStream(MemoriaPerfil);
                EditarRegistro.txtCodigo.Text = dgvTabla.CurrentRow.Cells[2].Value.ToString();
                EditarRegistro.txtAPaterno.Text = dgvTabla.CurrentRow.Cells[3].Value.ToString();
                EditarRegistro.txtAMaterno.Text = dgvTabla.CurrentRow.Cells[4].Value.ToString();
                EditarRegistro.txtNombre.Text = dgvTabla.CurrentRow.Cells[5].Value.ToString();
                EditarRegistro.txtDireccion.Text = dgvTabla.CurrentRow.Cells[8].Value.ToString();
                EditarRegistro.txtTelefono.Text = dgvTabla.CurrentRow.Cells[9].Value.ToString();
                EditarRegistro.cxtEscuela.SelectedValue = dgvTabla.CurrentRow.Cells[10].Value.ToString();
                EditarRegistro.txtPReferencia.Text = dgvTabla.CurrentRow.Cells[12].Value.ToString();
                EditarRegistro.txtTReferencia.Text = dgvTabla.CurrentRow.Cells[13].Value.ToString();
                EditarRegistro.txtEFisico.Text = dgvTabla.CurrentRow.Cells[14].Value.ToString();
                EditarRegistro.txtEMental.Text = dgvTabla.CurrentRow.Cells[15].Value.ToString();
                MemoriaPerfil = null;

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
                    ObjEntidad.CodEstudiante = dgvTabla.CurrentRow.Cells[2].Value.ToString();
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

        private void dgvTabla_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Fila in dgvTabla.Rows)
            {
                if (Fila.Selected == true)
                {
                    byte[] Perfil = new byte[0];
                    Perfil = (byte[])Fila.Cells[0].Value;
                    MemoryStream MemoriaPerfil = new MemoryStream(Perfil);

                    Image PerfilImagen = Bitmap.FromStream(MemoriaPerfil);
                    Image PerfilCircular = HacerImagenCircular(PerfilImagen, Color.FromArgb(104, 13, 15));
                    byte[] PerfilFinal = new byte[0];
                    using (MemoryStream MemoriaPerfilFinal = new MemoryStream())
                    {
                        PerfilCircular.Save(MemoriaPerfilFinal, PerfilImagen.RawFormat);
                        PerfilFinal = MemoriaPerfilFinal.ToArray();
                    }

                    Fila.Cells[0].Value = PerfilFinal;
                }
                else
                {
                    byte[] Perfil = new byte[0];
                    Perfil = (byte[])Fila.Cells[0].Value;
                    MemoryStream MemoriaPerfil = new MemoryStream(Perfil);

                    Image PerfilImagen = Bitmap.FromStream(MemoriaPerfil);
                    Image PerfilCircular = HacerImagenCircular(PerfilImagen, Color.White);
                    byte[] PerfilFinal = new byte[0];
                    using (MemoryStream MemoriaPerfilFinal = new MemoryStream())
                    {
                        PerfilCircular.Save(MemoriaPerfilFinal, PerfilImagen.RawFormat);
                        PerfilFinal = MemoriaPerfilFinal.ToArray();
                    }

                    Fila.Cells[0].Value = PerfilFinal;
                }
            }
        }
    }
}
