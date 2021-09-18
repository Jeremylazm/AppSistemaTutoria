using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_Estudiante
    {
        readonly P_DatosEstudiante Estudiante = new P_DatosEstudiante(true);
        readonly string RutaImagenEstudiante = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../CapaPresentaciones/Iconos/Perfil Estudiante.png");

        [TestMethod]
        public void CodigoVacio()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar el código";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void ApellidoPaternoVacio()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar el apellido paterno";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void ApellidoMaternoVacio()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar el apellido materno";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void NombreVacio()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar el nombre";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void DireccionVacia()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar la dirección";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void TelefonoVacio()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar el teléfono";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void CodigoInvalido()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "18291", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "El código deber ser de 6 caracteres numéricos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void TelefonoInvalido()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "98765432", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "El teléfono deber ser de 9 caracteres numéricos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void TelefonoReferenciaInvalido()
        {
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "98765432", "INFORMACIÓN");
            string MensajeEsperado = "El teléfono de referencia deber ser de 9 caracteres numéricos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void InsertarDatosValidos()
        {
            Program.Evento = 0;
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Registro insertado exitosamente";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        [TestMethod]
        public void EditarDatosValidos()
        {
            Program.Evento = 1;
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(RutaImagenEstudiante), "182916", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Registro editado exitosamente";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}
