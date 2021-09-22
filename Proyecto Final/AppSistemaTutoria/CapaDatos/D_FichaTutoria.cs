using CapaEntidades;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            Conectar.Open();
            //Comando.Parameters.AddWithValue("@CodTutoria", FichaTutoria.CodTutoria);
            Comando.Parameters.AddWithValue("@CodEstudiante", FichaTutoria.CodEstudiante);
            Comando.Parameters.AddWithValue("@Semestre", FichaTutoria.Semestre);
            Comando.Parameters.AddWithValue("@Fecha", FichaTutoria.Fecha);
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
                Conectar.Open();
                Comando.Parameters.AddWithValue("@CodEstudiante", FichaTutoria.CodEstudiante);
                Comando.Parameters.AddWithValue("@Semestre", FichaTutoria.Semestre);
                Comando.Parameters.AddWithValue("@Fecha", FichaTutoria.Fecha);
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
        public void EliminarRegistro(E_FichaTutoria CodTutoria)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarFichaTutoria", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodTutoria", CodTutoria.CodTutoria);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
        public DataTable BuscarRegistros(string Tutoria, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarFichaTutorias", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", Tutoria);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }
    }
}
