using System;
using BattlelogMobile.Client.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class DoubleStringConverterTest
    {
        private readonly DoubleStringConverter _converter = new DoubleStringConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            string expected = "0.00";
            object actual = _converter.Convert(0, null, null, null);
            Assert.AreEqual(expected, actual);

            expected = "55.50suffix";
            actual = _converter.Convert(55.5, null, "suffix", null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConvertExceptionTest()
        {
            object actual = _converter.Convert("not a number", null, null, null);
        }
    }
}