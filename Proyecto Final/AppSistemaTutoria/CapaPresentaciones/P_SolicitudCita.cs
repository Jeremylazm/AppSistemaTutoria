using CapaNegocios;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
namespace CapaPresentaciones
{
    public partial class P_SolicitudCita : Form
    {
        public string Usuario = "";
        public string CorreoTutor = "";
        public P_SolicitudCita(string pUsuario, DataTable Datos)
        {
            // Buscamos los datos del Tutor
            Usuario = pUsuario;
            object[] Fila = Datos.Rows[0].ItemArray;
            CorreoTutor = Fila[4].ToString();
            InitializeComponent();
            CargarDatosEstudiante();
        }
        public void CargarDatosEstudiante()
        {
            // Establecemos que el minimo de fecha es hoy
            dTPFechaCita.MinDate = DateTime.Today.AddDays(1);
            // Leemos los datos de estudiante para el formulario
            DataTable Datos = N_Estudiante.BuscarRegistro(Usuario);
            object[] Fila = Datos.Rows[0].ItemArray;
            // Asignamos los valores en los textBox
            txtCodigo.Text = Fila[2].ToString();
            txtEstudiante.Text = Fila[6].ToString();
            txtDireccion.Text = Fila[8].ToString();
            txtTelefono.Text = Fila[9].ToString();
            txtEscuelaP.Text = Fila[11].ToString();
            txtPReferencia.Text = Fila[12].ToString();
            txtTReferencia.Text = Fila[13].ToString();
        }
        //Cerrar aplicacion
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // Algunos restricciones antes de enviar la solicitud
            if (cBoxHora.Text == "")
            {
                MessageBox.Show("Especifique Hora de Cita");
                return;
            }
            else if (cBoxAMPM.Text == "")
            {
                MessageBox.Show("Especifique indicador de hora AM o PM");
                return;
            }
            else
            {
                // Llenamos el contenido de la solicitud
                string TextoSolicitud = "<!DOCTYPE html>";
                TextoSolicitud += "<html lang='es'>";
                TextoSolicitud += "<body style='background - color: black '>";
                TextoSolicitud += "<tr>";
                TextoSolicitud += "<h2 style='color: #000000; text-align: center; margin: 0 0 7px'>" + "SOLICITUD CITA DE TUTORIA" + "</h2>";
                TextoSolicitud += "<p style='color: #000000; margin: 2px; font - size: 15px'>";
                TextoSolicitud += "El Sistema de Tutorias UNSAAC, hace de conocimiento la siguiente solicitud de cita hacia Ud.:";
                TextoSolicitud += "<br/>";
                TextoSolicitud += "<b>" + gbxDatos.Text + "</b>" + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Código: </b>" + txtCodigo.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Estudiante: </b>" + txtEstudiante.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Dirección: </b>" + txtDireccion.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Teléfono: </b>" + txtTelefono.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Esc. Profesional: </b>" + txtEscuelaP.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Persona Referencia: </b>" + txtPReferencia.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "<b>Tel. Referencia: </b>" + txtTReferencia.Text + "<br/>" + "<br/>" +
                    "<b>" + labelDatosCita.Text + "</b>" + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "Fecha: " + dTPFechaCita.Text + " Hora: " + cBoxHora.Text + ":00:00 " + cBoxAMPM.Text + "<br/>" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "Descripción: " + txtDescripcionCita.Text;
                TextoSolicitud += "</p>";
                TextoSolicitud += "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Atte. Sistemas de Tutorias UNSAAC</p>";

                TextoSolicitud += "</tr>";
                TextoSolicitud += "</body>";
                TextoSolicitud += "</html>";
                // Enviar un correo con los detalles de la cita
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
                    mailDetails.To.Add(CorreoTutor);
                    mailDetails.Subject = "Solicitud de Cita de Tutoria";
                    mailDetails.IsBodyHtml = true;
                    mailDetails.Body = TextoSolicitud;
                    clientDetails.Send(mailDetails);
                    MessageBox.Show("Solicitud Enviada.", "Estado Solicitud", MessageBoxButtons.OK);
                }
                catch (Exception)
                {
                    MessageBox.Show("Solicitud no Enviada", "Estado Solicitud", MessageBoxButtons.OK);
                }

            }


        }
    }
}
