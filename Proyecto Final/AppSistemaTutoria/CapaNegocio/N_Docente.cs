using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Docente
    {
        readonly D_Docente ObjDocente = new D_Docente();

        public static DataTable MostrarRegistros()
        {
            return new D_Docente().MostrarRegistros();
        }

        public static DataTable BuscarRegistros(string Texto)
        {
            return new D_Docente().BuscarRegistros(Texto);
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
