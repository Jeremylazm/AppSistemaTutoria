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

        // Recupera la contraseña asociada a un usuario
        void Recuperar(string Email, string Dominio)
        {
            N_InicioSesion InicioSesion = new N_InicioSesion();
            string Contraseña = InicioSesion.RetornarContraseña(Email);

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
                mailDetails.To.Add(Email + Dominio);
                mailDetails.Subject = "Recuperación de contraseña";
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = "Tu contraseña es " + Contraseña;
                clientDetails.Send(mailDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            Recuperar(txtEmail.Text, lblDominioEmail.Text);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                Recuperar(txtEmail.Text, lblDominioEmail.Text);
        }
    }
}
