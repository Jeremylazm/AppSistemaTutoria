using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Tutoria
    {
        readonly D_FichaTutoria ObjFichaTutoria = new D_FichaTutoria();
        SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        
        public DataTable MostrarRegistros()
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarTutorias", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        public DataTable BuscarRegistros(string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarTutorias", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            return Resultado;
        }

        public string InsertarRegistro(E_Tutoria Tutoria, List<E_FichaTutoria> FichaTutoria)
        {
            string Respuesta;
            try
            {
                Conectar.Open();
                SqlTransaction Transaccion = Conectar.BeginTransaction();
                SqlCommand Comando = new SqlCommand
                {
                    Connection = Conectar,
                    Transaction = Transaccion,
                    CommandText = "spuInsertarTutoria",
                    CommandType = CommandType.StoredProcedure

                };

                SqlParameter ParIdVentas = new SqlParameter
                {
                    ParameterName = "@CodTutoria",
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Output
                };
                Comando.Parameters.Add(ParIdVentas);
                Comando.Parameters.AddWithValue("@CodTutoria", Tutoria.CodTutoria);
                Comando.Parameters.AddWithValue("@CodDocente", Tutoria.CodDocente);
                Comando.Parameters.AddWithValue("@CodEstudiante", Tutoria.CodEstudiante);

                Respuesta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al insertar el registro";

                if (Respuesta.Equals("OK"))
                {
                    Tutoria.CodTutoria = Comando.Parameters["@CodTutoria"].Value.ToString();
                    foreach (E_FichaTutoria FT in FichaTutoria)
                    {
                        FT.CodTutoria = Tutoria.CodTutoria;
                        Respuesta = ObjFichaTutoria.InsertarFichaTutoria(FT, ref Conectar, ref Transaccion);

                        if (!Respuesta.Equals("OK"))
                            break;
                    }
                }
                if (Respuesta.Equals("OK"))
                    Transaccion.Commit();
                else
                    Transaccion.Rollback();
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            finally
            {
                if (Conectar.State == ConnectionState.Open)
                    Conectar.Close();
            }

            return Respuesta;
        }

        public void ModificarRegistro(E_Tutoria Tutoria)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarTutoria", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodTutoria", Tutoria.CodTutoria);
            Comando.Parameters.AddWithValue("@CodDocente", Tutoria.CodDocente);
            Comando.Parameters.AddWithValue("@CodEstudiante", Tutoria.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void EliminarRegistro(E_Tutoria Tutoria)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarTutoria", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodTutoria", Tutoria.CodTutoria);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
