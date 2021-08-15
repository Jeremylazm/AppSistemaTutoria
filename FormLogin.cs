using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WinFormsFix.dsTutoriasTableAdapters;

namespace WinFormsFix
{
    public partial class FormLogin : Form
    {
        // Drag and drop login
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Usuarios Table Adapter y DataTable
        private UsuariosTableAdapter taUsuarios = new UsuariosTableAdapter();
        private dsTutorias.UsuariosDataTable dtUsuarios = new dsTutorias.UsuariosDataTable();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            dtUsuarios = taUsuarios.GetDataByIdUsuario(textBoxUsuario.Text + "@unsaac.edu.pe");
            if (dtUsuarios.Rows.Count == 0)
            {
                MessageBox.Show("El usuario no existe");
                textBoxUsuario.Text = "";
                textBoxContraseña.Text = "";
            }
            else
            {
                dsTutorias.UsuariosRow rowUsuario = (dsTutorias.UsuariosRow)dtUsuarios[0];
                if (rowUsuario.Contraseña != textBoxContraseña.Text)
                {
                    MessageBox.Show("Contraseña incorrecta");
                    textBoxContraseña.Text = "";
                }
                else
                {
                    string TipoUsuario = rowUsuario.Tipo.ToString();
                    string[] G = textBoxUsuario.Text.Split('@');
                    if (TipoUsuario == "COORDINADOR")
                    {
                        FormCoordinador formCoordinador = new FormCoordinador(G[0]);
                        formCoordinador.Show();
                    }
                    if (TipoUsuario == "TUTOR")
                    {
                        FormTutor formTutor = new FormTutor(G[0]);
                        formTutor.Show();

                    }
                    if (TipoUsuario == "ESTUDIANTE")
                    {
                        FormEstudiante formEstudiante = new FormEstudiante(G[0]);
                        formEstudiante.Show();
                    }
                    this.Hide();
                }
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "User")
            {
                textBoxUsuario.Text = "";
                textBoxUsuario.ForeColor = Color.Black;
            }
        }

        private void textBoxUsuario_Leave(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "")
            {
                textBoxUsuario.Text = "User";
                textBoxUsuario.ForeColor = Color.DimGray;
            }
        }

        private void textBoxContraseña_Enter(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "Password")
            {
                textBoxContraseña.Text = "";
                textBoxContraseña.ForeColor = Color.Black;
                textBoxContraseña.UseSystemPasswordChar = true;
            }
        }

        private void textBoxContraseña_Leave(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "")
            {
                textBoxContraseña.Text = "Password";
                textBoxContraseña.ForeColor = Color.DimGray;
                textBoxContraseña.UseSystemPasswordChar = false;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.ActiveControl = panel1;
        }

        private void panelDDleft_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelDDright_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}