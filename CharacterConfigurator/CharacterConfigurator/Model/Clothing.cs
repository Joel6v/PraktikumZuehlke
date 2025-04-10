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
    public class Clothing : Item
    {
        public override ModelTypeDb DbModel { get; protected set; } = ModelTypeDb.CLOTHING;

        public override string Name
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

        public override string PathImage { get; protected set; }

        public override string GetAttributs()
        {
            return $"'{Name}', {Defense}, {(int)ClothingType}";
        }

        public override List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{Defense}", $"{(int)ClothingType}" };
        }

        public override void SetAttributes(MySqlDataReader sqlResult)
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

        public Clothing(int id, string name, string pathImage, ClothingType clothingType, int defense) 
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
            ClothingType = clothingType;
            Defense = defense;
        }
    }
}
