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
            }

            return Resultado;
        }

        public DataTable MostrarTutorados(string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarTutorados", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
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

            foreach (DataRow Fila in Resultado.Rows)
            {
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable BuscarTutorados(string CodDocente, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

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
