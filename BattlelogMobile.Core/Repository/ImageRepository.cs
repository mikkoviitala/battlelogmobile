using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace BattlelogMobile.Core.Repository
{
    public class ImageRepository : IImageRepository
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

        public void Load(string imageUrl, string imageName, Action<BitmapImage> callback, string imageSaveName = null)
        {
            BitmapImage image;
            
            if (imageSaveName != null)
                image = Load(imageSaveName);
            else
                image = Load(imageName);

            if (image != null)
              callback.Invoke(image);
            else
                Download(imageUrl, imageName, callback, imageSaveName);
        }

        //public void Save(string imageUrl)
        //{
        //    ThreadPool.QueueUserWorkItem(GetImage, imageUrl);
        //}

        private void Download(string imageUrl, string imageName, Action<BitmapImage> callBack, string imageSaveName)
        {
            var imageUri = new Uri(string.Format(imageUrl, imageName));

            var client = new WebClient();
            client.OpenReadCompleted += (s, e) =>
            {
                try
                {
                    var streamResourseInfo = new StreamResourceInfo(e.Result, null);
                    var streamReader = new StreamReader(streamResourseInfo.Stream);
                    byte[] imageBytes;
                    using (var binaryReader = new BinaryReader(streamReader.BaseStream))
                    {
                        imageBytes = binaryReader.ReadBytes((int)streamReader.BaseStream.Length);
                    }

                    string name = imageSaveName ?? imageName;
                    using (var stream = _isolatedStorageFile.CreateFile(name))
                    {
                        stream.Write(imageBytes, 0, imageBytes.Length);
                        var image = new BitmapImage();
                        image.SetSource(stream);
                        callBack.Invoke(image);
                    }
                }
                catch (Exception ex)
                {
                    // Let it fail if not something catastrophic
                    if (!(ex is WebException))
                        throw;
                }
            };
            client.OpenReadAsync(imageUri, client);
        }
    }
}
