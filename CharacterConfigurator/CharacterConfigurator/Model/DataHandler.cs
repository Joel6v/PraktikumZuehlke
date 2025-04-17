using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public static class DataHandler
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 30;

        public static CultureInfo Format = CultureInfo.GetCultureInfo("de-DE");

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

        public static void CheckName(List<string> nametToCheck, string name, int index)
        {
            if (!CheckIfNameNotExists(nametToCheck, name, index)) { throw new ExceptionAlreadyExistingName(); }
            if (!CheckIfNameValid(name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(name)) { throw new ExceptionNameLength(true); }
        }

        public static void CheckName(List<string> nametToCheck, string name)
        {
            if (!CheckIfNameNotExists(nametToCheck, name)) { throw new ExceptionAlreadyExistingName(); }
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

            if (newName.Length < DataHandler.MinNameLength || newName.Length > DataHandler.MaxNameLength)
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
