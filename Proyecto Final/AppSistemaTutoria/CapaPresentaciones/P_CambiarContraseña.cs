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
            string correo = tbCorreo.Text + "@unsaac.edu.pe";
            if(correo != "@unsaac.edu.pe")
            {
                if(correo == Correo)
                {
                    codigo_verificacion = EnviarCodigo(correo);
                    panelVerificacion.Visible = true;
                    panelCorreo.Visible = false;
                    panelVerificacion.BringToFront();
                }
                else
                {
                    tbCorreo.Text = "";
                    tbCorreo.Focus();
                    MensajeError("Correo electrónico no coincide, intente de nuevo");
                }
            }
            else
            {
                MensajeError("Correo no ingresados, intente de nuevo");
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if(tbCodigoVerificacion.Text != "")
            {
                if(tbCodigoVerificacion.Text == codigo_verificacion)
                {
                    panelVerificacion.Visible = false;
                    panelCambiarContraseña.Visible = true;
                    panelCambiarContraseña.BringToFront();
                }
                else
                {
                    tbCodigoVerificacion.Text = "";
                    tbCodigoVerificacion.Focus();
                    MensajeError("Los codigos no coinciden, intente de nuevo");
                }
            }
            else
            {
                MensajeError("Campo codigo de validacion vacio, intente de nuevo");
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if(tbContraseñaAnterior.Text != "" &&
                tbContraseña.Text != "" &&
                tbContraseñaRep.Text != "")
            {
                if (tbContraseña.Text == tbContraseñaRep.Text)
                {

                    N_InicioSesion InicioSesion = new N_InicioSesion();

                    var ValidarDatos = InicioSesion.IniciarSesion(Usuario, tbContraseñaAnterior.Text);
                    if (ValidarDatos == true)
                    {
                        try
                        {
                            string nuevaContraseña = tbContraseña.Text;
                            //string contraseñaEncriptada = E_Criptografia.CifradoMD5(nuevaContraseña);
                            //MessageBox.Show(contraseñaEncriptada + " ,  len: " + contraseñaEncriptada.Length);

                            DialogResult Opcion = MessageBox.Show("¿Realmente desea cambiar la contraseña?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.OK)
                            {
                                //var CambioContraseñaValido = InicioSesion.EditarRegistros(Usuario, contraseñaEncriptada);
                                var CambioContraseñaValido = InicioSesion.EditarRegistros(Usuario, nuevaContraseña);
                                Close();
                                if(CambioContraseñaValido)
                                    MessageBox.Show("Contraseña cambiada correctamente");
                                else
                                    MessageBox.Show("No se pudo cambiar la contraseña");
                            }

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error al cambiar la contraseña " + ex);
                        }
                    }
                    else
                    {
                        MensajeError("La contraseña anterior no es correcta, intente de nuevo");
                        tbContraseñaAnterior.Clear();
                        tbContraseña.Clear();
                        tbContraseñaRep.Clear();
                        tbContraseñaAnterior.Focus();
                    }

                }
                else
                {
                    MensajeError("La contraseñas no coinciden, intente de nuevo");
                    tbContraseña.Clear();
                    tbContraseñaRep.Clear();
                    tbContraseña.Focus();
                }
            }
            else
            {
                MensajeError("Campos vacíos, intente de nuevo");
                if (tbContraseñaAnterior.Text == "")
                    tbContraseñaAnterior.Focus();
                else if (tbContraseña.Text == "")
                {
                    tbContraseña.Focus();
                    tbContraseñaRep.Clear();
                }

                else
                    tbContraseñaRep.Focus();
                
            }
        }
    }
}
