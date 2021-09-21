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
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_InformacionTutor : Form
    {
        // Atributo Usuario
        public string Usuario = "";
        // Constructor
        public P_InformacionTutor( string pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
            CargarDatosTutor();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void CargarDatosTutor()
        {
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
            // Asignamos a cada celda los valores correspondientes

            txtDocente.Text = Fila[1].ToString() + " " + Fila[2].ToString() +
                        " " + Fila[3].ToString();
            txtEmail.Text = Fila[4].ToString();
            txtDireccion.Text = Fila[5].ToString();
            txtTelefono.Text = Fila[6].ToString();
            txtEscProfesional.Text = Fila[7].ToString();
            txtHorario.Text = Fila[8].ToString();
            
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
