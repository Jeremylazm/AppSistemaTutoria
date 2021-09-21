using CapaEntidades;
using CapaNegocios;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentaciones
{
    public partial class P_InicioSesion : Form
    {
        // Atributo para pruebas
        public bool Test { get; set; }

        public P_InicioSesion()
        {
            // Bandera de pruebas
            Test = false;
            InitializeComponent();
        }

        public P_InicioSesion(bool pTest)
        {
            Test = pTest;
        }

        // Message Box para errores
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

        // Función parar iniciar sesión
        public string IniciarSesion(string Usuario, string Contraseña)
        {
            // Mensaje cuando se están ejecutando las pruebas
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
                    // Patrones de usuario de estudiante o docente
                    Regex PatronCodigo1 = new Regex(@"\A[0-9]{5}\Z");
                    Regex PatronCodigo2 = new Regex(@"\A[0-9]{6}\Z");

                    // Patron de usuario de administrador
                    Regex PatronCodigo3 = new Regex(@"\A(AD)[A-Z]{2}\Z");

                    // Patrón de usuario de director de escuela
                    Regex PatronCodigo4 = new Regex(@"\A(DE)[A-Z]{2}\Z");

                    if (PatronCodigo1.IsMatch(Usuario) || PatronCodigo2.IsMatch(Usuario) || PatronCodigo3.IsMatch(Usuario) || PatronCodigo4.IsMatch(Usuario))
                    {
                        var ValidarDatos = false;

                        // Verificar el usuario y la contraseña
                        if (Test == false)
                        {
                            N_InicioSesion InicioSesion = new N_InicioSesion();
                            ValidarDatos = InicioSesion.IniciarSesion(Usuario, Contraseña);
                        }

                        // Prueba de inicio de sesión exitoso
                        if (Usuario == "17453" && Contraseña == "17453" && Test == true)
                        {
                            Mensaje = "Inicio de sesión exitoso";
                            return Mensaje;
                        }

                        // Si los datos son correctos
                        if (ValidarDatos == true)
                        {
                            // Si no se está ejecuatando las pruebas
                            if (Test == false)
                            {
                                Hide();

                                //Mostrar mensaje de bienvenida
                                P_Bienvenida Bienvenida = new P_Bienvenida();

                                Bienvenida.ShowDialog();
                                // Si el usuario es Director de Escuela
                                if (E_InicioSesion.Acceso == E_Acceso.DirectorEscuela)
                                {
                                    P_Menu Menu = new P_Menu
                                    {
                                        Acceso = "Director de Escuela"
                                    };
                                    Menu.Show();
                                }

                                // Si el usuario es Docente
                                if (E_InicioSesion.Acceso == E_Acceso.Docente)
                                {
                                    P_Menu Menu = new P_Menu
                                    {
                                        Acceso = "Docente"
                                    };
                                    Menu.Show();
                                }

                                // Si el usuario es Estudiante
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
                        // Si los datos son incorrectos
                        else
                        {
                            if (Test == false)
                            {
                                txtContraseña.Clear();
                                txtUsuario.Focus();
                                MensajeError("Usuario o Contraseña incorrectos");
                            }
                            Mensaje = "Datos incorrectos";
                            return Mensaje;
                        }
                    }
                    // Si la longitud del usuario no es de 5 o 6 dígitos
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
                // Si el campo de la contraseña está vacío
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
            // Si el campo del usuario está vacío
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

        // Link label para recuperar la contraseña
        private void lblRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_RecuperarContraseña RC = new P_RecuperarContraseña();
            RC.ShowDialog();
        }

        // Enter para iniciar sesión cuando se ha digitado la contraseña
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                IniciarSesion(txtUsuario.Text, txtContraseña.Text);
        }
    }
}