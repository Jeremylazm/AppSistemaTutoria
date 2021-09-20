using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CapaEntidades;
using ImageMagick;
namespace CapaDatos
{
    public class D_FichaTutoria
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        public void InsertarFichaTutoria(E_FichaTutoria FichaTutoria)
        {

            SqlCommand Comando = new SqlCommand("spuInsertarFichaTutoria", Conectar)
            {
                CommandType = CommandType.StoredProcedure

            };
            Comando.Parameters.AddWithValue("@CodDocente", FichaTutoria.CodDocente);
            Comando.Parameters.AddWithValue("@CodEstudiante", FichaTutoria.CodEstudiante);
            Comando.Parameters.AddWithValue("@Semestre", FichaTutoria.Semestre);
            Comando.Parameters.AddWithValue("@Fecha", FichaTutoria.Fecha.ToString());
            Comando.Parameters.AddWithValue("@Dimension", FichaTutoria.Dimension);
            Comando.Parameters.AddWithValue("@Descripcion", FichaTutoria.Descripcion);
            Comando.Parameters.AddWithValue("@Referencia", FichaTutoria.Referencia);
            Comando.Parameters.AddWithValue("@Observaciones", FichaTutoria.Observaciones);

            Comando.ExecuteNonQuery();

        }
        public void EditarFichaTutoria(E_FichaTutoria FichaTutoria)
        {
            string Respuesta;
            try
            {
                SqlCommand Comando = new SqlCommand("spuActualizarFichaTutoria", Conectar)
                {
                    CommandType = CommandType.StoredProcedure

                };

                Comando.Parameters.AddWithValue("@CodTutoria", FichaTutoria.CodFichaTutoria);
                Comando.Parameters.AddWithValue("@CodTutoria", FichaTutoria.CodDocente);
                Comando.Parameters.AddWithValue("@CodTutoria", FichaTutoria.CodEstudiante);
                Comando.Parameters.AddWithValue("@CodTutoria", FichaTutoria.Semestre);
                Comando.Parameters.AddWithValue("@Fecha", FichaTutoria.Fecha.ToString());
                Comando.Parameters.AddWithValue("@Dimension", FichaTutoria.Dimension);
                Comando.Parameters.AddWithValue("@Descripcion", FichaTutoria.Descripcion);
                Comando.Parameters.AddWithValue("@Referencia", FichaTutoria.Referencia);
                Comando.Parameters.AddWithValue("@Observaciones", FichaTutoria.Observaciones);

                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar el registro";
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }

        }
        public DataTable MostrarRegistros(string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarFichaTutorias", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }
    }
}
