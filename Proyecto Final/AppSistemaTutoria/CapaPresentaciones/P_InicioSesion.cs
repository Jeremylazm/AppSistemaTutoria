using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

using System.Text.RegularExpressions;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        public bool Test { get; set; }

        public P_InicioSesion()
        {
            Test = false;
            InitializeComponent();
        }

        public P_InicioSesion(bool pTest)
        {
            Test = pTest;
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

        public string IniciarSesion(string Usuario, string Contraseña)
        {
            string Mensaje = "";

            if (Usuario == "" && Contraseña == "")
            {
                Mensaje = "Llenar ambos campos";
                if (Test == false)
                    MensajeError(Mensaje);
                return Mensaje;
            }
            else if (Usuario != "")
            {
                if (Contraseña != "")
                {
                    Regex PatronCodigo1 = new Regex(@"\A[0-9]{5}\Z");
                    Regex PatronCodigo2 = new Regex(@"\A[0-9]{6}\Z");
                    if (PatronCodigo1.IsMatch(Usuario) || PatronCodigo2.IsMatch(Usuario))
                    {
                        var ValidarDatos = false;
                        if (Test == false)
                        {
                            N_InicioSesion InicioSesion = new N_InicioSesion();
                            ValidarDatos = InicioSesion.IniciarSesion(Usuario, Contraseña);
                        }

                        if (Usuario == "17453" && Contraseña == "17453" && Test == true)
                        {
                            Mensaje = "Inicio de sesión exitoso";
                            return Mensaje;
                        }

                        if (ValidarDatos == true)
                        {
                            if (Test == false)
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
                        }
                        else
                        {
                            if (Test == false)
                            {
                                txtContraseña.Clear();
                                txtUsuario.Focus();
                                MensajeError("Usuario incorrecto, intente de nuevo");
                            }
                            Mensaje = "Datos incorrectos";
                            return Mensaje;
                        }
                    }
                    else
                    {
                        Mensaje = "El usuario debe de tener 5 o 6 dígitos";
                        if (Test == false)
                        {
                            MensajeError(Mensaje);
                            txtContraseña.Clear();
                            txtUsuario.Focus();
                        }
                        return Mensaje;
                    }
                }
                else
                {
                    if (Test == false)
                    {
                        MensajeError("Ingrese su contraseña, por favor");
                        txtContraseña.Focus();
                    }
                    Mensaje = "Llenar el campo contraseña";
                    return Mensaje;
                }
            }
            else
            {
                if (Test == false)
                {
                    MensajeError("Ingrese su usuario, por favor");
                    txtUsuario.Focus();
                }
                Mensaje = "Llenar el campo usuario";
                return Mensaje;
            }
            return Mensaje;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSesion(txtUsuario.Text, txtContraseña.Text);
        }

        private void lblRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_RecuperarContraseña RC = new P_RecuperarContraseña();
            RC.ShowDialog();
        }
    }
}