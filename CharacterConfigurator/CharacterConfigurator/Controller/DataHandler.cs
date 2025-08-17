using CharacterConfigurator.Model;
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Controller
{
    public static class DataHandler
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 15;

        public static CultureInfo FormatCurrent = CultureInfo.CurrentUICulture;
        public static string FormtDb = "yyyy-MM-dd HH:mm:ss"; //SQL DateTime YYYY-MM-DD HH:MI:SS

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

        public static void CheckName(List<string> namesToCheck, string name, int index)
        {
            if (!CheckIfNameNotExists(namesToCheck, name, index)) { throw new ExceptionAlreadyExistingName(); }
            if (!CheckIfNameValid(name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(name)) { throw new ExceptionNameLength(true); }
        }

        public static void CheckName(List<string> namesToCheck, string name)
        {
            if (!CheckIfNameNotExists(namesToCheck, name)) { throw new ExceptionAlreadyExistingName(); }
            if (!CheckIfNameValid(name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(name)) { throw new ExceptionNameLength(true); }
        }

        public static bool CheckIfNameNotExists(List<string> namesToCheck, string newName)
        {
            for (int i = 0; i < namesToCheck.Count; i++)
            {
                if (namesToCheck[i] == newName)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckIfNameNotExists(List<string> namesToCheck, string newName, int indexExlude)
        {
            for (int i = 0; i < namesToCheck.Count; i++)
            {
                if (namesToCheck[i] == newName && i != indexExlude)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckIfNameLength(string newName)
        {

            if (newName.Length < MinNameLength || newName.Length > MaxNameLength)
            {
                return false;
            }
            return true;
        }


        public static bool CheckIfNameValid(string newName)
        {
            foreach (char c in newName)
            {
                if (!(char.IsLetterOrDigit(c) || c == ' '))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
