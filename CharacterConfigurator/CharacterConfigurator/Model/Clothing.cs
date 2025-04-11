using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.DbEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;

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

        public static string BasePathImage { get; } = AppContext.BaseDirectory + ImagePath.RootPath + "Clothing\\";

        public string GetFullPathImage()
        {
            return BasePathImage + ClothingType.GetStringPathImage();
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
            Name = sqlResult.GetString(1);
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
