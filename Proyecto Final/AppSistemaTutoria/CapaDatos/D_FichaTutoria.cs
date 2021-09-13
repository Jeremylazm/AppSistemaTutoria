using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class D_FichaTutoria
    {
        public string InsertarFichaTutoria(E_FichaTutoria FichaTutoria, ref SqlConnection Conexion, ref SqlTransaction Transaccion)
        {
            string Respuesta;
            try
            {
                SqlCommand Comando = new SqlCommand("spuInsertarFichaTutoria", Conexion)
                {
                    CommandType = CommandType.StoredProcedure,
                    Transaction = Transaccion
                };

                Comando.Parameters.AddWithValue("@CodTutoria", FichaTutoria.CodTutoria);
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

            return Respuesta;
        }
    }
}
