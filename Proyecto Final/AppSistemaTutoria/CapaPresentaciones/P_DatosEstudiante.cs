using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

using System.Net;
using System.Net.Mail;

namespace CapaPresentaciones
{
    public partial class P_DatosEstudiante : Form
    {
        readonly E_Estudiante ObjEntidad = new E_Estudiante();
        readonly N_Estudiante ObjNegocio = new N_Estudiante();
        private readonly string Key = "key_estudiante"; //Llave de cifrado

        public P_DatosEstudiante()
        {
            InitializeComponent();
            LlenarComboBox();
            ValidarPerfil();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LimpiarCajas()
        {
            txtCodigo.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtPReferencia.Clear();
            txtTReferencia.Clear();
            txtCodigo.Focus();
        }

        private void ValidarPerfil()
        {
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
            if (imgPerfil.Image == Image.FromFile(fullImagePath))
            {
                btnRestablecerPerfil.Visible = false;
            }
        }

        private void LlenarComboBox()
        {
            if (E_InicioSesion.Acceso == "Administrador")
            {
                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarRegistros();
                cxtEscuela.ValueMember = "CodEscuelaP";
                cxtEscuela.DisplayMember = "Nombre";
            }
            else
            {

            }
        }
        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            LlenarComboBox();
        }

        string VisibilidadIPersonal(string IPersonalCifrada, bool EsEstudiante = false)
        {
            //Mostrar o no la información personal de acuerdo al permiso otorgado

            //Verificar permiso de visibilidad
            string Permiso = IPersonalCifrada.Substring(IPersonalCifrada.Length - 4);
            IPersonalCifrada = IPersonalCifrada.Substring(0, IPersonalCifrada.Length - 5); //Eliminar string permiso

            //Si el usuario es estudiante, puede ver su inf personal
            if (EsEstudiante)
            {
                return E_Criptografia.DesencriptarRSA(IPersonalCifrada, Key); //Desencriptar
            }

            //Si Tutor tiene permiso de visualizar Inf Personal
            if (Permiso == "VT=T")
            {
                return E_Criptografia.DesencriptarRSA(IPersonalCifrada, Key); //Desencriptar
            }
            else return IPersonalCifrada; //No desencriptar
        }

        string EncriptarIPersonal(string IPersonal, bool PermisoVisibilidad)
        {
            //Encriptar
            string IPersonalCifrada = E_Criptografia.EncriptarRSA(IPersonal, Key);
            //Añadir permiso
            if (PermisoVisibilidad) IPersonalCifrada += " VT=T";
            else IPersonalCifrada += " VT=F";
            return IPersonalCifrada;
        }

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((txtCodigo.Text.Trim() != "") &&
                (txtAPaterno.Text.Trim() != "") &&
                (txtAMaterno.Text.Trim() != "") &&
                (txtNombre.Text.Trim() != "") &&
                (txtDireccion.Text.Trim() != "") &&
                (txtTelefono.Text.Trim() != ""))
            {
                if (Program.Evento == 0)
                {
                    try
                    {
                        byte[] Perfil = new byte[0];
                        using (MemoryStream MemoriaPerfil = new MemoryStream())
                        {
                            imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                            Perfil = MemoriaPerfil.ToArray();
                        }
                        ObjEntidad.Perfil = Perfil;
                        ObjEntidad.CodEstudiante = txtCodigo.Text;
                        ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
                        ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
                        ObjEntidad.Nombre = txtNombre.Text.ToUpper();
                        ObjEntidad.Email = txtCodigo.Text + "@unsaac.edu.pe";
                        ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                        ObjEntidad.Telefono = txtTelefono.Text;
                        ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
                        ObjEntidad.PersonaReferencia = txtPReferencia.Text.ToUpper();
                        ObjEntidad.TelefonoReferencia = txtTReferencia.Text;
                        ObjEntidad.InformacionPersonal = EncriptarIPersonal(txtIPersonal.Text,false);

                        ObjNegocio.InsertarRegistros(ObjEntidad);
                        MensajeConfirmacion("Registro insertado exitosamente");
                        Program.Evento = 0;

                        N_InicioSesion InicioSesion = new N_InicioSesion();
                        string Contrasena = InicioSesion.RetornarContrasena(txtCodigo.Text);

                        // Enviar un correo con la contraseña para un nuevo usuario
                        try
                        {
                            SmtpClient clientDetails = new SmtpClient();
                            clientDetails.Port = 587;
                            clientDetails.Host = "smtp.gmail.com";
                            clientDetails.EnableSsl = true;
                            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                            clientDetails.UseDefaultCredentials = false;
                            clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

                            MailMessage mailDetails = new MailMessage();
                            mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
                            mailDetails.To.Add(ObjEntidad.Email);
                            mailDetails.Subject = "Contraseña del Sistema de Tutoría UNSAAC";
                            mailDetails.IsBodyHtml = true;
                            mailDetails.Body = "Tu contraseña es " + Contrasena;
                            clientDetails.Send(mailDetails);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        LimpiarCajas();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al insertar el registro " + ex);
                    }
                }
                else
                {
                    try
                    {
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
                            ObjEntidad.Perfil = Perfil;
                            ObjEntidad.CodEstudiante = txtCodigo.Text;
                            ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
                            ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
                            ObjEntidad.Nombre = txtNombre.Text.ToUpper();
                            ObjEntidad.Email = txtCodigo.Text + "@unsaac.edu.pe";
                            ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                            ObjEntidad.Telefono = txtTelefono.Text;
                            ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
                            ObjEntidad.PersonaReferencia = txtPReferencia.Text.ToUpper();
                            ObjEntidad.TelefonoReferencia = txtTReferencia.Text;
                            ObjEntidad.InformacionPersonal = EncriptarIPersonal(txtIPersonal.Text, false);

                            ObjNegocio.EditarRegistros(ObjEntidad);
                            MensajeConfirmacion("Registro editado exitosamente");
                            Program.Evento = 0;
                            LimpiarCajas();
                            Close();
                        }
                    }
                    catch (Exception)
                    {
                        MensajeError("Error al editar el registro");
                    }
                }
            }
            else
            {
                MensajeError("Debe llenar los campos");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.Evento = 0;
            Close();
        }

        private void btnEscuelas_Click(object sender, EventArgs e)
        {
            //P_Ciudades NuevoRegistro = new P_Ciudades();
            //NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            //NuevoRegistro.ShowDialog();
            //NuevoRegistro.Dispose();
        }

        public Image HacerImagenCircular(Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);
            //int r = x;

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
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
            imgPerfil.Image = Image.FromFile(fullImagePath);
        }

        #endregion
    }
}
