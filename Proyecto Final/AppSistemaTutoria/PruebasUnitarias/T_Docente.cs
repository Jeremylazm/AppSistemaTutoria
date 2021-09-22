using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebasUnitarias
{
    /// <summary>
    /// Summary description for T_Docente
    /// </summary>
    [TestClass]
    public class T_Docente
    {
        // Definir variables globales para las pruebas unitarias
        readonly P_DatosDocente Docente = new P_DatosDocente (true);
        //readonly string RutaImagenDocente = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../CapaPresentaciones/Iconos/Perfil Docente.png");

        [TestMethod]
        public void CodigoVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar el código";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        //								
        [TestMethod]
        public void ApellidoPaternoVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar el apellido paterno";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }

        [TestMethod]
        public void ApellidoMaternoVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar el apellido materno";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void NombreVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar el nombre";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void EmailVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar el email";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void DireccionVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar la dirección";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void TelefonoVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe llenar el telefono";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void CategoriaVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe elegir la categoría";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void SubcategoriaVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe elegir la subcategoría";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void RegimenVacio()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Debe elegir el régimen";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void CodigoInvalido()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "633a1", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "El formato del código es incorrecto";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void TelefonoInvalido()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "98459033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "El formato del teléfono es incorrecto";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(false, EsValido);
        }
        [TestMethod]
        public void InsertarDatosValidos()
        {
            //Obtener mensaje al insertar datos válidos
            bool EsValido;
            string MensajePrueba = Docente.VerificarDatosDocente(
                out EsValido, "63321", "TICONA", "PARI", "GUZMAN", "63321@unsaac.edu.pe",
                "AV. BOLIVAR 211", "984589033", "NOMBRADO", "ASOCIADO", "DEDICACIÓN EXCLUSIVA", "IN", "DISPONIBLE");
            // Mensaje de prueba esperado
            string MensajeEsperado = "Registro insertado correctamente";
            //Verificar si los mensajes pasan la prueba
            Assert.AreEqual(MensajeEsperado, MensajePrueba);
            //Verificar variable EsValido da el valor correcto
            Assert.AreEqual(true, EsValido);
        }

    }
}
