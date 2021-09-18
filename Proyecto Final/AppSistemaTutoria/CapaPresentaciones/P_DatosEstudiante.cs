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
using System.Text.RegularExpressions;

namespace CapaPresentaciones
{
    public partial class P_DatosEstudiante : Form
    {
        readonly E_Estudiante ObjEntidad = new E_Estudiante();

        public bool Test { get; set; }

        private readonly string Key = "key_estudiante"; //Llave de cifrado

        public P_DatosEstudiante()
        {
            Test = false;
            InitializeComponent();
            LlenarComboBox();
            ValidarPerfil();
        }

        public P_DatosEstudiante(bool pTest) 
        {
            Test = pTest;
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
            }
            else
            {
                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarRegistros(E_InicioSesion.Usuario);
                cxtEscuela.Enabled = false;
            }

            cxtEscuela.ValueMember = "CodEscuelaP";
            cxtEscuela.DisplayMember = "Nombre";
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

        public string AgregarOModificar(Image Perfil, string Codigo, string APaterno, string AMaterno, string Nombre, 
                                 string Email, string Direccion, string Telefono, string CodEscuelaP, 
                                 string PesonaReferencia, string TelefonoReferencia, string InformacionPersonal)
        {
            string Mensaje = "";

            if ((Codigo.Trim() != "") &&
                (APaterno.Trim() != "") &&
                (AMaterno.Trim() != "") &&
                (Nombre.Trim() != "") &&
                (Direccion.Trim() != "") &&
                (Telefono.Trim() != ""))
            {
                Regex PatronCodigo = new Regex(@"\A[0-9]{6}\Z");
                Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");
                Regex PatronTelefonoReferencia = new Regex(@"\A([0-9]{9}\Z)|(^$)");

                if (Program.Evento == 0)
                {
                    try
                    {
                        byte[] PerfilArray = new byte[0];
                        using (MemoryStream MemoriaPerfil = new MemoryStream())
                        {
                            Perfil.Save(MemoriaPerfil, ImageFormat.Bmp);
                            PerfilArray = MemoriaPerfil.ToArray();
                        }
                        ObjEntidad.Perfil = PerfilArray;

                        if (!PatronCodigo.IsMatch(Codigo))
                        {
                            Mensaje = "El código deber ser de 6 caracteres numéricos";
                            if (Test == false)
                                MensajeError(Mensaje);
                            return Mensaje;
                        }
                        else
                        {
                            ObjEntidad.CodEstudiante = Codigo;
                            ObjEntidad.APaterno = APaterno;
                            ObjEntidad.AMaterno = AMaterno;
                            ObjEntidad.Nombre = Nombre;
                            ObjEntidad.Email = Email;
                            ObjEntidad.Direccion = Direccion;

                            if (!PatronTelefono.IsMatch(Telefono))
                            {
                                Mensaje = "El teléfono deber ser de 9 caracteres numéricos";
                                if (Test == false)
                                    MensajeError(Mensaje);
                                return Mensaje;
                            }
                            else
                            {
                                ObjEntidad.Telefono = Telefono;
                                ObjEntidad.CodEscuelaP = CodEscuelaP;
                                ObjEntidad.PersonaReferencia = PesonaReferencia;

                                if (!PatronTelefonoReferencia.IsMatch(TelefonoReferencia))
                                {
                                    Mensaje = "El teléfono de referencia deber ser de 9 caracteres numéricos";
                                    if (Test == false)
                                        MensajeError(Mensaje);
                                    return Mensaje;
                                }
                                else
                                {
                                    ObjEntidad.TelefonoReferencia = TelefonoReferencia;
                                    ObjEntidad.InformacionPersonal = EncriptarIPersonal(InformacionPersonal, false);

                                    if (Test == false)
                                    {
                                        N_Estudiante ObjNegocio = new N_Estudiante();
                                        ObjNegocio.InsertarRegistros(ObjEntidad);
                                    }
                                    
                                    Mensaje = "Registro insertado exitosamente";
                                    if (Test == false)
                                        MensajeConfirmacion(Mensaje);
                                    Program.Evento = 0;

                                    if (Test == false)
                                    {
                                        N_InicioSesion InicioSesion = new N_InicioSesion();
                                        string Contrasena = InicioSesion.RetornarContrasena(Codigo);

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
                                            mailDetails.To.Add(Email);
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
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (Test == false)
                            MensajeError("Error al insertar el registro ");
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
                            byte[] PerfilArray = new byte[0];
                            using (MemoryStream MemoriaPerfil = new MemoryStream())
                            {
                                Perfil.Save(MemoriaPerfil, ImageFormat.Bmp);
                                PerfilArray = MemoriaPerfil.ToArray();
                            }
                            ObjEntidad.Perfil = PerfilArray;

                            if (!PatronCodigo.IsMatch(Codigo))
                            {
                                Mensaje = "El código deber ser de 6 caracteres numéricos";
                                if (Test == false)
                                    MensajeError(Mensaje);
                                return Mensaje;
                            }
                            else
                            {
                                ObjEntidad.CodEstudiante = Codigo;
                                ObjEntidad.APaterno = APaterno;
                                ObjEntidad.AMaterno = AMaterno;
                                ObjEntidad.Nombre = Nombre;
                                ObjEntidad.Email = Email;
                                ObjEntidad.Direccion = Direccion;

                                if (!PatronTelefono.IsMatch(Telefono))
                                {
                                    Mensaje = "El teléfono deber ser de 9 caracteres numéricos";
                                    if (Test == false)
                                        MensajeError(Mensaje);
                                    return Mensaje;
                                }
                                else
                                {
                                    ObjEntidad.Telefono = Telefono;
                                    ObjEntidad.CodEscuelaP = CodEscuelaP;
                                    ObjEntidad.PersonaReferencia = PesonaReferencia;

                                    if (!PatronTelefonoReferencia.IsMatch(TelefonoReferencia))
                                    {
                                        Mensaje = "El teléfono deber ser de 9 caracteres numéricos";
                                        if (Test == false)
                                            MensajeError(Mensaje);
                                        return Mensaje;
                                    }
                                    else
                                    {

                                        ObjEntidad.TelefonoReferencia = TelefonoReferencia;
                                        ObjEntidad.InformacionPersonal = EncriptarIPersonal(InformacionPersonal, false);

                                        if (Test == false)
                                        {
                                            N_Estudiante ObjNegocio = new N_Estudiante();
                                            ObjNegocio.EditarRegistros(ObjEntidad);
                                        }
                                        
                                        Mensaje = "Registro editado exitosamente";
                                        if (Test == false)
                                            MensajeConfirmacion(Mensaje);
                                        Program.Evento = 0;

                                        if (Test == false)
                                        {
                                            LimpiarCajas();
                                            Close();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al editar el registro" + ex);
                    }
                }
            }
            else
            {
                if (Codigo.Trim() == "")
                {
                    Mensaje = "Debe llenar el código";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (APaterno.Trim() == "")
                {
                    Mensaje = "Debe llenar el apellido paterno";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (AMaterno.Trim() == "")
                {
                    Mensaje = "Debe llenar el apellido materno";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                if (Nombre.Trim() == "")
                {
                    Mensaje = "Debe llenar el nombre";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                if (Direccion.Trim() == "")
                {
                    Mensaje = "Debe llenar la dirección";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (Telefono.Trim() == "")
                {
                    Mensaje = "Debe llenar el teléfono";
                    if (Test == false)
                        MensajeError(Mensaje);
                }                
            }

            return Mensaje;
        }

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarOModificar(imgPerfil.Image, txtCodigo.Text, txtAPaterno.Text.ToUpper(), txtAMaterno.Text.ToUpper(),
                              txtNombre.Text.ToUpper(), txtCodigo.Text + "@unsaac.edu.pe", txtDireccion.Text.ToUpper(),
                              txtTelefono.Text, cxtEscuela.SelectedValue.ToString(), txtPReferencia.Text.ToUpper(),
                              txtTReferencia.Text, txtIPersonal.Text);
            //if ((txtCodigo.Text.Trim() != "") &&
            //    (txtAPaterno.Text.Trim() != "") &&
            //    (txtAMaterno.Text.Trim() != "") &&
            //    (txtNombre.Text.Trim() != "") &&
            //    (txtDireccion.Text.Trim() != "") &&
            //    (txtTelefono.Text.Trim() != ""))
            //{
            //    if (Program.Evento == 0)
            //    {
            //        try
            //        {
            //            byte[] Perfil = new byte[0];
            //            using (MemoryStream MemoriaPerfil = new MemoryStream())
            //            {
            //                imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
            //                Perfil = MemoriaPerfil.ToArray();
            //            }
            //            ObjEntidad.Perfil = Perfil;
            //            ObjEntidad.CodEstudiante = txtCodigo.Text;
            //            ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
            //            ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
            //            ObjEntidad.Nombre = txtNombre.Text.ToUpper();
            //            ObjEntidad.Email = txtCodigo.Text + "@unsaac.edu.pe";
            //            ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
            //            ObjEntidad.Telefono = txtTelefono.Text;
            //            ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
            //            ObjEntidad.PersonaReferencia = txtPReferencia.Text.ToUpper();
            //            ObjEntidad.TelefonoReferencia = txtTReferencia.Text;
            //            ObjEntidad.InformacionPersonal = EncriptarIPersonal(txtIPersonal.Text,false);

            //            ObjNegocio.InsertarRegistros(ObjEntidad);
            //            MensajeConfirmacion("Registro insertado exitosamente");
            //            Program.Evento = 0;

            //            N_InicioSesion InicioSesion = new N_InicioSesion();
            //            string Contrasena = InicioSesion.RetornarContrasena(txtCodigo.Text);

            //            // Enviar un correo con la contraseña para un nuevo usuario
            //            try
            //            {
            //                SmtpClient clientDetails = new SmtpClient();
            //                clientDetails.Port = 587;
            //                clientDetails.Host = "smtp.gmail.com";
            //                clientDetails.EnableSsl = true;
            //                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
            //                clientDetails.UseDefaultCredentials = false;
            //                clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

            //                MailMessage mailDetails = new MailMessage();
            //                mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
            //                mailDetails.To.Add(ObjEntidad.Email);
            //                mailDetails.Subject = "Contraseña del Sistema de Tutoría UNSAAC";
            //                mailDetails.IsBodyHtml = true;
            //                mailDetails.Body = "Tu contraseña es " + Contrasena;
            //                clientDetails.Send(mailDetails);
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }

            //            LimpiarCajas();
            //            Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MensajeError("Error al insertar el registro " + ex);
            //        }
            //    }
            //    else
            //    {
            //        try
            //        {
            //            DialogResult Opcion;
            //            Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //            if (Opcion == DialogResult.OK)
            //            {
            //                byte[] Perfil = new byte[0];
            //                using (MemoryStream MemoriaPerfil = new MemoryStream())
            //                {
            //                    imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
            //                    Perfil = MemoriaPerfil.ToArray();
            //                }
            //                ObjEntidad.Perfil = Perfil;
            //                ObjEntidad.CodEstudiante = txtCodigo.Text;
            //                ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
            //                ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
            //                ObjEntidad.Nombre = txtNombre.Text.ToUpper();
            //                ObjEntidad.Email = txtCodigo.Text + "@unsaac.edu.pe";
            //                ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
            //                ObjEntidad.Telefono = txtTelefono.Text;
            //                ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
            //                ObjEntidad.PersonaReferencia = txtPReferencia.Text.ToUpper();
            //                ObjEntidad.TelefonoReferencia = txtTReferencia.Text;
            //                ObjEntidad.InformacionPersonal = EncriptarIPersonal(txtIPersonal.Text, false);

            //                ObjNegocio.EditarRegistros(ObjEntidad);
            //                MensajeConfirmacion("Registro editado exitosamente");
            //                Program.Evento = 0;
            //                LimpiarCajas();
            //                Close();
            //            }
            //        }
            //        catch (Exception)
            //        {
            //            MensajeError("Error al editar el registro");
            //        }
            //    }
            //}
            //else
            //{
            //    MensajeError("Debe llenar los campos");
            //}
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
