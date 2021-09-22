using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_DatosDocente : Form
    {
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();
        public bool Test { get; set; }

        public P_DatosDocente()
        {
            InitializeComponent();
            LlenarComboBox();
            ValidarPerfil();
        }

        public P_DatosDocente(bool pTest)
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
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCodigo.Focus();
        }

        private void ValidarPerfil()
        {
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
            if (imgPerfil.Image == Image.FromFile(fullImagePath))
            {
                btnRestablecerPerfil.Visible = false;
            }
        }

        private void LlenarComboBox()
        {
            cxtCategoria.SelectedIndex = 0;
            cxtSubcategoria.SelectedIndex = 0;
            cxtRegimen.SelectedIndex = 0;

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

        //public string VerificarDatosDocente(Image Perfil, string Codigo, string APaterno, string AMaterno,
        //    string Nombre, string Email, string Direccion, string Telefono, string Categoria, string Subcategoria, 
        //    string Regimen, string EProfesional, string Horario)
        //{
        //    string msg = ""; //Mensaje a retornar
            
        //    //Verificar si los strings no están vacios
        //    if( (Codigo.Trim() != "") &&
        //        (APaterno.Trim() != "") &&
        //        (AMaterno.Trim() != "") &&
        //        (Nombre.Trim() != "") &&
        //        (Email.Trim() != "") &&
        //        (Direccion.Trim() != "") &&
        //        (Telefono.Trim() != ""))
        //    {
        //        //Definiendo expresiones regulares
        //        Regex PatronCodigo = new Regex(@"\A[0-9]{6}\Z");
        //        Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");

        //        //Si Programa está en modo edicion
        //        if (Program.Evento == 0) 
        //        {
        //            //Tratar de insertar la informacion
        //            try
        //            {
        //                //Definir byte para guardar la imagen de perfil
        //                byte[] PerfilArray = new byte[0];
        //                using (MemoryStream MemoriaPerfil = new MemoryStream())
        //                {
        //                    //Guardar imagen de perfil en mapa de bits
        //                    Perfil.Save(MemoriaPerfil, ImageFormat.Bmp);
        //                    PerfilArray = MemoriaPerfil.ToArray();
        //                }
        //                ObjEntidad.Perfil = PerfilArray; //Guardadno en ObjEntidad
        //                //Si Codigo no coincide con la expresión regular definida
        //                if (!PatronCodigo.IsMatch(Codigo))
        //                {
        //                    msg = "El código debe tener 6 caracteres numéricos";
        //                    //Si no es test
        //                    if (Test == false) MensajeError(msg); //Mostrar warning
        //                    return msg;
        //                }
        //                else //Si codigo coincide con la expresión regular
        //                {
        //                    //Guardar información
        //                    ObjEntidad.CodDocente = Codigo;
        //                    ObjEntidad.APaterno = APaterno;
        //                    ObjEntidad.AMaterno = AMaterno;
        //                    ObjEntidad.Nombre = Nombre;
        //                    ObjEntidad.Email = Email;
        //                    ObjEntidad.Direccion = Direccion;

        //                    //SI Telefono no coincide con la expresión regular
        //                    if (!PatronTelefono.IsMatch(Telefono))
        //                    {
        //                        msg = "El teléfono debe tener 9 dígitos";
        //                        //Si no es test
        //                        if (Test == false) MensajeError(msg); //Mostrar warning
        //                        return msg;
        //                    }
        //                    else //Si telefono coincide con la exp. regular
        //                    {
        //                        ObjEntidad.Telefono = Telefono;
        //                        //ObjEntidad.Categoria = Categoria;
        //                        //ObjEntidad.Subcategoria = Subcategoria;
        //                        //ObjEntidad.Regimen = Regimen;
        //                        ObjEntidad.CodEscuelaP = EProfesional;
        //                        //ObjEntidad.Horario = Horario;
                                


        //                    }
        //                }
        //            }
        //            catch (Exception e)
        //            {

        //                throw;
        //            }
        //        }

        //    }

        //    /*
        //    string Mensaje = "";

        //    if ((Codigo.Trim() != "") &&
        //        (APaterno.Trim() != "") &&
        //        (AMaterno.Trim() != "") &&
        //        (Nombre.Trim() != "") &&
        //        (Direccion.Trim() != "") &&
        //        (Telefono.Trim() != ""))
        //    {
        //        Regex PatronCodigo = new Regex(@"\A[0-9]{6}\Z");
        //        Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");
        //        Regex PatronTelefonoReferencia = new Regex(@"\A([0-9]{9}\Z)|(^$)");

        //        if (Program.Evento == 0)
        //        {
        //            try
        //            {
        //                byte[] PerfilArray = new byte[0];
        //                using (MemoryStream MemoriaPerfil = new MemoryStream())
        //                {
        //                    Perfil.Save(MemoriaPerfil, ImageFormat.Bmp);
        //                    PerfilArray = MemoriaPerfil.ToArray();
        //                }
        //                ObjEntidad.Perfil = PerfilArray;

        //                if (!PatronCodigo.IsMatch(Codigo))
        //                {
        //                    Mensaje = "El código deber ser de 6 caracteres numéricos";
        //                    if (Test == false)
        //                        MensajeError(Mensaje);
        //                    return Mensaje;
        //                }
        //                else
        //                {
        //                    ObjEntidad.CodEstudiante = Codigo;
        //                    ObjEntidad.APaterno = APaterno;
        //                    ObjEntidad.AMaterno = AMaterno;
        //                    ObjEntidad.Nombre = Nombre;
        //                    ObjEntidad.Email = Email;
        //                    ObjEntidad.Direccion = Direccion;

        //                    if (!PatronTelefono.IsMatch(Telefono))
        //                    {
        //                        Mensaje = "El teléfono deber ser de 9 caracteres numéricos";
        //                        if (Test == false)
        //                            MensajeError(Mensaje);
        //                        return Mensaje;
        //                    }
        //                    else
        //                    {
        //                        ObjEntidad.Telefono = Telefono;
        //                        ObjEntidad.CodEscuelaP = CodEscuelaP;
        //                        ObjEntidad.PersonaReferencia = PersonaReferencia;

        //                        if (!PatronTelefonoReferencia.IsMatch(TelefonoReferencia))
        //                        {
        //                            Mensaje = "El teléfono de referencia deber ser de 9 caracteres numéricos";
        //                            if (Test == false)
        //                                MensajeError(Mensaje);
        //                            return Mensaje;
        //                        }
        //                        else
        //                        {
        //                            ObjEntidad.TelefonoReferencia = TelefonoReferencia;
        //                            ObjEntidad.InformacionPersonal = E_Criptografia.EncriptarRSA(InformacionPersonal, Key);
        //                            if (Test == false)
        //                            {
        //                                N_Estudiante ObjNegocio = new N_Estudiante();
        //                                ObjNegocio.InsertarRegistros(ObjEntidad);
        //                            }
                                    
        //                            Mensaje = "Registro insertado exitosamente";
        //                            if (Test == false)
        //                                MensajeConfirmacion(Mensaje);
        //                            Program.Evento = 0;

        //                            if (Test == false)
        //                            {
        //                                N_InicioSesion InicioSesion = new N_InicioSesion();
        //                                string Contrasena = InicioSesion.RetornarContrasena(Codigo);

        //                                // Enviar un correo con la contraseña para un nuevo usuario
        //                                try
        //                                {
        //                                    SmtpClient clientDetails = new SmtpClient();
        //                                    clientDetails.Port = 587;
        //                                    clientDetails.Host = "smtp.gmail.com";
        //                                    clientDetails.EnableSsl = true;
        //                                    clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
        //                                    clientDetails.UseDefaultCredentials = false;
        //                                    clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

        //                                    MailMessage mailDetails = new MailMessage();
        //                                    mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
        //                                    mailDetails.To.Add(Email);
        //                                    mailDetails.Subject = "Contraseña del Sistema de Tutoría UNSAAC";
        //                                    mailDetails.IsBodyHtml = true;
        //                                    mailDetails.Body = "Tu contraseña es " + Contrasena;
        //                                    clientDetails.Send(mailDetails);
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    MessageBox.Show(ex.Message);
        //                                }

        //                                LimpiarCajas();
        //                                Close();
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                if (Test == false)
        //                    MensajeError("Error al insertar el registro ");
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                DialogResult Opcion;
        //                Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //                if (Opcion == DialogResult.OK)
        //                {
        //                    byte[] PerfilArray = new byte[0];
        //                    using (MemoryStream MemoriaPerfil = new MemoryStream())
        //                    {
        //                        Perfil.Save(MemoriaPerfil, ImageFormat.Bmp);
        //                        PerfilArray = MemoriaPerfil.ToArray();
        //                    }
        //                    ObjEntidad.Perfil = PerfilArray;

        //                    if (!PatronCodigo.IsMatch(Codigo))
        //                    {
        //                        Mensaje = "El código deber ser de 6 caracteres numéricos";
        //                        if (Test == false)
        //                            MensajeError(Mensaje);
        //                        return Mensaje;
        //                    }
        //                    else
        //                    {
        //                        ObjEntidad.CodEstudiante = Codigo;
        //                        ObjEntidad.APaterno = APaterno;
        //                        ObjEntidad.AMaterno = AMaterno;
        //                        ObjEntidad.Nombre = Nombre;
        //                        ObjEntidad.Email = Email;
        //                        ObjEntidad.Direccion = Direccion;

        //                        if (!PatronTelefono.IsMatch(Telefono))
        //                        {
        //                            Mensaje = "El teléfono deber ser de 9 caracteres numéricos";
        //                            if (Test == false)
        //                                MensajeError(Mensaje);
        //                            return Mensaje;
        //                        }
        //                        else
        //                        {
        //                            ObjEntidad.Telefono = Telefono;
        //                            ObjEntidad.CodEscuelaP = CodEscuelaP;
        //                            ObjEntidad.PersonaReferencia = PersonaReferencia;

        //                            if (!PatronTelefonoReferencia.IsMatch(TelefonoReferencia))
        //                            {
        //                                Mensaje = "El teléfono deber ser de 9 caracteres numéricos";
        //                                if (Test == false)
        //                                    MensajeError(Mensaje);
        //                                return Mensaje;
        //                            }
        //                            else
        //                            {

        //                                ObjEntidad.TelefonoReferencia = TelefonoReferencia;
        //                                ObjEntidad.InformacionPersonal = E_Criptografia.EncriptarRSA(InformacionPersonal, Key);

        //                                if (Test == false)
        //                                {
        //                                    N_Estudiante ObjNegocio = new N_Estudiante();
        //                                    ObjNegocio.EditarRegistros(ObjEntidad);
        //                                }
                                        
        //                                Mensaje = "Registro editado exitosamente";
        //                                if (Test == false)
        //                                    MensajeConfirmacion(Mensaje);
        //                                Program.Evento = 0;

        //                                if (Test == false)
        //                                {
        //                                    LimpiarCajas();
        //                                    Close();
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MensajeError("Error al editar el registro" + ex);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (Codigo.Trim() == "")
        //        {
        //            Mensaje = "Debe llenar el código";
        //            if (Test == false)
        //                MensajeError(Mensaje);
        //        }

        //        if (APaterno.Trim() == "")
        //        {
        //            Mensaje = "Debe llenar el apellido paterno";
        //            if (Test == false)
        //                MensajeError(Mensaje);
        //        }

        //        if (AMaterno.Trim() == "")
        //        {
        //            Mensaje = "Debe llenar el apellido materno";
        //            if (Test == false)
        //                MensajeError(Mensaje);
        //        }
        //        if (Nombre.Trim() == "")
        //        {
        //            Mensaje = "Debe llenar el nombre";
        //            if (Test == false)
        //                MensajeError(Mensaje);
        //        }
        //        if (Direccion.Trim() == "")
        //        {
        //            Mensaje = "Debe llenar la dirección";
        //            if (Test == false)
        //                MensajeError(Mensaje);
        //        }

        //        if (Telefono.Trim() == "")
        //        {
        //            Mensaje = "Debe llenar el teléfono";
        //            if (Test == false)
        //                MensajeError(Mensaje);
        //        }                
        //    }

        //    return Mensaje;
        //}
        //     */

        //    return msg;
        //}

        /*EN PROCESO... :'v*/
        public string AgregarOModificar(Image Perfil, string Codigo, string APaterno, string AMaterno,
            string Nombre, string Email, string Direccion, string Telefono, string Categoria, string Subcategoria,
            string Regimen, string EProfesional, string Horario)
        {
            string msg = "";

            if ((Codigo.Trim() != "") &&
                (APaterno.Trim() != "") &&
                (AMaterno.Trim() != "") &&
                (Nombre.Trim() != "") &&
                (Email.Trim() != "") &&
                (Direccion.Trim() != "") &&
                (Telefono.Trim() != ""))
            {
                if (Program.Evento == 0)
                {
                    try
                    {
                        byte[] PerfilArray = new byte[0];
                        using (MemoryStream MemoriaPerfil = new MemoryStream())
                        {
                            imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                            PerfilArray = MemoriaPerfil.ToArray();
                        }
                        ObjEntidad.Perfil = PerfilArray;
                        ObjEntidad.CodDocente = Codigo;
                        ObjEntidad.APaterno = APaterno;
                        ObjEntidad.AMaterno = AMaterno;
                        ObjEntidad.Nombre = Nombre;
                        ObjEntidad.Email = Email;
                        ObjEntidad.Direccion = Direccion;
                        ObjEntidad.Telefono = Telefono;
                        ObjEntidad.Categoria = Categoria;
                        ObjEntidad.Subcategoria = Subcategoria;
                        ObjEntidad.Regimen = Regimen;
                        ObjEntidad.CodEscuelaP = EProfesional;
                        ObjEntidad.Horario = Horario;

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
                            byte[] PerfilArray = new byte[0];
                            using (MemoryStream MemoriaPerfil = new MemoryStream())
                            {
                                imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                                PerfilArray = MemoriaPerfil.ToArray();
                            }
                            ObjEntidad.Perfil = PerfilArray;
                            ObjEntidad.CodDocente = Codigo;
                            ObjEntidad.APaterno = APaterno;
                            ObjEntidad.AMaterno = AMaterno;
                            ObjEntidad.Nombre = Nombre;
                            ObjEntidad.Email = Email;
                            ObjEntidad.Direccion = Direccion;
                            ObjEntidad.Telefono = Telefono;
                            ObjEntidad.Categoria = Categoria;
                            ObjEntidad.Subcategoria = Subcategoria;
                            ObjEntidad.Regimen = Regimen;
                            ObjEntidad.CodEscuelaP = EProfesional;
                            ObjEntidad.Horario = Horario;                       

                            ObjNegocio.EditarRegistros(ObjEntidad);
                            MensajeConfirmacion("Registro editado exitosamente");
                            Program.Evento = 0;
                            LimpiarCajas();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al editar el registro " + ex);
                    }
                }
            }
            else
            {
                MensajeError("Debe llenar los campos");
            }

            return msg;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if ((txtCodigo.Text.Trim() != "") &&
            //    (txtAPaterno.Text.Trim() != "") &&
            //    (txtAMaterno.Text.Trim() != "") &&
            //    (txtNombre.Text.Trim() != "") &&
            //    (txtEmail.Text.Trim() != "") &&
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
            //            ObjEntidad.CodDocente = txtCodigo.Text;
            //            ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
            //            ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
            //            ObjEntidad.Nombre = txtNombre.Text.ToUpper();
            //            ObjEntidad.Email = txtEmail.Text + lblDominioEmail.Text;
            //            ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
            //            ObjEntidad.Telefono = txtTelefono.Text;
            //            ObjEntidad.Categoria = cxtCategoria.SelectedItem.ToString();
            //            ObjEntidad.Subcategoria = cxtSubcategoria.SelectedItem.ToString();
            //            ObjEntidad.Regimen = cxtRegimen.SelectedItem.ToString();
            //            ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
            //            ObjEntidad.Horario = txtHorario.Text.ToUpper();

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
            //                ObjEntidad.CodDocente = txtCodigo.Text;
            //                ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
            //                ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
            //                ObjEntidad.Nombre = txtNombre.Text.ToUpper();
            //                ObjEntidad.Email = txtEmail.Text + lblDominioEmail.Text;
            //                ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
            //                ObjEntidad.Telefono = txtTelefono.Text;
            //                ObjEntidad.Categoria = cxtCategoria.SelectedItem.ToString();
            //                ObjEntidad.Subcategoria = cxtSubcategoria.SelectedItem.ToString();
            //                ObjEntidad.Regimen = cxtRegimen.SelectedItem.ToString();
            //                ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
            //                ObjEntidad.Horario = txtHorario.Text.ToUpper();

            //                ObjNegocio.EditarRegistros(ObjEntidad);
            //                MensajeConfirmacion("Registro editado exitosamente");
            //                Program.Evento = 0;
            //                LimpiarCajas();
            //                Close();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MensajeError("Error al editar el registro " + ex);
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

        private void cxtCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cxtSubcategoria.Items.Clear();
            cxtRegimen.Items.Clear();
            cxtRegimen.Items.Add("TIEMPO COMPLETO");
            cxtRegimen.Items.Add("TIEMPO PARCIAL");

            if (cxtCategoria.SelectedItem.ToString() == "NOMBRADO")
            {
                
                cxtSubcategoria.Items.Add("PRINCIPAL");
                cxtSubcategoria.Items.Add("ASOCIADO");
                cxtSubcategoria.Items.Add("AUXILIAR");

                cxtRegimen.Enabled = true;
                cxtRegimen.Items.Insert(1, "DEDICACIÓN EXCLUSIVA");
            }
            else
            {
                cxtSubcategoria.Items.Add("A1");
                cxtSubcategoria.Items.Add("A2");
                cxtSubcategoria.Items.Add("A3");
                cxtSubcategoria.Items.Add("B1");
                cxtSubcategoria.Items.Add("B2");
                cxtSubcategoria.Items.Add("B3");
                
                cxtRegimen.Enabled = false;
            }

            cxtSubcategoria.SelectedIndex = 0;
            cxtRegimen.SelectedIndex = 0;
        }

        private void cxtSubcategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtCategoria.SelectedItem.ToString() == "CONTRATADO")
            {
                if (cxtSubcategoria.SelectedItem.ToString().EndsWith("1"))
                {
                    cxtRegimen.SelectedItem = "TIEMPO COMPLETO";
                }
                else
                {
                    cxtRegimen.SelectedItem = "TIEMPO PARCIAL";
                }
            }
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
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
            imgPerfil.Image = Image.FromFile(fullImagePath);
        }
    }
}
