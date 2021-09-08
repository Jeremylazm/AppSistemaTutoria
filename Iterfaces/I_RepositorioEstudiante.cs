// HOLAAAA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsFix.dsTutoriasTableAdapters;

namespace WinFormsFix.Iterfaces
{
    public interface I_RepositorioEstudiante
    {
        string BuscarEstudiante(string CodEstudiante);
        string AgregarEstudiante(string CodEstudiante, string Nombres, string Apellidos, string EscuelaProf, string Email, string Direccion, string Celular);
        string ModificarEstudiante(string CodEstudiante, string Nombres, string Apellidos, string EscuelaProf, string Email, string Direccion, string Celular);
        string EliminarEstudiante(string CodEstudiante);
        bool EstudianteValido(string CodEstudiante);
    }

    public class RepositorioEstudiante : I_RepositorioEstudiante
    {
       
        dsTutoriasTableAdapters.EstudianteTableAdapter ta = new dsTutoriasTableAdapters.EstudianteTableAdapter();

        public string BuscarEstudiante(string CodEstudiante)
        {
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dt.Rows[0];
            return rowEstudiante.CodEstudiante;
        }
        public string AgregarEstudiante(string CodEstudiante, string Nombres, string Apellidos, string EscuelaProf, string Email, string Direccion, string Celular)
        {
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dt.Rows[0];
            ta.Insertar(CodEstudiante,
                            Nombres,
                            Apellidos,
                            EscuelaProf,
                            Email,
                            Direccion,
                            Celular,
                            "NO CONSIGNA");
            return rowEstudiante.CodEstudiante;
        }
        public string ModificarEstudiante(string CodEstudiante, string Nombres, string Apellidos, string EscuelaProf, string Email, string Direccion, string Celular)
        {
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dt.Rows[0];
            ta.Modificar(CodEstudiante,
                            Nombres,
                            Apellidos,
                            EscuelaProf,
                            Email,
                            Direccion,
                            Celular,
                            "NO CONSIGNA");
            return rowEstudiante.CodEstudiante;
        }
        public string EliminarEstudiante(string CodEstudiante)
        {
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dt.Rows[0];
            ta.Eliminar(CodEstudiante);
            return rowEstudiante.CodEstudiante;
        }
        public bool EstudianteValido(string CodEstudiante)
        {
            dsTutorias.EstudianteDataTable dt = ta.GetDataByCodEstudiante(CodEstudiante);
            dsTutorias.EstudianteRow rowEstudiante = (dsTutorias.EstudianteRow)dt.Rows[0];
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
