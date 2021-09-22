using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_FichaTutoria
    {
        //Falta adaptar Ficha Tutoria
        // Definir variables globales para las pruebas unitarias
        readonly P_DatosEstudiante Estudiante = new P_DatosEstudiante(true);
        readonly string RutaImagenEstudiante = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../CapaPresentaciones/Iconos/Perfil Estudiante.png");

        // Caso de Prueba: Codigo vacio
        [TestMethod]
        public void CodigoVacio()
        {
            // Obtener un mensaje tras introducir un codigo vacio
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Debe llenar el código";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Apellido paterno vacio
        [TestMethod]
        public void ApellidoPaternoVacio()
        {
            // Obtener un mensaje tras introducir un apellido paterno vacio
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Debe llenar el apellido paterno";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Apellido materno vacio
        [TestMethod]
        public void ApellidoMaternoVacio()
        {
            // Obtener un mensaje tras introducir un apellido materno vacio
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Debe llenar el apellido materno";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}
