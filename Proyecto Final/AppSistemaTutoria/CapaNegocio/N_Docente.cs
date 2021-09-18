using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Docente
    {
        readonly D_Docente ObjDocente = new D_Docente();

        public static DataTable MostrarRegistros(string CodDocente)
        {
            return new D_Docente().MostrarRegistros(CodDocente);
        }

        public static DataTable MostrarTutores(string CodDocente)
        {
            return new D_Docente().MostrarTutores(CodDocente);
        }

        public static DataTable MostrarTutorados(string CodDocente)
        {
            return new D_Docente().MostrarTutorados(CodDocente);
        }

        public static DataTable BuscarRegistro(string CodDocente)
        {
            return new D_Docente().BuscarRegistro(CodDocente);
        }

        public static DataTable BuscarRegistros(string CodDocente, string Texto)
        {
            return new D_Docente().BuscarRegistros(CodDocente, Texto);
        }

        public static DataTable BuscarTutor(string CodDocente, string Texto)
        {
            return new D_Docente().BuscarTutor(CodDocente, Texto);
        }

        public static DataTable BuscarTutorados(string CodDocente, string Texto, int Filas)
        {
            return new D_Docente().BuscarTutorados(CodDocente, Texto, Filas);
        }

        public void InsertarRegistros(E_Docente Docente)
        {
            ObjDocente.InsertarRegistro(Docente);
        }

        public void EditarRegistros(E_Docente Docente)
        {
            ObjDocente.ModificarRegistro(Docente);
        }

        public void EliminarRegistros(E_Docente Docente)
        {
            ObjDocente.EliminarRegistro(Docente);
        }
    }
}