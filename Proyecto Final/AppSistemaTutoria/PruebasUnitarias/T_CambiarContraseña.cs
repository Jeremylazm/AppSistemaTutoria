using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        // -- Metodo validarpanelEnviarCodigo
        // Correo electronico vacio
        [TestMethod]
        public void TestCorreoNoIngresadoPanelEnviarCodigo()
        {
            // Iniciar varaibles
            string correoValido = "140156@unsaac.edu.pe";
            string correoIngresado = "";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelEnviarCodigo(correoValido, correoIngresado);
            // Iniciar respuesta esperada
            string respuestaEsperada = "01";
            // comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Correo electronico invalido
        [TestMethod]
        public void TestCorreoNoValidoPanelEnviarCodigo()
        {
            // Iniciar variables
            string correoValido = "140156@unsaac.edu.pe";
            string correoIngresado = "110156@unsaac.edu.pe";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelEnviarCodigo(correoValido, correoIngresado);
            // Iniciar respuesta esperada
            string respuestaEsperada = "00";
            // Comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Correo electronico valido
        [TestMethod]
        public void TestCorreoValidoPanelEnviarCodigo()
        {
            // Iniciar variables
            string correoValido = "140156@unsaac.edu.pe";
            string correoIngresado = "140156@unsaac.edu.pe";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelEnviarCodigo(correoValido, correoIngresado);
            // Iniciar respuesta esperada
            int longitudRespuestaPrueba = respuestaPrueba.Length;
            int longitudRespuestaEsperada = 6;
            // Comparar respuestas
            Assert.AreEqual(longitudRespuestaPrueba, longitudRespuestaEsperada);
        }
        // -- Metodo validarpanelVerificarCodigo
        // codigo de verificacion ingresado vacio
        [TestMethod]
        public void TestCodigoNoIngresadoPanelVerificarCodigo()
        {
            // Iniciar variables
            string codigoValido = "123457";
            string codigoIngresado = "";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelVerificarCodigo(codigoValido, codigoIngresado);
            // Iniciar respuesta esperada
            string respuestaEsperada = "01";
            // Comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // codigo de verificacion incorrecto
        [TestMethod]
        public void TestCodigoIncorrectoPanelVerificarCodigo()
        {
            // Iniciar variables
            string codigoValido = "123456";
            string codigoIngresado = "654321";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelVerificarCodigo(codigoValido, codigoIngresado);
            // Iniciar respuesta esperada
            string respuestaEsperada = "00";
            // comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // codigo de verificacion correcto
        [TestMethod]
        public void TestCodigoCorrectoPanelVerificarCodigo()
        {
            // Iniciar variables
            string codigoValido = "123457";
            string codigoIngresado = "123457";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelVerificarCodigo(codigoValido, codigoIngresado);
            // Iniciar respuesta esperada
            string respuestaEsperada = "1";
            // Comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // -- Metodo validarpanelCambiarContraseña
        // Contraseña anterior vacia
        [TestMethod]
        public void TestContraseñaAnteriorNoIngresadaPanelCambiarContraseña()
        {
            // Iniciar variables
            string contraseña = "";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "170115";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar respuesta esperada
            string respuestaEsperada = "000";
            // comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Contraseña nueva vacia
        [TestMethod]
        public void TestContraseñaNuevaNoIngresadaPanelCambiarContraseña()
        {
            // Iniciar variables
            string contraseña = "170115";
            string contraseñaNueva = "";
            string confirmarContraseña = "170115";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar respuesta esperada
            string respuestaEsperada = "001";
            // comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Contraseña de confirmacion vacia
        [TestMethod]
        public void TestContraseñaConfirmarNoIngresadaPanelCambiarContraseña()
        {
            // Iniciar variables
            string contraseña = "170115";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar respuesta esperada
            string respuestaEsperada = "010";
            // Comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Contraseña nueva no cumple requisitos >= 6
        [TestMethod]
        public void TestContraseñaLongitudNoAceptadaPanelCambiarContraseña()
        {
            // Iniciar Variables
            string contraseña = "170115";
            string contraseñaNueva = "17011";
            string confirmarContraseña = "17011";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar respuesta esperada
            string respuestaEsperada = "011";
            // Comparar soluciones
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // contraseña nueva no cumple requisitos <= 8
        [TestMethod]
        public void TestContraseñasNoCoincidenPanelCambiarContraseña()
        {
            // Iniciar variables
            string contraseña = "170115";
            string contraseñaNueva = "170116";
            string confirmarContraseña = "170115";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar respuesta esperada
            string respuestaEsperada = "100";
            // Comparar soluciones
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Contraseña anterior incorrecta
        [TestMethod]
        public void TestContraseñaAnteriorIncorrectaPanelCambiarContraseña()
        {
            // Iniciar variables
            string contraseña = "101010";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "170115";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar respuesta esperada
            string respuestaEsperada = "-1";
            // Comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
        // Datos correctos
        [TestMethod]
        public void TestParametrosCorrectosCambiarContraseña()
        {
            // Iniciar variables
            string contraseña = "170115";
            string contraseñaNueva = "170115";
            string confirmarContraseña = "170115";
            // Obtener respuesta de prueba
            string respuestaPrueba = cambiarContraseña.validarpanelCambiarContraseña("170115", contraseña, contraseñaNueva, confirmarContraseña, true);
            // Iniciar variable esperada
            string respuestaEsperada = "1";
            // Comparar respuestas
            Assert.AreEqual(respuestaPrueba, respuestaEsperada);
        }
    }
}
