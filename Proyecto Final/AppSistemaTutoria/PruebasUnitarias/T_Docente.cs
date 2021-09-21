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
        readonly P_DatosDocente Docente = new P_DatosDocente(true);
        readonly string RutaImagenDocente = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../CapaPresentaciones/Iconos/Perfil Docente.png");


        [TestMethod]
        public void CodigoVacio()
        {
        }

        [TestMethod]
        public void ApellidoPaternoVacio()
        {
        }

        [TestMethod]
        public void ApellidoMaternoVacio()
        {
        }
        [TestMethod]
        public void NombreVacio()
        {
        }
        [TestMethod]
        public void EmailVacio()
        {
        }
        [TestMethod]
        public void DireccionVacio()
        {
        }
        [TestMethod]
        public void TelefonoVacio()
        {
        }
        [TestMethod]
        public void CodigoInvalido()
        {
        }
        [TestMethod]
        public void TelefonoInvalido()
        {
        }
        [TestMethod]
        public void InsertarDatosValidos()
        {
        }
        //[TestMethod]
        //public void EditarDatosValidos()
        //{
        //}

    }
}
