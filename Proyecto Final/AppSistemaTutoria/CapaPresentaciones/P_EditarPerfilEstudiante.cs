using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_EditarPerfilEstudiante : Form
    {
        readonly E_Estudiante ObjEntidad = new E_Estudiante();
        readonly N_Estudiante ObjNegocio = new N_Estudiante();

        public string Usuario = "";
        private string APaterno = "";
        private string AMaterno = "";
        private string Nombre = "";
        private string CodEscuelaP = "";

        public P_EditarPerfilEstudiante()
        {
            InitializeComponent();
        }

        private void CargarDatosUsuario()
        {
            DataTable Datos = N_Estudiante.BuscarRegistros(Usuario);
            object[] Fila = Datos.Rows[0].ItemArray;

            byte[] Perfil = new byte[0];
            Perfil = E_InicioSesion.Perfil;
            MemoryStream MemoriaPerfil = new MemoryStream(Perfil);

            imgPerfil.Image = Bitmap.FromStream(MemoriaPerfil);
            txtCodigo.Text = Fila[2].ToString();
            APaterno = Fila[3].ToString();
            AMaterno = Fila[4].ToString();
            Nombre = Fila[5].ToString();
            txtEstudiante.Text = Fila[6].ToString();
            txtDireccion.Text = Fila[8].ToString();
            txtTelefono.Text = Fila[9].ToString();
            CodEscuelaP = Fila[10].ToString();
            txtEscuelaP.Text = Fila[11].ToString();
            txtPReferencia.Text = Fila[12].ToString();
            txtTReferencia.Text = Fila[13].ToString();
            txtEFisico.Text = Fila[14].ToString();
            txtEMental.Text = Fila[15].ToString();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSubirPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Archivo = new OpenFileDialog();
                Archivo.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                Archivo.Title = "Subir Perfil";

                if (Archivo.ShowDialog() == DialogResult.OK)
                {
                    imgPerfil.Image = Image.FromFile(Archivo.FileName);
                }
            }
            catch (Exception)
            {
                MensajeError("Error al subir perfil");
            }
        }

        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            imgPerfil.Image = Image.FromFile("C:/Users/Jeremylazm/Desktop/Documentos/AppSistemaTutoria/CapaPresentaciones/Iconos/Perfil Estudiante.png");
        }

        private void P_EditarPerfilEstudiante_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Opcion == DialogResult.OK)
            {
                byte[] Perfil = new byte[0];
                using (MemoryStream MemoriaPerfil = new MemoryStream())
                {
                    imgPerfil.Image.Save(MemoriaPerfil, imgPerfil.Image.RawFormat);
                    Perfil = MemoriaPerfil.ToArray();
                }
                ObjEntidad.Perfil = Perfil;
                ObjEntidad.CodEstudiante = txtCodigo.Text;
                ObjEntidad.APaterno = APaterno;
                ObjEntidad.AMaterno = AMaterno;
                ObjEntidad.Nombre = Nombre;
                ObjEntidad.Email = txtCodigo.Text + "@unsaac.edu.pe";
                ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                ObjEntidad.Telefono = txtTelefono.Text;
                ObjEntidad.CodEscuelaP = CodEscuelaP;
                ObjEntidad.PersonaReferencia = txtPReferencia.Text.ToUpper();
                ObjEntidad.TelefonoReferencia = txtTReferencia.Text;
                ObjEntidad.EstadoFisico = txtEFisico.Text.ToUpper();
                ObjEntidad.EstadoMental = txtEMental.Text.ToUpper();

                ObjNegocio.EditarRegistros(ObjEntidad);
                MensajeConfirmacion("Registro editado exitosamente");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
