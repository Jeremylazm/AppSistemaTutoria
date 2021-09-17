using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaEntidades;
using System.Net;
using System.Net.Mail;

namespace CapaPresentaciones
{
    public partial class P_CambiarContraseña : Form
    {
        public string Usuario = "";
        public string Correo = "";
        private string codigo_verificacion = "";
        public P_CambiarContraseña()
        {
            InitializeComponent();
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private string EnviarCodigo(string Correo)
        {
            // Enviar un correo con la contraseña
            try
            {
                Random r = new Random();
                var x = r.Next(0, 1000000);
                string s = x.ToString("000000");

                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
                mailDetails.To.Add(Correo);
                mailDetails.Subject = "Código de verificación";
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = "Ingresa el siguiente código: " + s;

                clientDetails.Send(mailDetails);
                MessageBox.Show("Email Sent");
                return s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "-1";
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.Size = new Size(25, 25);
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.Size = new Size(24, 24);
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string correo = txtEmail.Text + lblDominioEmail.Text;
            if (correo != lblDominioEmail.Text)
            {
                if (correo == Correo)
                {
                    codigo_verificacion = EnviarCodigo(correo);
                    panelVerificacion.Visible = true;
                    panelCorreo.Visible = false;
                    panelVerificacion.BringToFront();
                    lblEmail.Text = correo;
                }
                else
                {
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    MensajeError("Correo electrónico no coincide, intente de nuevo");
                }
            }
            else
            {
                MensajeError("Correo no ingresados, intente de nuevo");
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseñaAnterior.Text != "" &&
                txtContraseñaNueva.Text != "" &&
                txtConfirmarContraseña.Text != "")
            {
                if (txtContraseñaNueva.Text == txtConfirmarContraseña.Text)
                {

                    N_InicioSesion InicioSesion = new N_InicioSesion();

                    var ValidarDatos = InicioSesion.IniciarSesion(Usuario, txtContraseñaAnterior.Text);
                    if (ValidarDatos == true)
                    {
                        try
                        {
                            string nuevaContraseña = txtContraseñaNueva.Text;

                            DialogResult Opcion = MessageBox.Show("¿Realmente desea cambiar la contraseña?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.OK)
                            {
                                bool CambioContraseñaValido = InicioSesion.EditarRegistros(Usuario, nuevaContraseña);
                                Close();
                                if (CambioContraseñaValido)
                                    MessageBox.Show("Contraseña cambiada correctamente");
                                else
                                    MessageBox.Show("No se pudo cambiar la contraseña");
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cambiar la contraseña " + ex);
                        }
                    }
                    else
                    {
                        MensajeError("La contraseña anterior no es correcta, intente de nuevo");
                        txtContraseñaAnterior.Clear();
                        txtContraseñaNueva.Clear();
                        txtConfirmarContraseña.Clear();
                        txtContraseñaAnterior.Focus();
                    }

                }
                else
                {
                    MensajeError("La contraseñas no coinciden, intente de nuevo");
                    txtContraseñaNueva.Clear();
                    txtConfirmarContraseña.Clear();
                    txtContraseñaNueva.Focus();
                }
            }
            else
            {
                MensajeError("Campos vacíos, intente de nuevo");
                if (txtContraseñaAnterior.Text == "")
                    txtContraseñaAnterior.Focus();
                else if (txtContraseñaNueva.Text == "")
                {
                    txtContraseñaNueva.Focus();
                    txtConfirmarContraseña.Clear();
                }

                else
                    txtConfirmarContraseña.Focus();

            }
        }

        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            if (txtCodigoVerificacion.Text != "")
            {
                if (txtCodigoVerificacion.Text == codigo_verificacion)
                {
                    panelVerificacion.Visible = false;
                    panelCambiarContraseña.Visible = true;
                    panelCambiarContraseña.BringToFront();
                }
                else
                {
                    txtCodigoVerificacion.Text = "";
                    txtCodigoVerificacion.Focus();
                    MensajeError("Los codigos no coinciden, intente de nuevo");
                }
            }
            else
            {
                MensajeError("Campo codigo de validacion vacio, intente de nuevo");
            }
        }

        private void lblVolverEnviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string correo = lblEmail.Text;
            codigo_verificacion = EnviarCodigo(correo);
        }
    }
}
