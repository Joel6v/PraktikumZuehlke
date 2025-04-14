using CharacterConfigurator.Controller;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace CharacterConfigurator.Model
{
    public class User : IBaseModel<User>
    {
        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.USER;

        public const int MinNameLength = 3;
        public const int MaxNameLength = 30;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (MainController.User.CheckIfNameExists(value))
                {
                    throw new ExceptionAlreadyExistingName();
                }
                bool usernameValid = true;
                if (value.Length >= MinNameLength && value.Length <= MaxNameLength)
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
                    throw new ExceptionNameLenght();
                }
            }
        }
        private string _Name { get; set; }

        public string GetAttributs()
        {
            return $"'{Name}', '{BitConverter.ToString(Password).Replace("-", "")}'";
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
            if (password.Length >= MinNameLength) 
            {
                Password = DataConverter.GenerateHex(password);
            }
            else
            {
                throw new Exception($"The Password is too short. The minimum length is {MinNameLength}.");
            }
        }
    }
}
