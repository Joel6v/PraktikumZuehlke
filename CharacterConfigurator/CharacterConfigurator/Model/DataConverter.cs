using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public static class DataConverter
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 30;

        public static byte[] GenerateHex(string text)
        {
            byte[] bytesToBytes = Encoding.Unicode.GetBytes(text);
            using (SHA256 s = SHA256.Create()) //256 bit 32 byte 
            {
                return s.ComputeHash(bytesToBytes);
            }
        }

        public static BitmapImage LoadImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                bitmap.Freeze();

                return bitmap;
            }
        }
    }
}
