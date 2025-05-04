using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Race : IBaseModel<Race>, IItem
    {
        public Race()
        {

        }

        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.RACE;

        public string Name { get; set; }

        public BitmapImage Image { get { throw new NotImplementedException(); } set { } }

        public BitmapImage GetImage(Sex sex)
        {
            if (sex == Sex.MALE)
            {
                return _ImageMale;
            }
            else
            {
                return _ImageFemale;
            }
        }

        private BitmapImage _ImageMale { get; set; }
        private BitmapImage _ImageFemale { get; set; }


        public int Health { get; private set; }

        public int Magicka { get; private set; }

        public int Stamina { get; private set; }

        public Skill Skill { get; private set; }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            Health = sqlResult.GetInt32(2);
            Magicka = sqlResult.GetInt32(3);
            Stamina = sqlResult.GetInt32(4);
            Skill = (Skill)sqlResult.GetInt32(5);
            _ImageMale = DataHandler.LoadImage((byte[])sqlResult.GetValue(6));
            _ImageFemale = DataHandler.LoadImage((byte[])sqlResult.GetValue(7));
        }
    }
}
