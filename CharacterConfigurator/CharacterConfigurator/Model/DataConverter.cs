using System.Security.Cryptography;
using System.Text;

namespace CharacterConfigurator.Model
{
    public static class DataConverter
    {
        public static byte[] GenerateHex(string text)
        {
            byte[] bytesToBytes = Encoding.Unicode.GetBytes(text);
            using (SHA256 s = SHA256.Create()) //256 bit 32 byte 
            {
                return s.ComputeHash(bytesToBytes);
            }
        }
    }
}
