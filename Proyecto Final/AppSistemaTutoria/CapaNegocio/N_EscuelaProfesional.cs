using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class N_EscuelaProfesional
    {
        readonly D_EscuelaProfesional ObjEscuelaProfesional = new D_EscuelaProfesional();

        public static DataTable MostrarRegistros(string CodDocente = "*")
        {
            return new D_EscuelaProfesional().MostrarRegistros(CodDocente);
        }
    }
}
