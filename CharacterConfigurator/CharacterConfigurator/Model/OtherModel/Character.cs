using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using CharacterConfigurator.Model.Clothing;
using CharacterConfigurator.Model.InheritedModel;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Model
{
    public class Character : IBaseModel<Character>, IBaseModelVariable<Character>
    {
        public Character()
        {
        }

        public Character(string name, Race race, Headgear headgear, Chest chest, Gloves gloves, Legs legs, Consumable consumable, Weapon weapon)
        {
            User = MainController.User.GetCurrentUser();
            Name = name;
            Race = race;
            Headgear = headgear;
            Chest = chest;
            Gloves = gloves;
            Legs = legs;
            Consumable = consumable;
            Weapon = weapon;
            TimeStamp = DateTime.Now;
        }

        public int Id {  get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; protected set; } = DbEnum.ModelTypeDb.CHARACTER;

        public string Name { get { return _Name; } set 
            {
                if (MainController.Character.CheckIfNameExists(value)) //The name should only be checked in the names from the current user
                {
                    throw new ExceptionAlreadyExistingName();
                }
                bool nameValid = true;
                if (value.Length >= User.MinNameLength && value.Length <= User.MaxNameLength)
                {
                    foreach (char c in value)
                    {
                        if (!char.IsLetterOrDigit(c))
                        {
                            nameValid = false;
                            break;
                        }
                    }
                    if (nameValid)
                    {
                        _Name = value;
                    }
                    else
                    {
                        throw new ExceptionInvalidLetters();
                    }
                }
                else
                {
                    throw new ExceptionNameLenght();
                }
            } 
        }

        private string _Name {  get; set; }

        public string GetAttributes()
        {
            return string.Join(", ", GetListAttributes());           
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"'{TimeStamp}'", $"{User.Id}", $"{Race.Id}", $"{Headgear.Id}", $"{Chest.Id}", $"{Gloves.Id}", $"{Legs.Id}", $"{Weapon.Id}", $"{Consumable.Id}", $"{(int)Sex}"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            TimeStamp = sqlResult.GetDateTime(2);
            User = MainController.User.Get(sqlResult.GetInt32(3) - 1); //-1 because the Id's in the Db starts with 1
            Race = MainController.Race.Get(sqlResult.GetInt32(4) - 1);
            Headgear = MainController.Headgear.Get(sqlResult.GetInt32(5) - 1);
            Chest = MainController.Chest.Get(sqlResult.GetInt32(6) - 1);
            Gloves = MainController.Gloves.Get(sqlResult.GetInt32(7) - 1);
            Legs = MainController.Legs.Get(sqlResult.GetInt32(8) - 1);
            Weapon = MainController.Weapon.Get(sqlResult.GetInt32(9) - 1);
            Consumable = MainController.Consumable.Get(sqlResult.GetInt32(10) - 1);
            Sex = (Sex)sqlResult.GetInt32(11);
        }

        public DateTime TimeStamp { get; set; }

        public User User { get; set; }

        public Race Race { get; set; }

        public Headgear Headgear { get; set; }

        public Chest Chest { get; set; }

        public Gloves Gloves { get; set; }

        public Legs Legs { get; set; } 

        public Consumable Consumable {  get; set; }

        public Weapon Weapon { get; set; }

        public Sex Sex { get; private set; }


        public int GetWholeAmountDefense()
        {
            int wholeAmountDefense = 0;
            wholeAmountDefense += Headgear.Defense;
            wholeAmountDefense += Chest.Defense;
            wholeAmountDefense += Gloves.Defense;
            wholeAmountDefense += Legs.Defense;
            return wholeAmountDefense;
        }
    }
}
