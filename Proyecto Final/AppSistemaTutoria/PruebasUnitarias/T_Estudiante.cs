using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_Estudiante
    {
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

        // Caso de Prueba: Nombre vacio
        [TestMethod]
        public void NombreVacio()
        {
            // Obtener un mensaje tras introducir un nombre vacio
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Debe llenar el nombre";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Direccion vacia
        [TestMethod]
        public void DireccionVacia()
        {
            // Obtener un mensaje tras introducir una direccion vacia
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Debe llenar la dirección";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Telefono vacio
        [TestMethod]
        public void TelefonoVacio()
        {
            // Obtener un mensaje tras introducir un telefono vacio
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Debe llenar el teléfono";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Codigo invalido
        [TestMethod]
        public void CodigoInvalido()
        {
            // Obtener un mensaje tras introducir un codigo invalido
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "18291", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "El código deber ser de 6 caracteres numéricos";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Telefono invalido
        [TestMethod]
        public void TelefonoInvalido()
        {
            // Obtener un mensaje tras introducir un telefono invalido
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "98765432", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "El teléfono deber ser de 9 caracteres numéricos";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Telefono de referencia invalido
        [TestMethod]
        public void TelefonoReferenciaInvalido()
        {
            // Obtener un mensaje tras introducir un telefono de referencia invalido
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "98765432", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "El teléfono de referencia deber ser de 9 caracteres numéricos";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Insertar datos validos
        [TestMethod]
        public void InsertarDatosValidos()
        {
            // Establecer el modo en insertar
            Program.Evento = 0;

            // Obtener un mensaje tras insertar datos validos
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Registro insertado exitosamente";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Editar datos validos
        [TestMethod]
        public void EditarDatosValidos()
        {
            // Establecer el modo en editar
            Program.Evento = 1;

            // Obtener un mensaje tras editar datos validos
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");

            // Establecer el mensaje esperado para la prueba
            string MensajeEsperado = "Registro editado exitosamente";

            // Verificar si pasa o no la prueba
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}