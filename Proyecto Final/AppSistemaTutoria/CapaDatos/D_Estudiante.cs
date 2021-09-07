using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using CapaEntidades;
using ImageMagick;

namespace CapaDatos
{
    public class D_Estudiante
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // makes nice round ellipse/circle images from rectangle images

        public Image CropImage(Image img)
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

        public static Image MakeCircleImage(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gpImg = new GraphicsPath())
            {

                gpImg.AddEllipse(0, 0, img.Width, img.Height);
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    grp.Clear(Color.White);
                    grp.SetClip(gpImg);
                    grp.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }

        public Image ClipToCircle(Image srcImage, PointF center, float radius, Color backGround)
        {
            Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);

            using (Graphics g = Graphics.FromImage(dstImage))
            {
                RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
                                                         radius * 2, radius * 2);

                // enables smoothing of the edge of the circle (less pixelated)
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // fills background color
                //using (Brush br = new SolidBrush(backGround))
                //{
                //    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                //}

                // adds the new ellipse & draws the image again 
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(r);
                g.SetClip(path);
                g.DrawImage(srcImage, 0, 0);

                return dstImage;
            }
        }

        public DataTable MostrarRegistros()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            
            foreach (DataRow Fila in Resultado.Rows)
            {
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }

                byte[] Perfil = new byte[0];
                Perfil = (byte[])Fila["Perfil2"];
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);

                Image PerfilImagen = Bitmap.FromStream(MemoriaPerfil);
                Image PerfilCircular = ClipToCircle(PerfilImagen, new PointF(PerfilImagen.Width / 2, PerfilImagen.Height / 2), PerfilImagen.Width / 2, Color.White);
                //Image PerfilCircular = CropImage(PerfilImagen);
                //Image PerfilCircular = MakeCircleImage(PerfilImagen);
                byte[] PerfilFinal = new byte[0];
                using (MemoryStream MemoriaPerfilFinal = new MemoryStream())
                {
                    PerfilCircular.Save(MemoriaPerfilFinal, PerfilImagen.RawFormat);
                    PerfilFinal = MemoriaPerfilFinal.ToArray();
                }

                Fila["Perfil2"] = PerfilFinal;
            }

            return Resultado;
        }

        public DataTable BuscarRegistros(string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        public void InsertarRegistro(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Estudiante.Perfil);
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Estudiante.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Estudiante.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            Comando.Parameters.AddWithValue("@Email", Estudiante.Email);
            Comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Estudiante.Telefono);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Estudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@PersonaReferencia", Estudiante.PersonaReferencia);
            Comando.Parameters.AddWithValue("@TelefonoReferencia", Estudiante.TelefonoReferencia);
            Comando.Parameters.AddWithValue("@EstadoFisico", Estudiante.EstadoFisico);
            Comando.Parameters.AddWithValue("@EstadoMental", Estudiante.EstadoMental);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void ModificarRegistro(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Estudiante.Perfil);
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Estudiante.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Estudiante.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            Comando.Parameters.AddWithValue("@Email", Estudiante.Email);
            Comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Estudiante.Telefono);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Estudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@PersonaReferencia", Estudiante.PersonaReferencia);
            Comando.Parameters.AddWithValue("@TelefonoReferencia", Estudiante.TelefonoReferencia);
            Comando.Parameters.AddWithValue("@EstadoFisico", Estudiante.EstadoFisico);
            Comando.Parameters.AddWithValue("@EstadoMental", Estudiante.EstadoMental);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void EliminarRegistro(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
