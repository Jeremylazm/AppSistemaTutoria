using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using CapaNegocios;

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

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            N_InicioSesion InicioSesion = new N_InicioSesion();
            string Contrasena = InicioSesion.RetornarContrasena(txtEmail.Text);

            // Enviar un correo con la contraseña del usuario
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
                mailDetails.To.Add(txtEmail.Text + lblDominioEmail.Text);
                mailDetails.Subject = "Recuperación de contraseña";
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = "Tu contraseña es " + Contrasena;
                clientDetails.Send(mailDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
