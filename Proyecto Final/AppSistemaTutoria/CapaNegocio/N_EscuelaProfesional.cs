using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_EscuelaProfesional
    {
        readonly D_EscuelaProfesional ObjEscuelaProfesional = new D_EscuelaProfesional();

        public static DataTable MostrarRegistros()
        {
            return new D_EscuelaProfesional().MostrarRegistros();
        }
    }
}
