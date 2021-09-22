using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
<<<<<<< HEAD
using System.Windows.Forms;
=======
using CapaEntidades;
>>>>>>> parent of 09b56f7 (Merge pull request #105 from Jeremylazm/revert-103-Raisa18)
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_InformacionTutor : Form
    {
<<<<<<< HEAD
        // Atributo para copnfirmar Test
        public bool Test { get; set; }

        // Constructor
        public P_InformacionTutor(string Usuario)
        {
            // No es un Test
            Test = false;
            // Buscamos el tutor del usuario
            DataTable Datos = N_Estudiante.BuscarTutor(Usuario);
            // Si no existe cargara el formulario vacio
            if (Datos.Rows.Count == 0)
            {
                InitializeComponent();
                CargarDatosTutor(null, "", "", "",
                        "", "", "");
            }
            else
            {
                InitializeComponent();
                object[] Fila = Datos.Rows[0].ItemArray;
                CargarDatosTutor(Fila[0], Fila[1].ToString() + " " + Fila[2].ToString() +
                        " " + Fila[3].ToString(), Fila[4].ToString(), Fila[5].ToString(),
                        Fila[6].ToString(), Fila[7].ToString(), Fila[8].ToString());
            }
        }
        // Constructor de Test
        public P_InformacionTutor(bool pTest)
        {
            Test = pTest;
=======
        // Atributo Usuario
        public string Usuario = "";
        // Constructor
        public P_InformacionTutor( string pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
            CargarDatosTutor();
>>>>>>> parent of 09b56f7 (Merge pull request #105 from Jeremylazm/revert-103-Raisa18)
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Modulos para cargar datos de tutor
        public string CargarDatosTutor(object pPerfil, string Docente, string Email, string Direccion, 
            string Telefono, string EscProfesional, string Horario)
        {
<<<<<<< HEAD
            // Cadena que nos servira para los test
            string Mensaje = "";
            // Mostramos mensasje si se tiene o no tutor
            if ((Docente.Trim() != "") &&
                (Email.Trim() != "") &&
                (Direccion != "") &&
                (Telefono.Trim() != "") &&
                (EscProfesional.Trim() != "") &&
                (Horario.Trim() != ""))
=======
            // Buscamos los datos del Tutor 
            DataTable Datos = N_Estudiante.BuscarTutor(Usuario);
            object[] Fila = Datos.Rows[0].ItemArray;
            // Es la imagen de perfil
            byte[] imagen;
            if (Fila.GetValue(0).GetType() == Type.GetType("System.DBNull"))
                imagen = null;
            else
                imagen = (byte[])Fila.GetValue(0);

            if (imagen == null)
>>>>>>> parent of 09b56f7 (Merge pull request #105 from Jeremylazm/revert-103-Raisa18)
            {
                Mensaje = "Datos de Tutor Cargados Exitosamente";
                if(Test == false)
                    MessageBox.Show(Mensaje);
            }
            else
            {
                Mensaje = "Ud. Aun no tiene un tutor asignado";
                if (Test == false)
                    MessageBox.Show(Mensaje);
            }
                // Datos de la imagen de perfil
            if (pPerfil != null)
            {
                byte[] imagen;
                if (pPerfil.GetType() == Type.GetType("System.DBNull"))
                    imagen = null;
                else
                    imagen = (byte[])pPerfil;

<<<<<<< HEAD
                if (imagen == null)
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    imgPerfil.Image = Image.FromFile(fullImagePath);
                }
                else
                {
                    byte[] Perfil = new byte[0];
                    Perfil = imagen;
                    MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                    imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
                }
            }
            // Asignamos a cada celda los valores correspondientes

            txtDocente.Text = Docente;
            txtEmail.Text = Email;
            txtDireccion.Text = Direccion;
            txtTelefono.Text = Telefono;
            txtEscProfesional.Text = EscProfesional;
            txtHorario.Text = Horario;

            // Retornamos el Mensaje
            return Mensaje;
=======
            txtDocente.Text = Fila[1].ToString() + " " + Fila[2].ToString() +
                        " " + Fila[3].ToString();
            txtEmail.Text = Fila[4].ToString();
            txtDireccion.Text = Fila[5].ToString();
            txtTelefono.Text = Fila[6].ToString();
            txtEscProfesional.Text = Fila[7].ToString();
            txtHorario.Text = Fila[8].ToString();
            
>>>>>>> parent of 09b56f7 (Merge pull request #105 from Jeremylazm/revert-103-Raisa18)
        }
        // Para hacer la imagen circular
        public Image HacerImagenCircular(Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);

            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }
            return tmp;
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEscProfesional_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
