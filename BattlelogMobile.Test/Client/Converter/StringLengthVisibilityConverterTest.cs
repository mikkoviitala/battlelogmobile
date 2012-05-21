using System;
using System.Windows;
using BattlelogMobile.Client.Converter;
using BattlelogMobile.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattlelogMobile.Test.Client.Converter
{
    [TestClass()]
    public class StringLengthVisibilityConverterTest
    {
        private readonly StringLengthVisibilityConverter _converter = new StringLengthVisibilityConverter();

        [TestMethod()]
        public void ConvertTest()
        {
            var expected = Visibility.Visible;
            object actual = _converter.Convert("string", null, null, null);
            Assert.AreEqual(expected, actual);

            expected = Visibility.Collapsed;
            actual = _converter.Convert(string.Empty, null, null, null);
            Assert.AreEqual(expected, actual);

            expected = Visibility.Collapsed;
            actual = _converter.Convert(null, null, null, null);
            Assert.AreEqual(expected, actual);

            expected = Visibility.Visible;
            actual = _converter.Convert(Visibility.Visible, null, null, null);
            Assert.AreEqual(expected, actual);
        }
    }
}