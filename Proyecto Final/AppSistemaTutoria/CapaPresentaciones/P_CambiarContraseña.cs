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
        // Atributos
        public string Usuario = "";
        public string Correo = "";
        private string codigo_verificacion = "";
        // Metodos
        public P_CambiarContraseña()
        {
            InitializeComponent();
        }
        public P_CambiarContraseña(bool test) { }
        #region Metodos generales
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private DialogResult MensajeConfirmacion(string Mensaje)
        {
            return MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        public string EnviarCodigo(string Correo)
        {
            // Enviar un correo con un codigo de verificiacion random
            try
            {
                // Crear codigo random de 6 caracteres
                Random r = new Random();
                var x = r.Next(0, 1000000);
                string s = x.ToString("000000");

                // Enviar codigo de verificacion
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
                return s;
            }
            catch (Exception ex)
            {
                // Mostrar error
                MessageBox.Show(ex.Message);
                return "-1";
            }
        }
        public string validarpanelEnviarCodigo(string correoValido, string correoIngresado)
        {
            // Verificar correo ingresado
            if (correoIngresado != "")
                // verificar correo valido
                if (correoIngresado == correoValido)
                    // enviar codigo de verificacion
                    return EnviarCodigo(correoValido);
                // Correo invalido
                else
                    return "00"; // 0: correo invalido
            // Correo no ingresado
            else
                return "01"; // correo vacio
        }
        public string validarpanelVerificarCodigo(string codigoValido, string codigoIngresado)
        {
            // Verificar que se ingresó codigo
            if (codigoIngresado != "")
                // Verifcar código valido
                if (codigoIngresado == codigoValido)
                    return "1";
                // Codigo no coincide
                else
                    return "00";
            // Codigo no fue ingresado
            else
                return "01";
        }
        public bool usuarioValido(string usuario, string contraseña)
        {
            N_InicioSesion InicioSesion = new N_InicioSesion();
            return InicioSesion.IniciarSesion(usuario, contraseña);
        }
        public string validarpanelCambiarContraseña(string usuario, string contraseña, string contraseñaNueva, string confirmarContraseña, bool test)
        {
            if (contraseña == "")
                return "000"; // contraseña vacia
            else if (contraseñaNueva == "")
                return "001"; // nueva contraseña vacia
            else if (confirmarContraseña == "")
                return "010"; // longitud de confirmar contraeña vacia
            else if (contraseñaNueva.Length < 6 || contraseñaNueva.Length > 8)
                return "011"; // nueva contraseña no esta en intervalo [6, 8]
            else if (contraseñaNueva != confirmarContraseña)
                return "100"; // contraseña nueva y repeticion son diferentes
            else
            {
                if (!usuarioValido(usuario, contraseña))
                    return "-1"; // contraseña incorrecta

                DialogResult Opcion = DialogResult.OK; // Ok para test unitario

                if (!test)
                    Opcion = MensajeConfirmacion("¿Realmente desea cambiar la contraseña ? ");

                if (Opcion == DialogResult.OK)
                {
                    N_InicioSesion InicioSesion = new N_InicioSesion();
                    bool CambioContraseñaValido = InicioSesion.EditarRegistros(usuario, contraseñaNueva);
                    if (CambioContraseñaValido)
                        return "1"; // contraseña cambiada
                    else
                        return "-2"; // contraseña no se pudo cambiar
                }
                return "2"; // Cancelar
            }
        }
        #endregion
        #region Eventos
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
            string correoIngresado = txtEmail.Text;
            if (correoIngresado != "")
                correoIngresado += lblDominioEmail.Text;

            string ans = validarpanelEnviarCodigo(Correo, correoIngresado);

            if (ans == "-1")
            {
                txtEmail.Focus();
                MessageBox.Show("El código no se pudo enviar");
            }
            else if (ans == "00") // Correo invalido
            {
                txtEmail.Text = "";
                txtEmail.Focus();
                MensajeError("Correo electrónico no coincide, intente de nuevo");
            }
            // Correo no ingresado
            else if (ans == "01")
            {
                txtEmail.Focus();
                MensajeError("Correo no ingresado, intente de nuevo");
            }
            else
            {
                MessageBox.Show("Código enviado");
                codigo_verificacion = ans;

                // mostrar panel de verificacion de codigo
                panelCorreo.Visible = false;
                panelVerificacion.Visible = true;
                panelVerificacion.BringToFront();
                lblEmail.Text = correoIngresado;
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            string ans = validarpanelCambiarContraseña(Usuario, txtContraseñaAnterior.Text, txtContraseñaNueva.Text, txtConfirmarContraseña.Text, false);

            if (ans == "000" || ans == "001" || ans == "010") // campos vacios
            {
                MensajeError("Campos vacíos, intente de nuevo");
                if (ans == "00") txtContraseñaAnterior.Focus(); // contraseña vacia
                else if (ans == "01") txtContraseñaNueva.Focus(); //Contraseña nueva vacia
                else if (ans == "10") txtConfirmarContraseña.Focus(); // Repeticion contraseña nueva vacia
            }

            else if (ans == "011") // longitud de nueva contraseña no está en el intervalo [6, 8]
            {
                MensajeError("Error, la longitud de la nueva contraseña debe estar contenida entre 6 y 8");
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                txtContraseñaNueva.Focus();
            }
            else if (ans == "100") // contraseña nueva y repeticion son diferentes
            {
                MensajeError("Nuevas contraseñas no coinciden, intente de nuevo");
                txtConfirmarContraseña.Clear();
                txtContraseñaNueva.Clear();
                txtContraseñaNueva.Focus();
            }
            else if (ans == "-1")
            {
                MensajeError("Contraseña anterior incorrecta, intente de nuevo");
                txtContraseñaAnterior.Clear();
                txtContraseñaNueva.Clear();
                txtConfirmarContraseña.Clear();
                txtContraseñaAnterior.Focus();
            }
            else if (ans == "-2")
                MensajeError("Error al cambiar la contraseña");

            else if (ans == "1")
            {
                MessageBox.Show("Contraseña cambiada correctamente");
                Close();
            }
        }

        private void btnValidarCodigo_Click(object sender, EventArgs e)
        {
            string ans = validarpanelVerificarCodigo(codigo_verificacion, txtCodigoVerificacion.Text);
            if (ans == "00") // codigo ingresado incorrecto
            {
                MensajeError("Los codigos no coinciden, intente de nuevo");
                txtCodigoVerificacion.Text = "";
                txtCodigoVerificacion.Focus();
            }
            else if (ans == "01") // codigo ingresado vacío
            {
                txtCodigoVerificacion.Focus();
                MensajeError("Campo codigo de verificación vacio, intente de nuevo");
            }
            else if (ans == "1") // validacion correcta
            {
                // Mostrar panel cambiar contraseña
                panelVerificacion.Visible = false;
                panelCambiarContraseña.Visible = true;
                panelCambiarContraseña.BringToFront();
            }
        }

        private void lblVolverEnviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string correo = lblEmail.Text;
            codigo_verificacion = EnviarCodigo(correo);
        }
        #endregion
    }
}
