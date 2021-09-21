using CapaNegocios;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_RecuperarContraseña : Form
    {
        public P_RecuperarContraseña()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Recupera la contraseña asociada a un usuario
        void Recuperar(string Email, string Dominio)
        {
            // Verificar si hay un usuario asociado al correo puesto en el textbox
            N_InicioSesion InicioSesion = new N_InicioSesion();
            string Contraseña = InicioSesion.RetornarContraseña(Email);

            // Enviar un correo con la contraseña del usuario si el usuario existe
            if (Contraseña != null)
            {
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
                    mailDetails.To.Add(Email + Dominio);
                    mailDetails.Subject = "Recuperación de contraseña de Sistema de Tutoría UNSAAC";
                    mailDetails.IsBodyHtml = true;

                    // Llenamos el contenido de la solicitud
                    string TextoSolicitud = "<!DOCTYPE html>";
                    TextoSolicitud += "<html lang='es'>";
                    TextoSolicitud += "<body style='background - color: black '>";
                    TextoSolicitud += "<tr>";
                    TextoSolicitud += "<h2 style='color: #000000; text-align: center; margin: 0 0 7px'>" + "Solicitud de recuperación de contraseña de Sistema de Tutoría UNSAAC" + "</h2>";
                    TextoSolicitud += "<p style='color: #000000; margin: 2px; font - size: 15px'>";
                    TextoSolicitud += "<br/>";
                    TextoSolicitud += "<b>" + "CONTRASEÑA: " + "<span style='font-size: 45px'>" + Contraseña + "</span>" + "</b>" + "<br/>";
                    TextoSolicitud += "</p>";
                    TextoSolicitud += "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Atte. Sistemas de Tutorias UNSAAC</p>";

                    TextoSolicitud += "</tr>";
                    TextoSolicitud += "</body>";
                    TextoSolicitud += "</html>";

                    mailDetails.Body = TextoSolicitud;
                    clientDetails.Send(mailDetails);
                    lblMensaje.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No hay ningún usuario asociado a esta cuenta");
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            Recuperar(txtEmail.Text, lblDominioEmail.Text);
        }

        // Atajo tecla ENTER para enviar el formulario
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Recuperar(txtEmail.Text, lblDominioEmail.Text);
        }
    }
}
