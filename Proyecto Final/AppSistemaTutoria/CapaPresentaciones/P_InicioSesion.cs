using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CapaEntidades;
using CapaNegocios;


namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        // Encryption key
        private readonly string Key = "passek159753_?&%";

        public P_InicioSesion()
        {
            InitializeComponent();
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtContraseña.Text != "")
                {
                    N_InicioSesion InicioSesion = new N_InicioSesion();

                    var ValidarDatos = InicioSesion.IniciarSesion(txtUsuario.Text, txtContraseña.Text);

                    if (ValidarDatos == true)
                    {
                        Hide();
                        P_Bienvenida Bienvenida = new P_Bienvenida();
                        Bienvenida.ShowDialog();
                        if (E_InicioSesion.Acceso == E_Acceso.DirectorEscuela)
                        {
                            P_Menu Menu = new P_Menu
                            {
                                Acceso = "Director de Escuela"
                            };
                            Menu.Show();
                        }
                        if (E_InicioSesion.Acceso == E_Acceso.Docente)
                        {
                            P_Menu Menu = new P_Menu
                            {
                                Acceso = "Docente"
                            };
                            Menu.Show();
                        }
                        if (E_InicioSesion.Acceso == E_Acceso.Estudiante)
                        {
                            P_Menu Menu = new P_Menu
                            {
                                Acceso = "Estudiante"
                            };
                            Menu.Show();
                        }
                    }
                    else
                    {
                        MensajeError("Usuario incorrecto, intente de nuevo");
                        txtContraseña.Clear();
                        txtUsuario.Focus();
                    }
                }
                else
                {
                    MensajeError("Ingrese su contraseña, por favor");
                    txtContraseña.Focus();
                }
            }
            else
            {
                MensajeError("Ingrese su usuario, por favor");
                txtUsuario.Focus();
            }
        }
        private void lblRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_RecuperarContraseña RC = new P_RecuperarContraseña();
            RC.ShowDialog();
        }
    }
}
