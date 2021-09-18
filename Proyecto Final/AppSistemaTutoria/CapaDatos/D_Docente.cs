using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using CapaEntidades;
using ImageMagick;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CapaDatos
{
    public class D_Docente
    {
        // Definir la conexion a la base de datos
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Definir una llave de cifrado para descifrar la informacion personal del estudiante
        private readonly string Key = "key_estudiante";

        // Metodo para mostrar los docentes dados a un determinado director de escuela
        public DataTable MostrarRegistros(string CodDocente)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuMostrarDocentes"
            SqlCommand Comando = new SqlCommand("spuMostrarDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar el parametro necesario para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);
            
            // Recorrer las filas de la tabla de datos
            foreach (DataRow Fila in Resultado.Rows)
            {
                // Verificar si el perfil del docente es nulo
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    // Mostrar una imgen por defecto para el docente
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }

                // Cambiar el ancho de la imagen para que se visualice en la tabla
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }
            
            // Retornar la tabla de datos con los docentes de un determinado director de escuela
            return Resultado;
        }

        // Metodo para mostrar los tutores de un determinado director de escuela
        public DataTable MostrarTutores(string CodDocente)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuMostrarTutores"
            SqlCommand Comando = new SqlCommand("spuMostrarTutores", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar el parametro necesario para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Retornar la tabla de datos con los tutores de un determinado director de escuela
            return Resultado;
        }

        // Metodo para ver la informacion personal de un estudiante
        string VisibilidadIPersonal(string IPersonalCifrada, bool EsEstudiante = false)
        {
            // Mostrar o no la informacion personal de acuerdo al permiso otorgado

            // Verificar permiso de visibilidad
            string Permiso = IPersonalCifrada.Substring(IPersonalCifrada.Length - 4);

            //Eliminar el permiso
            IPersonalCifrada = IPersonalCifrada.Substring(0, IPersonalCifrada.Length - 5);

            // Si el usuario es estudiante, puede ver su informacion personal
            if (EsEstudiante)
            {
                // Retornar la la informacion personal desencriptada
                return E_Criptografia.DesencriptarRSA(IPersonalCifrada, Key);
            }

            // Si el tutor tiene permiso de visualizar la informacion personal
            if (Permiso == "VT=T")
            {
                // Retornar la la informacion personal desencriptada
                return E_Criptografia.DesencriptarRSA(IPersonalCifrada, Key);
            }
            else 
            {
                // Retornar la la informacion personal encriptada
                return IPersonalCifrada; //No desencriptar
            }
        }

        // Metodo para mostrar los tutorados de un tutor
        public DataTable MostrarTutorados(string CodDocente)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuMostrarTutorados"
            SqlCommand Comando = new SqlCommand("spuMostrarTutorados", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar el parametro necesario para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Recorrer las filas de la tabla de datos
            foreach (DataRow Fila in Resultado.Rows)
            {
                // Verificar si el perfil del docente es nulo
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    // Mostrar una imgen por defecto para el docente
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }

                // Cambiar el ancho de la imagen para que se visualice en la tabla
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }

                // Verificar si se concedio permiso al tutor para ver la informacion personal del estudiante
                if (Fila["ConcederPermiso"].Equals("SÍ"))
                {
                    // Desencriptar la informacion personal del estudiante
                    Fila["InformacionPersonal"] = VisibilidadIPersonal(Fila["InformacionPersonal"].ToString(), true);
                }
                else
                {
                    // Mostrar vacio la informacion personal del estudiante
                    Fila["InformacionPersonal"] = "";
                }
            }

            // Retornar la tabla de datos con los tutorados de un tutor
            return Resultado;
        }

        // Metodo para buscar un determinado docente (tabla de datos)
        public DataTable BuscarRegistro(string CodDocente)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuBuscarDocente"
            SqlCommand Comando = new SqlCommand("spuBuscarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar el parametro necesario para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Recorrer las filas de la tabla de datos
            foreach (DataRow Fila in Resultado.Rows)
            {
                // Verificar si el perfil del docente es nulo
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    // Mostrar una imgen por defecto para el docente
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }

                // Cambiar el ancho de la imagen para que se visualice en la tabla
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            // Retornar la tabla de datos con los datos del docente buscado
            return Resultado;
        }

        // Metodo para mostrar la tabla de docentes de un determinado director de escuela con algun filtro
        public DataTable BuscarRegistros(string CodDocente, string Texto)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuBuscarDocentes"
            SqlCommand Comando = new SqlCommand("spuBuscarDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Recorrer las filas de la tabla de datos
            foreach (DataRow Fila in Resultado.Rows)
            {
                // Verificar si el perfil del docente es nulo
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    // Mostrar una imgen por defecto para el docente
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }

                // Cambiar el ancho de la imagen para que se visualice en la tabla
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            // Retornar la tabla de datos con los docentes de un determinado director de escuela con algun filtro
            return Resultado;
        }

        // Metodo para mostrar los tutores de un determinado director de escuela con algun filtro
        public DataTable BuscarTutores(string CodDocente, string Texto)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuBuscarTutor"
            SqlCommand Comando = new SqlCommand("spuBuscarTutor", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Retornar la tabla de datos con los tutores de un determinado director de escuela con algun filtro
            return Resultado;
        }

        // Metodo para mostrar los tutorados de un tutor con algun filtro
        public DataTable BuscarTutorados(string CodDocente, string Texto, int Filas)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuBuscarTutorados"
            SqlCommand Comando = new SqlCommand("spuBuscarTutorados", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            Comando.Parameters.AddWithValue("@Filas", Filas);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Recorrer las filas de la tabla de datos
            foreach (DataRow Fila in Resultado.Rows)
            {
                // Verificar si el perfil del docente es nulo
                if (Fila["Perfil2"].GetType() == Type.GetType("System.DBNull"))
                {
                    // Mostrar una imgen por defecto para el docente
                    string RutaImagen = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(RutaImagen).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }

                // Cambiar el ancho de la imagen para que se visualice en la tabla
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }

                // Verificar si se concedio permiso al tutor para ver la informacion personal del estudiante
                if (Fila["ConcederPermiso"].Equals("SÍ"))
                {
                    // Desencriptar la informacion personal del estudiante
                    Fila["InformacionPersonal"] = VisibilidadIPersonal(Fila["InformacionPersonal"].ToString(), true);
                }
                else
                {
                    // Mostrar vacio la informacion personal del estudiante
                    Fila["InformacionPersonal"] = "";
                }
            }

            // Retornar la tabla de datos con los tutorados de un tutor con algun filtro
            return Resultado;
        }

        // Metodo para insertar un registro de docente
        public void InsertarRegistro(E_Docente Docente)
        {
            // Ejecutar el procedimiento almacenado "spuInsertarDocente"
            SqlCommand Comando = new SqlCommand("spuInsertarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
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

        // Metodo para editar un registro de docente
        public void EditarRegistro(E_Docente Docente)
        {
            // Ejecutar el procedimiento almacenado "spuActualizarDocente"
            SqlCommand Comando = new SqlCommand("spuActualizarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
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

        // Metodo para eliminar un registro de docente
        public void EliminarRegistro(E_Docente Docente)
        {
            // Ejecutar el procedimiento almacenado "spuEliminarDocente"
            SqlCommand Comando = new SqlCommand("spuEliminarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}

