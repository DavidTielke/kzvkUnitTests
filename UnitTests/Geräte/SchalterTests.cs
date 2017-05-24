using System;
using EventsUndDelegates.Geräte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Geräte
{
    [TestClass]
    public class SchalterTests
    {
        [TestMethod]
        public void Name_Uninitialized_NameIsSet()
        {
            var schalter = new Schalter();

            schalter.Name = "Test";

            Assert.IsNotNull(schalter.Name);
        }

        [TestMethod]
        public void Eingeschaltet_Ausgeschaltet_Eingeschaltet()
        {
            var schalter = new Schalter();

            schalter.Eingeschaltet = true;

            Assert.IsTrue(schalter.Eingeschaltet);
        }
    }
}
