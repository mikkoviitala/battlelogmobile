using System;
using System.Windows;
using BattlelogMobile.Client.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class TimeSpanStringConverterTest
    {
        private readonly TimeSpanStringConverter _converter = new TimeSpanStringConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            var expected = "01h 01m";
            object actual = _converter.Convert(new TimeSpan(0, 1, 1, 0), null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ConvertInvalidCastExceptionTest()
        {
            object actual = _converter.Convert("not a timespan", null, null, null);
        }
    }
}