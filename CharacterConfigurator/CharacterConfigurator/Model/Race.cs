using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Race : IBaseModel<Race>, IItem
    {
        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.RACE;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (!MainController.Race.CheckIfNameExists(value))
                {
                    _Name = value;
                }
            }
        }
        private string _Name { get; set; }

        public static string BasePathImage { get; } = ImagePath.FullRootPath + "Race\\";

        public string GetFullPathImageStr()
        {
            return BasePathImage + Sex.GetStringPathImage() + "\\" + Name + ImagePath.FileExtension;
        }

        public BitmapImage GetFullPathImage()
        {
            return new BitmapImage(new Uri(GetFullPathImageStr(), UriKind.Absolute));
        }

        public string GetAttributs()
        {
            return $"'{Name}', {Health}, {Magicka}, {Stamina}, {(int)Skill}, {(int)Sex}";
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{Health}", $"{Magicka}", $"{Stamina}", $"{(int)Skill}", $"{Sex}"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            Health = sqlResult.GetInt32(2);
            Magicka = sqlResult.GetInt32(3);
            Stamina = sqlResult.GetInt32(4);
            Skill = (Skill)sqlResult.GetInt32(5);
            Sex = (Sex)sqlResult.GetInt32(6);
        }

        public int Health { get; private set; }

        public int Magicka { get; private set; }

        public int Stamina { get; private set; }

        public Skill Skill { get; private set; }

        public Sex Sex { get; private set; }

        public Race()
        {

        }
    }
}
