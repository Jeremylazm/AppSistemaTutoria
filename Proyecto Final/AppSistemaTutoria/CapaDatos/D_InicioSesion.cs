using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;



namespace CapaDatos
{
    public class D_InicioSesion
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        public bool IniciarSesion(string Usuario, string Contraseña)
        {
            SqlCommand Comando = new SqlCommand("spuIniciarSesion", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Usuario", Usuario);
            Comando.Parameters.AddWithValue("@Contraseña", Contraseña);

            SqlDataReader LeerFilas = Comando.ExecuteReader();
            if (LeerFilas.HasRows)
            {
                while (LeerFilas.Read())
                {
                    E_InicioSesion.Perfil = (byte[])LeerFilas.GetValue(0);
                    E_InicioSesion.Usuario = LeerFilas.GetString(1);
                    E_InicioSesion.Contraseña = LeerFilas.GetString(2);
                    E_InicioSesion.Acceso = LeerFilas.GetString(3);
                    E_InicioSesion.Datos = LeerFilas.GetString(4);
                }
                return true;
            }
            else
                return false;
        }
        public void ModificarRegistro(D_InicioSesion inicioSesion)
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
            Comando.Parameters.AddWithValue("@InformacionPersonal", Estudiante.InformacionPersonal);
            //Comando.Parameters.AddWithValue("@EstadoFisico", Estudiante.EstadoFisico);
            //Comando.Parameters.AddWithValue("@EstadoMental", Estudiante.EstadoMental);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
