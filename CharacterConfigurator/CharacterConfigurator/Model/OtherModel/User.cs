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


        public string Name { get; set; }

        public DateTime TimeStamp { get; set; }

        public string GetAttributes()
        {
            return string.Join(", ", GetListAttributes());
        }

        public List<string> GetListAttributes()
        {

            return new List<string>() { $"'{Name}'", $"'{BitConverter.ToString(Password).Replace("-", "")}'", $"'{TimeStamp.ToString(DataHandler.FormtDb)}'"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            Password = Convert.FromHexString(sqlResult.GetString(2));
            TimeStamp = sqlResult.GetDateTime(3);
        }

        public byte[] Password { get; set; }

        public void SetPasswordStr(string password)
        {
            if (password.Length >= DataHandler.MinNameLength) 
            {
                Password = DataHandler.GenerateHex(password);
            }
            else
            {
                throw new ExceptionNameLength(false);
            }
        }
    }
}
