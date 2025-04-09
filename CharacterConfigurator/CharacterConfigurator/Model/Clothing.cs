using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Clothing : Item<Clothing>
    {
        public ClothingType ClothingType { get; private set; }

        public int Defense { get; private set; }

        static Clothing()
        {
            DbTableName = "";
        }

        public Clothing(uint id, string name, string pathImage, ClothingType clothingType, int defense) 
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
            ClothingType = clothingType;
            Defense = defense;
        }
    }
}
