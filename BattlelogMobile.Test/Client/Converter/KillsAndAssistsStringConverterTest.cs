using System;
using BattlelogMobile.Client.Converter;
using BattlelogMobile.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class KillsAndAssistsStringConverterTest
    {
        private readonly KillsAndAssistsStringConverter _converter = new KillsAndAssistsStringConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            IStatistics stats = new Statistics()
                {
                    Kills = 100,
                    KillAssists = 1000,
                    VehiclesDestroyed = 10000,
                    VehiclesDestroyedAssists = 1000000
                };

            string expected = "100+1 000";
            object actual = _converter.Convert(stats, null, "Kills", null);
            Assert.AreEqual(expected, actual);

            expected = "10 000+1 000 000";
            actual = _converter.Convert(stats, null, null, null);
            Assert.AreEqual(expected, actual);

            expected = "+";
            actual = _converter.Convert(new Statistics(), null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ConvertInvalidCastExceptionTest()
        {
            object actual = _converter.Convert("not a statistics object", null, null, null);
        }
    }
}