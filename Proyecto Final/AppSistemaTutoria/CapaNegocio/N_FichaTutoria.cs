using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Data;

namespace CapaNegocio
{
    class N_FichaTutoria
    {
        
        readonly D_FichaTutoria ObjEstudiante = new D_FichaTutoria();

        public static DataTable MostrarRegistros(string CodDocente)
        {
            return new D_FichaTutoria().MostrarRegistros(CodDocente);
        }

        public void InsertarRegistros(E_FichaTutoria FichaTutoria)
        {
            ObjEstudiante.InsertarFichaTutoria(FichaTutoria);
        }

        public void EditarRegistros(E_FichaTutoria FichaTutoria)
        {
            ObjEstudiante.EditarFichaTutoria(FichaTutoria);
        }
    }
}
