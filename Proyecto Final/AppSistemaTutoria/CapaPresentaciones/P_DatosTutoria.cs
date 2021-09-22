using CapaEntidades;
using CapaNegocios;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_DatosTutoria : Form
    {
        readonly E_FichaTutoria ObjEntidad = new E_FichaTutoria();
        readonly N_FichaTutoria ObjNegocio = new N_FichaTutoria();
        public bool Test { get; set; }
        public P_DatosTutoria()
        {
            InitializeComponent();
            cxtDimension.SelectedIndex = 0;
            DateTime thisDay = DateTime.Today;
            txtFecha.Text = thisDay.ToString("d");
        }
        public P_DatosTutoria(bool pTest)
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

            cxtDimension.SelectedIndex = 0;
            txtReferencia.Clear();
            txtDescripcion.Clear();
            txtObservaciones.Clear();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        public string AgregarOModificar(string semestre, string CodDocente, string CodEstudiante, string Dimension, string Referencia, string Descripcion,
                                 string Observaciones, string Fecha)
        {
            string Mensaje = "";

            if ((semestre.Trim() != "") &&
                (CodDocente.Trim() != "") &&
                (CodEstudiante.Trim() != "") &&
                (Dimension.Trim() != "") &&
                (Referencia.Trim() != "") &&
                (Descripcion.Trim() != "") &&
                (Observaciones.Trim() != ""))

            {
                Regex PatronCodigo = new Regex(@"\A[0-9]{6}\Z");
                Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");
                Regex PatronTelefonoReferencia = new Regex(@"\A([0-9]{9}\Z)|(^$)");

                if (Program.Evento == 1)
                {
                    try
                    {
                        ObjEntidad.CodEstudiante = CodDocente;
                        ObjEntidad.Semestre = semestre;

                        ObjEntidad.Dimension = Dimension;
                        ObjEntidad.Referencia = Referencia;
                        ObjEntidad.Descripcion = Descripcion;
                        ObjEntidad.Observaciones = Observaciones;
                        ObjEntidad.Fecha = Fecha;


                        if (Test == false)
                        {
                            ObjNegocio.InsertarRegistros(ObjEntidad);
                        }

                        Mensaje = "Registro insertado exitosamente";
                        if (Test == false)
                            MensajeConfirmacion(Mensaje);
                        Program.Evento = 0;

                        if (Test == false)
                        {
                            N_InicioSesion InicioSesion = new N_InicioSesion();
                            string Contrasena = InicioSesion.RetornarContraseña(CodDocente);

                            // Enviar un correo con la contraseña para un nuevo usuario

                            LimpiarCajas();
                            Close();
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
                            /*
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
                                    ObjEntidad.PersonaReferencia = PersonaReferencia;

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
                            }*/
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
                if (semestre.Trim() == "")
                {
                    Mensaje = "Debe llenar el campo semestre";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (Dimension.Trim() == "")
                {
                    Mensaje = "Debe llenar el apellido dimension";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (Observaciones.Trim() == "")
                {
                    Mensaje = "Debe llenar el campo observaciones";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                if (Referencia.Trim() == "")
                {
                    Mensaje = "Debe llenar la referencia";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                if (Descripcion.Trim() == "")
                {
                    Mensaje = "Debe llenar la descripcion";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
            }

            return Mensaje;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Agregar ficha tutoria
            if ((txtCodigoDocente.Text.Trim() != "") &&
                (txtCodigoEstudiante.Text.Trim() != "") &&
            (txtSemestre.Text.Trim() != "") &&
            (txtReferencia.Text.Trim() != "") &&
            (txtDescripcion.Text.Trim() != "") &&
            (cxtDimension.Text.Trim() != "") &&
            (txtObservaciones.Text.Trim() != "") &&
            (txtFecha.Text.Trim() != ""))
            {
                if (Program.Evento == 0)
                {
                    try
                    {

                        //ObjEntidad.CodDocente = txtCodigoDocente.Text;
                        ObjEntidad.CodEstudiante = txtCodigoEstudiante.Text;
                        ObjEntidad.Semestre = txtSemestre.Text;
                        ObjEntidad.Referencia = txtReferencia.Text;
                        ObjEntidad.Dimension = cxtDimension.Text;
                        ObjEntidad.Descripcion = txtDescripcion.Text;
                        ObjEntidad.Observaciones = txtObservaciones.Text;
                        DateTime thisDay = DateTime.Today;
                        ObjEntidad.Fecha = thisDay.ToString("d");

                        ObjNegocio.InsertarRegistros(ObjEntidad);
                        MensajeConfirmacion("Registro insertado exitosamente");

                        Program.Evento = 0;

                        N_InicioSesion InicioSesion = new N_InicioSesion();
                        string Contrasena = InicioSesion.RetornarContraseña(txtCodigoDocente.Text);

                        // Enviar un correo con la contraseña para un nuevo usuario
                        try
                        {
                            /*
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
                            clientDetails.Send(mailDetails);*/
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

                            //ObjEntidad.CodDocente = txtCodigoDocente.Text;
                            ObjEntidad.CodEstudiante = txtCodigoEstudiante.Text;
                            ObjEntidad.Semestre = txtAMaterno.Text.ToUpper();
                            ObjEntidad.Referencia = txtReferencia.Text;
                            ObjEntidad.Dimension = cxtDimension.Text;
                            ObjEntidad.Descripcion = txtDescripcion.Text;
                            ObjEntidad.Observaciones = txtObservaciones.Text;
                            DateTime thisDay = DateTime.Today;
                            ObjEntidad.Fecha = thisDay.ToString("d");

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
                MensajeError("Debe llenar todos los campos");
            }
        }
    }
}
