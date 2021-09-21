using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_InicioSesion
    {
        readonly P_InicioSesion InicioSesion = new P_InicioSesion(true);

        [TestMethod]
        public void TestLoginVacios()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("", "");
            string MensajeEsperado = "Llenar ambos campos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);

        }
        [TestMethod]
        public void LoginUsuarioVacio()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("", "17453");
            string MensajeEsperado = "Llenar el campo usuario";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);

        }
        [TestMethod]
        public void LoginContraseñaVacia()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("17453", "");
            string MensajeEsperado = "Llenar el campo contraseña";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);

        }
        [TestMethod]
        public void LoginExitoso()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("17453", "17453");
            string MensajeEsperado = "Inicio de sesión exitoso";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
        [TestMethod]
        public void LoginDatosIncorrectos()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("17453", "17435");
            string MensajeEsperado = "Datos incorrectos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);

        }
        [TestMethod]
        public void LongitudUsuario()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("1745353", "17453");
            string MensajeEsperado = "El usuario debe de tener 5 o 6 dígitos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}