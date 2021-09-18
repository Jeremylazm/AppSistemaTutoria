using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CapaPresentaciones;

namespace PruebasUnitarias
{
    /// <summary>
    /// Summary description for T_CambiarContraseña
    /// </summary>
    [TestClass]
    public class T_CambiarContraseña
    {
        readonly P_CambiarContraseña cambiarContraseña = new P_CambiarContraseña(true);
        public T_CambiarContraseña()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        // Metodo EnviarCodigo
        [TestMethod]
        public void TestLongitudCodigoVerificacion()
        {
            string codigoPrueba = cambiarContraseña.EnviarCodigo("140156@unsaac.edu.pe");
            int longitudCodigoPrueba = codigoPrueba.Length;
            int longitudCodigoEsperada = 6;
            Assert.AreEqual(longitudCodigoPrueba, longitudCodigoEsperada);
        }
        // Metodo validarpanelEnviarCodigo
        [TestMethod]
        public void TestCorreoNoIngresadoPanelEnviarCodigo()
        {
            string correoValido = "140156@unsaac.edu.pe";
            string correoIngresado = "";
            string respuestaPrueba = cambiarContraseña.validarpanelEnviarCodigo(correoValido, correoIngresado);

            string respuestaEsperada = "01";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        [TestMethod]
        public void TestCorreoNoValidoPanelEnviarCodigo()
        {
            string correoValido = "140156@unsaac.edu.pe";
            string correoIngresado = "110156@unsaac.edu.pe";
            string respuestaPrueba = cambiarContraseña.validarpanelEnviarCodigo(correoValido, correoIngresado);

            string respuestaEsperada = "00";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        [TestMethod]
        public void TestCorreoValidoPanelEnviarCodigo()
        {
            string correoValido = "140156@unsaac.edu.pe";
            string correoIngresado = "140156@unsaac.edu.pe";
            string respuestaPrueba = cambiarContraseña.validarpanelEnviarCodigo(correoValido, correoIngresado);
            int longitudRespuestaPrueba = respuestaPrueba.Length;
            int longitudRespuestaEsperada = 6;
            Assert.AreEqual(longitudRespuestaPrueba, longitudRespuestaEsperada);
        }
        // Metodo validarpanelVerificarCodigo
        [TestMethod]
        public void TestCodigoNoIngresadoPanelVerificarCodigo()
        {
            string codigoValido = "123457";
            string codigoIngresado = "";
            string respuestaPrueba = cambiarContraseña.validarpanelVerificarCodigo(codigoValido, codigoIngresado);

            string respuestaEsperada = "01";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        [TestMethod]
        public void TestCodigoIncorrectoPanelVerificarCodigo()
        {
            string correoValido = "123456";
            string correoIngresado = "654321";
            string respuestaPrueba = cambiarContraseña.validarpanelVerificarCodigo(correoValido, correoIngresado);

            string respuestaEsperada = "00";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        [TestMethod]
        public void TestCodigoCorrectoPanelVerificarCodigo()
        {
            string correoValido = "123456";
            string correoIngresado = "123456";
            string respuestaPrueba = cambiarContraseña.validarpanelVerificarCodigo(correoValido, correoIngresado);

            string respuestaEsperada = "1";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Metodo validarpanelCambiarContraseña
        [TestMethod]
        public void TestContraseñaAnteriorNoIngresadaPanelCambiarContraseña()
        {
            string contraseña = "";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "170115";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "000";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        public void TestContraseñaNuevaNoIngresadaPanelCambiarContraseña()
        {
            string contraseña = "170115";
            string contraseñaNueva = "";
            string confirmarContraseña = "170115";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "001";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        public void TestContraseñaConfirmarNoIngresadaPanelCambiarContraseña()
        {
            string contraseña = "170115";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "010";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        public void TestContraseñaLongitudNoAceptadaPanelCambiarContraseña()
        {
            string contraseña = "170115";
            string contraseñaNueva = "17011";
            string confirmarContraseña = "17011";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "011";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        public void TestContraseñasNoCoincidenPanelCambiarContraseña()
        {
            string contraseña = "170115";
            string contraseñaNueva = "170116";
            string confirmarContraseña = "170115";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "100";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        public void TestContraseñaAnteriorIncorrectaPanelCambiarContraseña()
        {
            string contraseña = "101010";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "170115";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "-1";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        public void TestParametrosCorrectosCambiarContraseña()
        {
            string contraseña = "170115";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "170115";

            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);

            string respuestaEsperada = "1";
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
    }
}
