using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Docente
    {
        // Instanciar la clase de la capa de datos de docente
        readonly D_Docente ObjDocente = new D_Docente();

        // Metodo para mostrar los docentes dados a un determinado director de escuela
        public static DataTable MostrarRegistros(string CodDocente)
        {
            return new D_Docente().MostrarRegistros(CodDocente);
        }

        // Metodo para mostrar los tutores de un determinado director de escuela
        public static DataTable MostrarTutores(string CodDocente)
        {
            return new D_Docente().MostrarTutores(CodDocente);
        }

        // Metodo para mostrar los tutorados de un tutor
        public static DataTable MostrarTutorados(string CodDocente)
        {
            return new D_Docente().MostrarTutorados(CodDocente);
        }


        // Metodo para buscar un determinado docente (tabla de datos)
        public static DataTable BuscarRegistro(string CodDocente)
        {
            return new D_Docente().BuscarRegistro(CodDocente);
        }

        // Metodo para mostrar la tabla de docentes de un determinado director de escuela con algun filtro
        public static DataTable BuscarRegistros(string CodDocente, string Texto)
        {
            return new D_Docente().BuscarRegistros(CodDocente, Texto);
        }

        // Metodo para mostrar los tutores de un determinado director de escuela con algun filtro
        public static DataTable BuscarTutores(string CodDocente, string Texto)
        {
            return new D_Docente().BuscarTutores(CodDocente, Texto);
        }

        // Metodo para mostrar los tutorados de un tutor con algun filtro
        public static DataTable BuscarTutorados(string CodDocente, string Texto, int Filas)
        {
            return new D_Docente().BuscarTutorados(CodDocente, Texto, Filas);
        }

        // Metodo para insertar un registro de docente
        public void InsertarRegistros(E_Docente Docente)
        {
            ObjDocente.InsertarRegistro(Docente);
        }

        // Metodo para editar un registro de docente
        public void EditarRegistros(E_Docente Docente)
        {
            ObjDocente.EditarRegistro(Docente);
        }

        // Metodo para eliminar un registro de docente
        public void EliminarRegistros(E_Docente Docente)
        {
            ObjDocente.EliminarRegistro(Docente);
        }
    }
}