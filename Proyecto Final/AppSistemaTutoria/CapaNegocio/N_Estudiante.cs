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

        public static DataTable MostrarTutorados(string CodDocente)
        {
            return new D_Estudiante().MostrarTutorados(CodDocente);
        }

        public static DataTable BuscarRegistros(string Texto)
        {
            return new D_Estudiante().BuscarRegistros(Texto);
        }

        public static DataTable BuscarTutorados(string CodDocente, string Texto)
        {
            return new D_Estudiante().BuscarTutorados(CodDocente, Texto);
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
