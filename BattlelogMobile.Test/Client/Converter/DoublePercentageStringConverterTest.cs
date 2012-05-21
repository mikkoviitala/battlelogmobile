using System;
using System.Windows;
using BattlelogMobile.Client.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class DoublePercentageStringConverterTest
    {
        private readonly DoublePercentageStringConverter _converter = new DoublePercentageStringConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            string expected = "0.0%";
            object actual = _converter.Convert(0, null, null, null);
            Assert.AreEqual(expected, actual);

            expected = "55.5%";
            actual = _converter.Convert(55.5, null, null, null);
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