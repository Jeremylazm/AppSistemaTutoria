using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Estudiante
    {
        readonly D_Estudiante ObjEstudiante = new D_Estudiante();

        public static DataTable MostrarRegistros()
        {
            return new D_Estudiante().MostrarRegistros();
        }

        public static DataTable BuscarRegistros(string Texto)
        {
            return new D_Estudiante().BuscarRegistros(Texto);
        }

        public void InsertarRegistros(E_Estudiante Estudiante)
        {
            ObjEstudiante.InsertarRegistro(Estudiante);
        }

        public void EditarRegistros(E_Estudiante Estudiante)
        {
            ObjEstudiante.ModificarRegistro(Estudiante);
        }

        public void EliminarRegistros(E_Estudiante Estudiante)
        {
            ObjEstudiante.EliminarRegistro(Estudiante);
        }
    }
}
