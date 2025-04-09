using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Clothing : Item
    {
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
    }
}
