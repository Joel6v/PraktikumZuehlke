using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.InheritedModel;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace CharacterConfigurator.Model
{
    public class User : IBaseModel<User>, IBaseModelVariable<User>
    {
        public User()
        {

        }

        public User(string username, string password)
        {
            Name = username;
            SetPasswordStr(password);
            TimeStamp = DateTime.Now;
        }

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

        public DateTime TimeStamp { get; set; }

        public string GetAttributes()
        {
            return string.Join(", ", GetListAttributes());
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"'{BitConverter.ToString(Password).Replace("-", "")})'", $"'{TimeStamp}'"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            Password = Convert.FromHexString(sqlResult.GetString(2));
            TimeStamp = sqlResult.GetDateTime(3);
        }

        public byte[] Password { get; set; }

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
