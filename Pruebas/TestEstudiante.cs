using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WinFormsFix.Iterfaces;
using WinFormsFix.Servicios;

namespace Pruebas
{
    [TestClass]
    public class TestEstudiante
    {
        [TestMethod]
        public void BuscarEstudiante()
        {
            //RepositorioEstudiante AuxInterfaz = new RepositorioEstudiante();
            //bool ValidarEstudiante = AuxInterfaz.EstudianteValido("182914");
            //string CodigoEstudiante = AuxInterfaz.BuscarEstudiante("182914");

            string CodEstudiante = "182914";

            Mock<I_RepositorioEstudiante> R_Estudiante = new Mock<I_RepositorioEstudiante>();
            R_Estudiante.Setup(a => a.EstudianteValido(CodEstudiante)).Returns(true);
            R_Estudiante.Setup(a => a.BuscarEstudiante(CodEstudiante)).Returns("182914");

            S_Estudiante Servicio = new S_Estudiante(R_Estudiante.Object);
            var CodEstudianteAux = Servicio.BuscarEstudianteBD(CodEstudiante);
            Assert.AreEqual(CodEstudiante, CodEstudianteAux);

            R_Estudiante.Verify(a => a.EstudianteValido(CodEstudiante));
            R_Estudiante.Verify(a => a.BuscarEstudiante(CodEstudiante));
        }

        [TestMethod]
        public void AgregarEstudiante()
        {
            string CodEstudiante = "182916";
            string Nombres = "JEREMY AXL";
            string Apellidos = "LAZO MENDOZA";
            string EscuelaProf = "IN";
            string Email = "182916@unsaac.edu.pe";
            string Direccion = "CUSCO";
            string Celular = "987654321";

            Mock<I_RepositorioEstudiante> R_Estudiante = new Mock<I_RepositorioEstudiante>();
            R_Estudiante.Setup(a => a.EstudianteValido(CodEstudiante)).Returns(false);
            R_Estudiante.Setup(a => a.AgregarEstudiante(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular)).Returns("182916");
            R_Estudiante.Setup(a => a.BuscarEstudiante(CodEstudiante)).Returns("182916");

            S_Estudiante Servicio = new S_Estudiante(R_Estudiante.Object);
            var CodEstudianteAux = Servicio.AgregarEstudianteBD(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular);
            Assert.AreEqual(CodEstudiante, CodEstudianteAux);

            R_Estudiante.Verify(a => a.EstudianteValido(CodEstudiante));
            R_Estudiante.Verify(a => a.AgregarEstudiante(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular));
            R_Estudiante.Verify(a => a.BuscarEstudiante(CodEstudiante));
        }

        [TestMethod]
        public void ModificarEstudiante()
        {
            string CodEstudiante = "182916";
            string Nombres = "JEREMY AXL";
            string Apellidos = "LAZO MENDOZA";
            string EscuelaProf = "IN";
            string Email = "182916@unsaac.edu.pe";
            string Direccion = "CUSCO";
            string Celular = "987654321";

            Mock<I_RepositorioEstudiante> R_Estudiante = new Mock<I_RepositorioEstudiante>();
            R_Estudiante.Setup(a => a.EstudianteValido(CodEstudiante)).Returns(true);
            R_Estudiante.Setup(a => a.ModificarEstudiante(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular)).Returns("182916");
            R_Estudiante.Setup(a => a.BuscarEstudiante(CodEstudiante)).Returns("182916");

            S_Estudiante Servicio = new S_Estudiante(R_Estudiante.Object);
            var CodEstudianteAux = Servicio.ModificarEstudianteBD(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular);
            Assert.AreEqual(CodEstudiante, CodEstudianteAux);

            R_Estudiante.Verify(a => a.EstudianteValido(CodEstudiante));
            R_Estudiante.Verify(a => a.ModificarEstudiante(CodEstudiante, Nombres, Apellidos, EscuelaProf, Email, Direccion, Celular));
            R_Estudiante.Verify(a => a.BuscarEstudiante(CodEstudiante));
        }

        [TestMethod]
        public void EliminarEstudiante()
        {
            string CodEstudiante = "182916";

            Mock<I_RepositorioEstudiante> R_Estudiante = new Mock<I_RepositorioEstudiante>();
            R_Estudiante.Setup(a => a.EstudianteValido(CodEstudiante)).Returns(true);
            R_Estudiante.Setup(a => a.EliminarEstudiante(CodEstudiante)).Returns("182916");
            R_Estudiante.Setup(a => a.BuscarEstudiante(CodEstudiante)).Returns("182916");

            S_Estudiante Servicio = new S_Estudiante(R_Estudiante.Object);
            var CodEstudianteAux = Servicio.EliminarEstudianteBD(CodEstudiante);
            Assert.AreEqual(CodEstudiante, CodEstudianteAux);

            R_Estudiante.Verify(a => a.EstudianteValido(CodEstudiante));
            R_Estudiante.Verify(a => a.EliminarEstudiante(CodEstudiante));
            R_Estudiante.Verify(a => a.BuscarEstudiante(CodEstudiante));
        }
    }
}
