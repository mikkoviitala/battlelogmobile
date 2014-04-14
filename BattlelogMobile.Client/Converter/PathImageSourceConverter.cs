using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BattlelogMobile.Client.Converter
{
    public class PathImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = @"/Assets/Images/Battlefield4/" + value;
            Uri uri = new Uri(path, UriKind.Relative);
            BitmapImage imgSource = new BitmapImage(uri);
            return imgSource as ImageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static Stream ReadFile(string filePath)
        {
            var resrouceStream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative));
            if (resrouceStream != null)
            {
                using (var stream = resrouceStream.Stream)
                {
                    if (stream.CanRead)
                    {
                        var myStreamReader = new StreamReader(stream);
                        var b = myStreamReader.ReadToEnd();
                    }
                }
            }
            return null;
        }
    }
}
