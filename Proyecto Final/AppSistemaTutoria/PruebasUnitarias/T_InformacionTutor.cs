using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CapaPresentaciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_InformacionTutor
    {
        // Definir variables globales para las pruebas unitarias
        readonly P_InformacionTutor ITutor = new P_InformacionTutor(true);

        // Caso de Prueba: El Alumno no tiene Tutor
        [TestMethod]
        public void NoTieneTutor()
        {
            // Obtener un mensaje cuando el estudiante no tiene tutor
            string MensajePrueba = ITutor.CargarDatosTutor(null, "", "", "",
                        "", "", "");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Ud. Aun no tiene un tutor asignado";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
        // Caso de Prueba: El Alumno Tiene Tutor
        [TestMethod]
        public void TieneTutor()
        {
            // Obtener un mensaje cuando el estudiante tiene tutor
            string MensajePrueba = ITutor.CargarDatosTutor(null, "FLORES PACHECO LINO PRISCILIANO", "32403@unsaac.edu.pe", 
                "CALLE PERA 46", "932432187", "INGENIERÍA INFORMÁTICA Y DE SISTEMAS", "DISPONIBLE");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Datos de Tutor Cargados Exitosamente";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}
