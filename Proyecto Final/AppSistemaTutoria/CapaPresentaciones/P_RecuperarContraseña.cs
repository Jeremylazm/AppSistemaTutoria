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
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; DataBase = BDSistema_Tutoria; Integrated Security = true");

            string Cod = txtTo.Text;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Usuario, Contraseña, Acceso from TUsuario where Usuario = @Usuario", con);
                cmd.Parameters.AddWithValue("Usuario", Cod);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
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
                        mailDetails.Subject = "Recuperación de contraseña";
                        mailDetails.IsBodyHtml = true;
                        mailDetails.Body = "Tu contraseña es " + dt.Rows[0][1].ToString();

                        clientDetails.Send(mailDetails);
                        MessageBox.Show("Email Sent");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("El correo no está asociado a ninguna cuenta");// No existe el usuario
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
