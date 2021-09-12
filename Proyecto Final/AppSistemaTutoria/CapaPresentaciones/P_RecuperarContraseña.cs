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
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_RecuperarContraseña : Form
    {

        readonly E_Estudiante ObjEntidad = new E_Estudiante();
        readonly N_Estudiante ObjNegocio = new N_Estudiante();

        public P_RecuperarContraseña()
        {
            InitializeComponent();
        }

        private void btnRecuperarContraseña_Click(object sender, EventArgs e)
        {
            // Ingresar en el formulario el correo electrónico asociado a la cuenta

            // Contraseña del usuario
            // Buscar usuario por email -> Buscar usuario por código
            // Si no hay -> Mensaje: Ningún usuario está asociado a este correo

            // Si hay
            // Desencriptar contraseña y enviarlo


            /*string Email = txtTo.Text;
            DataTable dt = CapaNegocios.N_Estudiante.BuscarRegistros("182906");*/
            


            // Enviar un correo con la contraseña
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
                mailDetails.To.Add(txtTo.Text + lblDominio.Text);
                mailDetails.Subject = "Asunto";
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = "Tu contraseña es " + "Contraseña";

                clientDetails.Send(mailDetails);
                MessageBox.Show("Email Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
