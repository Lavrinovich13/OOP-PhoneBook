using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PhoneBook.Helpers
{
    public static class ImageHelper
    {
        public static Image GetImageFromUri(Uri uri)
        {
            Image image = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = uri;
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            image.Source = src;

            return image;
        }
    }
}
