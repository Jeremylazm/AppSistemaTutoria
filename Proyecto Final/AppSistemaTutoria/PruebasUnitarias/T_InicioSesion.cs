using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_InicioSesion
    {
        // Definir variables globales para las pruebas unitarias
        readonly P_InicioSesion InicioSesion = new P_InicioSesion(true);

        // Caso de Prueba: Ambos campos de texto vacíos
        [TestMethod]
        public void CamposVacios()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("", "");
            string MensajeEsperado = "Llenar ambos campos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Campo de texto del usuario vacío
        [TestMethod]
        public void CampoUsuarioVacio()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("", "17453");
            string MensajeEsperado = "Llenar el campo usuario";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Campo de texto de la contraseña vacío
        [TestMethod]
        public void CampoContraseñaVacio()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("17453", "");
            string MensajeEsperado = "Llenar el campo contraseña";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Ambos campos de texto válidos
        [TestMethod]
        public void InicioSesionExitoso()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("17453", "17453");
            string MensajeEsperado = "Inicio de sesión exitoso";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: Datos inválidos
        [TestMethod]
        public void DatosInvalidos()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("17453", "17435");
            string MensajeEsperado = "Datos incorrectos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }

        // Caso de Prueba: La longitud de la cadena del campo usuario es inválido
        [TestMethod]
        public void LongitudUsuarioInvalido()
        {
            string MensajePrueba = InicioSesion.IniciarSesion("1745353", "17453");
            string MensajeEsperado = "El usuario debe de tener 5 o 6 dígitos";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}