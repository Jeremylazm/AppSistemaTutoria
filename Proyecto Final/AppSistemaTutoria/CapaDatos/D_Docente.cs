using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using CapaEntidades;
using ImageMagick;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CapaDatos
{
    public class D_Docente
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        
        public DataTable MostrarRegistros(string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            
            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }
            
            return Resultado;
        }

        public DataTable MostrarTutores(string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarTutores", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
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
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable BuscarRegistro(string CodDocente)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable BuscarRegistros(string CodDocente, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable BuscarTutor(string CodDocente, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarTutor", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        public DataTable BuscarTutorados(string CodDocente, string Texto, int Filas)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarTutorados", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            Comando.Parameters.AddWithValue("@Filas", Filas);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public void InsertarRegistro(E_Docente Docente)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Docente.Perfil);
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Docente.Nombre);
            Comando.Parameters.AddWithValue("@Email", Docente.Email);
            Comando.Parameters.AddWithValue("@Direccion", Docente.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.Parameters.AddWithValue("@Categoria", Docente.Categoria);
            Comando.Parameters.AddWithValue("@Subcategoria", Docente.Subcategoria);
            Comando.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Docente.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Horario", Docente.Horario);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void ModificarRegistro(E_Docente Docente)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Docente.Perfil);
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Docente.Nombre);
            Comando.Parameters.AddWithValue("@Email", Docente.Email);
            Comando.Parameters.AddWithValue("@Direccion", Docente.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.Parameters.AddWithValue("@Categoria", Docente.Categoria);
            Comando.Parameters.AddWithValue("@Subcategoria", Docente.Subcategoria);
            Comando.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Docente.CodEscuelaP);
            Comando.Parameters.AddWithValue("@Horario", Docente.Horario);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void EliminarRegistro(E_Docente Docente)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}

