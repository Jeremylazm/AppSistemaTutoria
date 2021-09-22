using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocios
{
    public class N_FichaTutoria
    {

        readonly D_FichaTutoria ObjFichaTutoria = new D_FichaTutoria();

        public static DataTable MostrarRegistros(string CodDocente)
        {
            return new D_FichaTutoria().MostrarRegistros(CodDocente);
        }

        public void InsertarRegistros(E_FichaTutoria FichaTutoria)
        {
            ObjFichaTutoria.InsertarFichaTutoria(FichaTutoria);
        }

        public void EditarRegistros(E_FichaTutoria FichaTutoria)
        {
            ObjFichaTutoria.EditarFichaTutoria(FichaTutoria);
        }
        public void EliminarRegistros(E_FichaTutoria FichaTutoria)
        {
            ObjFichaTutoria.EliminarRegistro(FichaTutoria);
        }
        public static DataTable BuscarRegistros(string Tutoria, string Texto)
        {
            return new D_FichaTutoria().BuscarRegistros(Tutoria, Texto);
        }
    }
}
