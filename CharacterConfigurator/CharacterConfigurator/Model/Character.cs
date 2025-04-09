using CharacterConfigurator.Controller;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public class Character : BaseModel<Character>
    {
        public new const string DbTableName = "character";

        public override string Name { get { return _Name; } set { if()} }

        private string _Name {  get; set; }

        public User User { get; private set; }

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

        public Character(uint id, string name, Race race, Clothing clothingHeadgears, Clothing clothingChest, Clothing clothingGloves, Clothing clothingLegs, Consumable consumable, Weapon weapon)
        {
            Id = id;
            User = MainController.CurrentUser;
            Name = name;
            Race = race;
            ClothingHeadgears = clothingHeadgears;
            ClothingChest = clothingChest;
            ClothingGloves = clothingGloves;
            ClothingLegs = clothingLegs;
            Consumable = consumable;
            Weapon = weapon;
        }

        public override string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, user_userId, race_raceId, clothing_headgearId, clothing_chestId, clothing_glovesId, clothing_legsId, weapon_weaponId, consumable_consumableId) VALUE " +
                $"{Name}, {User.Id}, {Race.Id}, {ClothingHeadgears.Id}, {ClothingChest.Id}, {ClothingGloves.Id}, {ClothingLegs.Id}, {Weapon.Id}, {Consumable.Id};";
        }
    }
}
