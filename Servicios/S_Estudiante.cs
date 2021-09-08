using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsFix.Iterfaces;
// xd
namespace WinFormsFix.Servicios
{
    public class S_Estudiante
    {
        private readonly I_RepositorioEstudiante aRepositorioEstudiante;

        public S_Estudiante(I_RepositorioEstudiante pRepositorioEstudiante)
        {
            aRepositorioEstudiante = pRepositorioEstudiante;
        }

        public string ConsultarEstudiante(string CodEstudiante)
        {
            return aRepositorioEstudiante.BuscarEstudiante(CodEstudiante);
        }

        public string BuscarEstudianteBD(string CodEstudiante)
        {
            if (!aRepositorioEstudiante.EstudianteValido(CodEstudiante))
            {
                throw new Exception("Estudiante no válido");
            }

            var RetornarCodEstudiante = aRepositorioEstudiante.BuscarEstudiante(CodEstudiante);

            return RetornarCodEstudiante;
        }

        public string AgregarEstudianteBD(string CodEstudiante, string Nombres, string Apellidos, string EscuelaProf, string Email, string Direccion, string Celular)
        {
            if (aRepositorioEstudiante.EstudianteValido(CodEstudiante))
            {
                throw new Exception("Estudiante no válido");
            }

            var RetornarCodEstudiante = aRepositorioEstudiante.AgregarEstudiante(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular);

            return ConsultarEstudiante(RetornarCodEstudiante);
        }

        public string ModificarEstudianteBD(string CodEstudiante, string Nombres, string Apellidos, string EscuelaProf, string Email, string Direccion, string Celular)
        {
            if (!aRepositorioEstudiante.EstudianteValido(CodEstudiante))
            {
                throw new Exception("Estudiante no válido");
            }

            var RetornarCodEstudiante = aRepositorioEstudiante.ModificarEstudiante(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular);

            return ConsultarEstudiante(RetornarCodEstudiante);
        }

        public string EliminarEstudianteBD(string CodEstudiante)
        {
            if (!aRepositorioEstudiante.EstudianteValido(CodEstudiante))
            {
                throw new Exception("Estudiante no válido");
            }

            var RetornarCodEstudiante = aRepositorioEstudiante.EliminarEstudiante(CodEstudiante);

            return ConsultarEstudiante(RetornarCodEstudiante);
        }
    }
}
