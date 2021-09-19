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
        private void CargarDatos()
        {
            P_TablaTutorados EditarRegistro = new P_TablaTutorados();
            EditarRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            P_TablaTutorados Tutorados=new P_TablaTutorados();
            object[] Fila = Tutorados.Rows[0].ItemArray;

            if (dgvTabla.SelectedRows.Count > 0)
            {
                Program.Evento = 1;

                if (dgvTabla.CurrentRow.Cells[0].Value.GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
                    EditarRegistro.imgPerfil.Image = Image.FromFile(fullImagePath);
                }
                else
                {
                    byte[] Perfil = new byte[0];
                    Perfil = (byte[])dgvTabla.CurrentRow.Cells[0].Value;
                    MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                    EditarRegistro.imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
                    MemoriaPerfil = null;
                }

                EditarRegistro.txtCodigo.Text = dgvTabla.CurrentRow.Cells[2].Value.ToString();
                EditarRegistro.txtAPaterno.Text = dgvTabla.CurrentRow.Cells[3].Value.ToString();
                EditarRegistro.txtAMaterno.Text = dgvTabla.CurrentRow.Cells[4].Value.ToString();
                EditarRegistro.txtNombre.Text = dgvTabla.CurrentRow.Cells[5].Value.ToString();
                EditarRegistro.txtDireccion.Text = dgvTabla.CurrentRow.Cells[8].Value.ToString();
                EditarRegistro.txtTelefono.Text = dgvTabla.CurrentRow.Cells[9].Value.ToString();
                EditarRegistro.cxtEscuela.SelectedValue = dgvTabla.CurrentRow.Cells[10].Value.ToString();
                EditarRegistro.txtPReferencia.Text = dgvTabla.CurrentRow.Cells[12].Value.ToString();
                EditarRegistro.txtTReferencia.Text = dgvTabla.CurrentRow.Cells[13].Value.ToString();
                EditarRegistro.txtIPersonal.Text = dgvTabla.CurrentRow.Cells[14].Value.ToString();

                EditarRegistro.ShowDialog();
            }
            else
            {
                MensajeError("Debe seleccionar una fila");
            }
            EditarRegistro.Dispose();
            txtCodigo.Text = Fila[2].ToString();
            APaterno = Fila[3].ToString();
            AMaterno = Fila[4].ToString();
            Nombre = Fila[5].ToString();
            txtDocente.Text = Fila[6].ToString();
            txtEmail.Text = Fila[7].ToString();
            txtDireccion.Text = Fila[8].ToString();
            txtTelefono.Text = Fila[9].ToString();
            txtCategoria.Text = Fila[10].ToString();
            txtSubcategoria.Text = Fila[11].ToString();
            txtRegimen.Text = Fila[12].ToString();
            CodEscuelaP = Fila[13].ToString();
            txtEscuelaP.Text = Fila[14].ToString();
            txtHorario.Text = Fila[15].ToString();
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
