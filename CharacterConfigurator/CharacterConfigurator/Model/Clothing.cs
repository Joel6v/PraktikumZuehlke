using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Clothing : IBaseModel<Clothing>, IItem
    {
        public int Id { get; set; }

        public static ModelTypeDb DbModel { get; private set; } = ModelTypeDb.CLOTHING;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (!MainController.ClothingController.CheckIfNameExists(value))
                {
                    _Name = value;
                }
            }
        }
        private string _Name { get; set; }

        public static string BasePathImage { get; } = ImagePath.FullRootPath + "Clothing\\";

        public string GetFullPathImageStr()
        {
            
            return BasePathImage + ClothingType.GetStringPathImage() + "\\" + Name + ImagePath.FileExtension;
        }

        public BitmapImage GetFullPathImage()
        {
            return new BitmapImage(new Uri(GetFullPathImageStr(), UriKind.Absolute));
        }

        public string GetAttributs()
        {
            return $"'{Name}', {Defense}, {(int)ClothingType}";
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{Defense}", $"{(int)ClothingType}" };
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            Defense = sqlResult.GetInt32(2);
            ClothingType = (ClothingType)sqlResult.GetInt32(3);
        }

        public ClothingType ClothingType { get; private set; }

        public int Defense { get; private set; }

        public Clothing()
        {

        }
    }
}
