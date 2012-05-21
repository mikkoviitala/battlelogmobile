using System;
using BattlelogMobile.Client.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class IntegerStringConverterTest
    {
        private readonly IntegerStringConverter _converter = new IntegerStringConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            string expected = "100";
            object actual = _converter.Convert(100, null, null, null);
            Assert.AreEqual(expected, actual);

            expected = "= 10 000";
            actual = _converter.Convert(10000, null, "AddEquals", null);
            Assert.AreEqual(expected, actual);

            expected = "1 000 000";
            actual = _converter.Convert(1000000, null, null, null);
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