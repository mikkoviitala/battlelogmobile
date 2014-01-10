using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace BattlelogMobile.Core.Repository
{
    public class ImageRepository
    {
        private readonly IsolatedStorageFile _isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication();

        public BitmapImage Load(string imageName)
        {
            BitmapImage image = null;
            if (_isolatedStorageFile.FileExists(imageName))
            {
                using (IsolatedStorageFileStream stream = _isolatedStorageFile.OpenFile(imageName, FileMode.Open, FileAccess.Read))
                {
                    image = new BitmapImage();
                    image.SetSource(stream);
                }
            }
            return image;
        }

        public async void Load(string imageUrl, string imageName, Action<BitmapImage> callback, string imageSaveName = null)
        {
            BitmapImage image = Load(imageSaveName ?? imageName);

            if (image == null)
                image = await Download(imageUrl, imageName, imageSaveName);
            
            callback.Invoke(image);
        }

        private async Task<BitmapImage> Download(string imageUrl, string imageName, string imageSaveName)
        {
            Stream imageStream = null;

            var client = new WebClient();
            try
            {
                var imageUri = new Uri(string.Format(imageUrl, imageName));
                imageStream = await client.OpenReadTaskAsync(imageUri);
            }
            catch (Exception ex)
            {
                // Let it fail if not something catastrophic
                if (!(ex is WebException))
                    throw;
            }

            if (imageStream == null)
                return null;

            var streamResourceInfo = new StreamResourceInfo(imageStream, null);
            var streamReader = new StreamReader(streamResourceInfo.Stream);
               
            byte[] imageBytes;
            using (var binaryReader = new BinaryReader(streamReader.BaseStream))
                imageBytes = binaryReader.ReadBytes((int) streamReader.BaseStream.Length);

            var image = new BitmapImage();
            string name = imageSaveName ?? imageName;
            using (var stream = _isolatedStorageFile.CreateFile(name))
            {
                stream.Write(imageBytes, 0, imageBytes.Length);
                image.SetSource(stream);
            }

            return image;
        }
    }
}
