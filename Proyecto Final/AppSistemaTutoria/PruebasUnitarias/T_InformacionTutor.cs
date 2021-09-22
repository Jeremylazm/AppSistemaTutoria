using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CapaPresentaciones;

namespace PruebasUnitarias
{
    [TestClass]
    public class T_InformacionTutor
    {
        readonly P_InformacionTutor cambiarContraseña = new P_InformacionTutor(true);
        [TestMethod]
        public void NoTieneTutor()
        {
        }
    }
}
