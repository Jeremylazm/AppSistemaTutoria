using CapaPresentaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_Estudiante
    {
        

        [TestMethod]
        public void CodigoVacio()
        {
            P_DatosEstudiante Estudiante = new P_DatosEstudiante(true);
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
            string MensajePrueba = Estudiante.AgregarOModificar(Image.FromFile(fullImagePath), "000000", "LAZO", "MENDOZA", "JEREMY AXL",
                                                                "182916@unsaac.edu.pe", "AV. LOS INCAS #10", "987654321", "IN",
                                                                "MAMÁ", "987654321", "INFORMACIÓN");
            string MensajeEsperado = "Debe llenar el código";
            Assert.AreEqual(MensajePrueba, MensajeEsperado);
        }
    }
}
