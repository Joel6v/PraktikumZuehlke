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
using System.Collections;

namespace CharacterConfigurator.Model
{
    public class User : IBaseModel<User>
    {
        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.USER;

        public const int MinUsernameLength = 3;
        public const int MaxUsernameLength = 30;
        public string Name { get { return _Name; } set 
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

        public string GetAttributs()
        {
            return $"'{Name}', UNHEX('{BitConverter.ToString(Password).Replace("-", "")})'";
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"'{BitConverter.ToString(Password).Replace("-", "")})'" };
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            Password = Convert.FromHexString(sqlResult.GetString(2));
        }

        public byte[] Password { get; set; }

        public User()
        {

        }

        public User(int id, string username, string password) 
        {
            Id = id;
            Name = username;
            SetPasswordStr(password);
        }

        public void SetPasswordStr(string password)
        {
            byte[] bytesToBytes = Encoding.Unicode.GetBytes(password);
            using (SHA256 s = SHA256.Create()) //256 bit 32 byte 
            {
                Password = s.ComputeHash(bytesToBytes);
            }
        }
    }
}
