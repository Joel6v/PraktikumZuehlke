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
    public class User : BaseModel<User>
    {
        public new const string DbTableName = "user";

        public const int MinUsernameLength = 3;
        public const int MaxUsernameLength = 30;

        //Username must be check if it is already existing
        public new string Name { get { return _Username; } set 
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
                        _Username = value;
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
        private string _Username { get; set; }

        public byte[] Password { get; set; }

        public User(uint id, string username, byte[] password) 
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

        public override string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, password) VALUE {Name}, {Convert.ToInt64(Password)};";
        }
    }
}
