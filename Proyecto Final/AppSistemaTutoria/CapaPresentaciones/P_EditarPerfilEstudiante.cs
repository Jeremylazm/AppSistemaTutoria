using CapaEntidades;
using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        private readonly string Key = "key_estudiante"; //Llave de cifrado

        public P_EditarPerfilEstudiante()
        {
            InitializeComponent();
        }

        private void CargarDatosUsuario()
        {
            DataTable Datos = N_Estudiante.BuscarRegistro(Usuario);
            object[] Fila = Datos.Rows[0].ItemArray;

            if (E_InicioSesion.Perfil == null)
            {
                imgPerfil.Image = Properties.Resources.Perfil_Estudiante as Image;
            }
            else
            {
                byte[] Perfil = new byte[0];
                Perfil = E_InicioSesion.Perfil;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
            }
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

            bool permiso = Fila[16].Equals("SÍ"); //Si se tiene el permiso de ver la inf. personal
            if (Fila[14].ToString() != "")
                txtIPersonal.Text = VisibilidadIPersonal(Fila[14].ToString(), permiso, true);  //Desencriptar  informacion personal
            else
                txtIPersonal.Text = "";

            if (permiso)
                ckbIPersonal.Checked = true;
            else
                ckbIPersonal.Checked = false;
            //txtEFisico.Text = Fila[14].ToString();
            //txtEMental.Text = Fila[15].ToString();


        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Image HacerImagenCircular(Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);

            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }
            return tmp;
        }

        string VisibilidadIPersonal(string IPersonalCifrada, bool Permiso, bool EsEstudiante = false)
        {
            //Mostrar o no la información personal de acuerdo al permiso otorgado

            //Verificar permiso de visibilidad
            if (EsEstudiante) return E_Criptografia.DesencriptarRSA(IPersonalCifrada, Key);//Encriptar
            if (Permiso) return E_Criptografia.DesencriptarRSA(IPersonalCifrada, Key);//Encriptar
            else return IPersonalCifrada; //No desencriptar
        }

        #region Eventos
        private void btnSubirPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Archivo = new OpenFileDialog();
                Archivo.Filter = "Archivos de Imagen | *.jpg; *.jpeg; *.png; *.gif; *.tif";
                Archivo.Title = "Subir Perfil";

                if (Archivo.ShowDialog() == DialogResult.OK)
                {
                    imgPerfil.Image = HacerImagenCircular(Image.FromFile(Archivo.FileName));
                }
            }
            catch (Exception)
            {
                MensajeError("Error al subir perfil");
            }
        }

        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            imgPerfil.Image = Properties.Resources.Perfil_Estudiante as Image;
        }

        private void P_EditarPerfilEstudiante_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Trim() != "")
            {
                Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");
                Regex PatronTelefonoReferencia = new Regex(@"\A([0-9]{9}\Z)|(^$)");

                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    byte[] Perfil = new byte[0];
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                        Perfil = MemoriaPerfil.ToArray();
                    }
                    E_InicioSesion.Perfil = Perfil;
                    ObjEntidad.Perfil = Perfil;
                    ObjEntidad.CodEstudiante = txtCodigo.Text;
                    ObjEntidad.APaterno = APaterno;
                    ObjEntidad.AMaterno = AMaterno;
                    ObjEntidad.Nombre = Nombre;
                    ObjEntidad.Email = txtCodigo.Text + "@unsaac.edu.pe";
                    ObjEntidad.Direccion = txtDireccion.Text.ToUpper();

                    if (!PatronTelefono.IsMatch(txtTelefono.Text))
                    {
                        MensajeError("El teléfono deber ser de 9 caracteres numéricos");
                    }
                    else
                    {
                        ObjEntidad.Telefono = txtTelefono.Text;
                        ObjEntidad.CodEscuelaP = CodEscuelaP;
                        ObjEntidad.PersonaReferencia = txtPReferencia.Text.ToUpper();

                        if (!PatronTelefonoReferencia.IsMatch(txtTReferencia.Text))
                        {
                            MensajeError("El teléfono de referencia deber ser de 9 caracteres numéricos");
                        }
                        else
                        {
                            ObjEntidad.TelefonoReferencia = txtTReferencia.Text;
                            //Encriptar 
                            if (txtIPersonal.Text.Trim() != "") //Si es distinto de vacio, encriptar
                                ObjEntidad.InformacionPersonal = E_Criptografia.EncriptarRSA(txtIPersonal.Text, Key);
                            else //No se encripta
                                ObjEntidad.InformacionPersonal = ""; //Guardar caracter vacio


                            //Guardar estado del permiso
                            if (ckbIPersonal.Checked)
                                ObjEntidad.ConcederPermiso = "SÍ";
                            else
                                ObjEntidad.ConcederPermiso = "NO";

                            ObjNegocio.EditarRegistros(ObjEntidad);
                            MensajeConfirmacion("Registro editado exitosamente");
                        }
                    }
                }
            }
            else
            {
                MensajeError("Debe llenar el teléfono");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Warning si desea cerrar el formulario sin guardar cambias
            string msg = "¿Está seguro que desea cerrar?";
            string titulo = "Cerrando formulario";
            var result = MessageBox.Show(msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Si le da al boton si, cerrar formulario
            if (result == DialogResult.Yes) Close();
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            P_CambiarContraseña NuevaContraseña = new P_CambiarContraseña
            {
                Usuario = E_InicioSesion.Usuario,
                Correo = E_InicioSesion.Usuario + "@unsaac.edu.pe"
            };
            NuevaContraseña.ShowDialog();
            NuevaContraseña.Dispose();
        }
        #endregion
    }
}
