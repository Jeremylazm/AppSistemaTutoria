using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_EncabezadoInforme
    {

        public string CodFicha { get; set; }
        public string CodEstudiante { get; set; }
        public string Fecha { get; set; }
        public string Estudiante { get; set; }
        public string Semestre { get; set; }
        public string Dimension { get; set; }
        public string Descripcion { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }


        //lista para almacenar los valores de las filas
        public List<E_FilaTabla> Filas = new List<E_FilaTabla>();

    }
}
