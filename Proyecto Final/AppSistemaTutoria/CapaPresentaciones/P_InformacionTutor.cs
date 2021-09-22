using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_InformacionTutor : Form
    {
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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Modulos para cargar datos de tutor
        public string CargarDatosTutor(object pPerfil, string Docente, string Email, string Direccion, 
            string Telefono, string EscProfesional, string Horario)
        {
            // Cadena que nos servira para los test
            string Mensaje = "";
            // Mostramos mensasje si se tiene o no tutor
            if ((Docente.Trim() != "") &&
                (Email.Trim() != "") &&
                (Direccion != "") &&
                (Telefono.Trim() != "") &&
                (EscProfesional.Trim() != "") &&
                (Horario.Trim() != ""))
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

                if (imagen == null)
                {
                    imgPerfil.Image = Properties.Resources.Perfil_Docente as Image;
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
            if (Test == false)
            {
                txtDocente.Text = Docente;
                txtEmail.Text = Email;
                txtDireccion.Text = Direccion;
                txtTelefono.Text = Telefono;
                txtEscProfesional.Text = EscProfesional;
                txtHorario.Text = Horario;
            }

            // Retornamos el Mensaje
            return Mensaje;
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
