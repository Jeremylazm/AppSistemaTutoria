using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Estudiante
    {
        readonly D_Estudiante ObjEstudiante = new D_Estudiante();

        public static DataTable MostrarRegistros(string CodEstudiante)
        {
            return new D_Estudiante().MostrarRegistros(CodEstudiante);
        }

        public static DataTable MostrarEstudiantesSinTutor(string CodEstudiante)
        {
            return new D_Estudiante().MostrarEstudiantesSinTutor(CodEstudiante);
        }

        public static DataTable BuscarRegistro(string CodEstudiante)
        {
            return new D_Estudiante().BuscarRegistro(CodEstudiante);
        }

        public static DataTable BuscarRegistros(string CodEstudiante, string Texto)
        {
            return new D_Estudiante().BuscarRegistros(CodEstudiante, Texto);
        }

        public static DataTable BuscarEstudiantesSinTutor(string CodEstudiante, string Texto, int Filas)
        {
            return new D_Estudiante().BuscarEstudiantesSinTutor(CodEstudiante, Texto, Filas);
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

        public void AsignarTutor(string CodEstudiante, string CodDocente)
        {
            ObjEstudiante.AsignarTutor(CodEstudiante, CodDocente);
        }

        public void EliminarTutor(string CodEstudiante)
        {
            ObjEstudiante.EliminarTutor(CodEstudiante);
        }
    }
}
