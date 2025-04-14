using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using System.Text;

namespace CharacterConfigurator.Controller
{
    public static class MainController
    {
        public static void Load()
        {
            User = new Controller<User>();
            Consumable = new Controller<Consumable>();
            Weapon = new Controller<Weapon>();
            Clothing = new Controller<Clothing>();
            Race = new Controller<Race>();
            Character = new ControllerCharacter();
        }

        public static Controller<User> User { get; set; }

        public static Controller<Consumable> Consumable { get; set; }

        public static Controller<Weapon> Weapon { get; set; }

        public static Controller<Clothing> Clothing { get; set; }

        public static Controller<Race> Race { get; set; }

        public static ControllerCharacter Character { get; set; }
    }
}
