using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using CharacterConfigurator.Controller;

namespace CharacterConfigurator.Model
{
    public class User : IBaseModel
    {
        public override DbEnum.ModelTypeDb DbModel { get; protected set; } = DbEnum.ModelTypeDb.USER;

        public const int MinUsernameLength = 3;
        public const int MaxUsernameLength = 30;
        public override string Name { get { return _Name; } set 
            {
                if (MainController.UserController.CheckIfNameExists(value))
                {
                    throw new ExceptionAlreadyExistingName();
                }
                bool usernameValid = true;
                if (value.Length >= MinUsernameLength && value.Length < MaxUsernameLength)
                {
                    foreach (char c in value)
                    {
                        if (!char.IsLetterOrDigit(c))
                        {
                            usernameValid = false;
                            break;
                        }
                    }
                    if (usernameValid)
                    {
                        _Name = value;
                    }
                    else
                    {
                        throw new ExceptionInvalidLetters();
                    }
                }
                else
                {
                    throw new Exception($"The Username is too short or too long. The minimum length is {MinUsernameLength} and the maximum length is {MaxUsernameLength}");
                }
            }
        }
        private string _Name { get; set; }

        public override string GetAttributs()
        {
            return $"'{Name}', {Convert.ToInt64(Password)}";
        }

        public override List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{Convert.ToInt64(Password)}"};
        }

        public override void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            Password = BitConverter.GetBytes(sqlResult.GetInt64(2));
        }

        public byte[] Password { get; set; }

        public User()
        {

        }

        public User(int id, string username, byte[] password) 
        {
            Id = id;
            Name = username;
            Password = password;
        }

        public void SetPasswordStr(string password)
        {
            byte[] bytesToBytes = Encoding.Unicode.GetBytes(password);
            using (SHA256 s = SHA256.Create()) 
            {
                Password = s.ComputeHash(bytesToBytes);
            }
        }
    }
}
