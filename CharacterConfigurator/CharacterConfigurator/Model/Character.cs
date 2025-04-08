using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Character
    {
        public uint Id { get; private set; }

        public string Name { get; set; }

        public Race Race { get; set; }

        public Clothing ClothingHeadgears 
        {
            get { return _ClothingHeadgears; } 
            set 
            { 
                if (value.ClothingType == ClothingType.HEADGEAR) 
                {
                    _ClothingHeadgears = value;
                }
                else { throw new ExceptionWrongClothingType(ClothingType.HEADGEAR.GetStringValue()); }
            } 
        }
        private Clothing _ClothingHeadgears { get; set;}

        public Clothing ClothingChest
        {
            get { return _ClothingChest; }
            set
            {
                if (value.ClothingType == ClothingType.CHEST)
                {
                    _ClothingChest = value;
                }
                else { throw new ExceptionWrongClothingType(ClothingType.CHEST.GetStringValue()); }
            }
        }
        private Clothing _ClothingChest { get; set; }


        public Clothing ClothingGloves
        {
            get { return _ClothingGloves; }
            set
            {
                if (value.ClothingType == ClothingType.GLOVES)
                {
                    _ClothingGloves = value;
                }
                else { throw new ExceptionWrongClothingType(ClothingType.GLOVES.GetStringValue()); }
            }
        }
        private Clothing _ClothingGloves { get; set; }

        public Clothing ClothingLegs
        {
            get { return _ClothingLegs; }
            set
            {
                if (value.ClothingType == ClothingType.LEGS)
                {
                    _ClothingLegs = value;
                }
                else { throw new ExceptionWrongClothingType(ClothingType.LEGS.GetStringValue()); }
            }
        }
        private Clothing _ClothingLegs { get; set; }

        public Consumable Consumable {  get; set; }

        public Weapon Weapon { get; set; }
    }
}
