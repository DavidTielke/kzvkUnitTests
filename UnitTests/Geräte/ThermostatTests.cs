using EventsUndDelegates.Geräte;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Geräte
{
    [TestClass]
    public class ThermostatTests
    {
        [TestMethod]
        public void Name_Uninitialized_NameIsSet()
        {
            var thermo = new Thermostat();

            thermo.Name = "Test";

            Assert.IsNotNull(thermo.Name);
        }

        [TestMethod]
        public void Temperatur_Uninitialized_TempIsSet()
        {
            var thermo = new Thermostat();

            thermo.Temperatur = 23;

            Assert.AreEqual(23, thermo.Temperatur);
        }

        [TestMethod]
        public void Temperatur_Uninitialized_Zustandgeändert()
        {
            var isRaised = false;
            var thermo = new Thermostat();
            thermo.Zustandgeaendert += s => isRaised = true;

            thermo.Temperatur = 23;

            Assert.IsTrue(isRaised);
        }

        [TestMethod]
        public void Messen_TempIs0_TempIs23()
        {
            var thermo = new Thermostat();

            thermo.Messen(23);

            Assert.AreEqual(23, thermo.Temperatur);
        }

        [TestMethod]
        public void Messen_EventSubscribed_ZustandgeändertRaised()
        {
            var thermo = new Thermostat();
            bool isRaised = false;
            thermo.Zustandgeaendert += s => isRaised = true;

            thermo.Messen(23);

            Assert.IsTrue(isRaised);
        }
    }
}
