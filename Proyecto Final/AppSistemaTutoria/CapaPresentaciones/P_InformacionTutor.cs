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
        public string Usuario = "";
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
            SqlConnection Conexion = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; DataBase = db_a7878d_BDSistemaTutoria; Integrated Security = true");
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT D.Perfil, D.APaterno, D.AMaterno, D.Nombre, D.Email, D.Direccion, D.Telefono, " +
                "P.Nombre, D.Horario FROM(((TEstudiante E INNER JOIN TTutoria T " +
                "ON E.CodEstudiante = T.CodEstudiante) INNER JOIN TDocente D ON T.CodDocente = D.CodDocente)" +
                "INNER JOIN TEscuela_Profesional P ON D.CodEscuelaP = P.CodEscuelaP) WHERE E.CodEstudiante = @CodEstudiante", Conexion);

                cmd.Parameters.AddWithValue("@CodEstudiante", Usuario);
                Conexion.Open();
                SqlDataReader Registro = cmd.ExecuteReader();
                if (Registro.Read())
                {
                    byte[] imagen;
                    if (Registro.GetValue(0).GetType() == Type.GetType("System.DBNull"))
                        imagen = null;
                    else
                        imagen = (byte[])Registro.GetValue(0);

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

                    txtDocente.Text = Registro[1].ToString() + " " + Registro[2].ToString() + 
                        " " + Registro[3].ToString();
                    txtEmail.Text = Registro[4].ToString();
                    txtDireccion.Text = Registro[5].ToString();
                    txtTelefono.Text = Registro[6].ToString();
                    txtEscProfesional.Text = Registro[7].ToString();
                    txtHorario.Text = Registro[8].ToString();
                }
                Conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
