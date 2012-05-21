using System;
using System.Windows;
using BattlelogMobile.Client.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class BoolVisibilityConverterTest
    {
        private readonly BoolVisibilityConverter _converter = new BoolVisibilityConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            var expected = Visibility.Visible;
            object actual = _converter.Convert(true, null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertReverseTest()
        {
            var expected = Visibility.Collapsed;
            object actual = _converter.Convert(true, null, "Reverse", null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertArgumentExceptionTest()
        {
            object actual = _converter.Convert(true, null, "unkownconverterparameter", null);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConvertFormatExceptionTest()
        {
            object actual = _converter.Convert("not a bool value", null, "unkownconverterparameter", null);
        }
    }
}