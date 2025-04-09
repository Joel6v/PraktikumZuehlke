using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Clothing : Item
    {
        public new const string DbTableName = "clothing";

        public ClothingType ClothingType { get; private set; }

        public int Defense { get; private set; }

        public Clothing(uint id, string name, string pathImage, ClothingType clothingType, int defense) 
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
            ClothingType = clothingType;
            Defense = defense;
        }

        public new string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, pathImage, defense, clothingType) VALUE {Name}, {PathImage}, {Defense}, {Convert.ToInt32(ClothingType)};";
        }
    }
}
