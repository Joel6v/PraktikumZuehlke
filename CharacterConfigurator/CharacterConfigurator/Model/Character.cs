using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Model
{
    public class Character : IBaseModel<Character>
    {
        public int Id {  get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; protected set; } = DbEnum.ModelTypeDb.CHARACTER;

        public string Name { get { return _Name; } set 
            {
                if (!MainController.Character.CheckIfNameExists(value))
                {
                    _Name = value;
                }
            } 
        }

        private string _Name {  get; set; }

        public string GetAttributs()
        {
            return $"'{Name}', {User.Id}, {Race.Id}, {ClothingHeadgear.Id}, {ClothingChest.Id}, {ClothingGloves.Id}, {ClothingLegs.Id}, {Weapon.Id}, {Consumable.Id}";
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{User.Id}", $"{Race.Id}", $"{ClothingHeadgear.Id}", $"{ClothingChest.Id}", $"{ClothingGloves.Id}", $"{ClothingLegs.Id}", $"{Weapon.Id}", $"{Consumable.Id}" };
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            User = MainController.User.Get(sqlResult.GetInt32(2));
            Race = MainController.Race.Get(sqlResult.GetInt32(3));
            ClothingHeadgear = MainController.Clothing.Get(sqlResult.GetInt32(4));
            ClothingChest = MainController.Clothing.Get(sqlResult.GetInt32(5));
            ClothingGloves = MainController.Clothing.Get(sqlResult.GetInt32(6));
            ClothingLegs = MainController.Clothing.Get(sqlResult.GetInt32(7));
            Weapon = MainController.Weapon.Get(sqlResult.GetInt32(8));
            Consumable = MainController.Consumable.Get(sqlResult.GetInt32(9));
        }

        public User User { get; private set; }

        public Race Race { get; private set; }

        public Clothing ClothingHeadgear 
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

        public Character()
        {

        }

        public Character(int id, string name, Race race, Clothing clothingHeadgear, Clothing clothingChest, Clothing clothingGloves, Clothing clothingLegs, Consumable consumable, Weapon weapon)
        {
            Id = id;
            User = MainController.CurrentUser;
            Name = name;
            Race = race;
            ClothingHeadgear = clothingHeadgear;
            ClothingChest = clothingChest;
            ClothingGloves = clothingGloves;
            ClothingLegs = clothingLegs;
            Consumable = consumable;
            Weapon = weapon;
        }
    }
}
