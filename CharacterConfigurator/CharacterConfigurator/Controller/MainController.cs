using CharacterConfigurator.Model;
using CharacterConfigurator.Model.Clothing;
using CharacterConfigurator.Repository;
using System.Text;

namespace CharacterConfigurator.Controller
{
    public static class MainController
    {
        public static void Load()
        {
            User = new ControllerUser();
            Consumable = new Controller<Consumable>();
            Weapon = new Controller<Weapon>();
            Headgear = new Controller<Headgear>();
            Chest = new Controller<Chest>();
            Gloves = new Controller<Gloves>();
            Legs = new Controller<Legs>();
            Race = new Controller<Race>();
            Character = new ControllerCharacter();
        }

        public static ControllerUser User { get; set; }

        public static Controller<Consumable> Consumable { get; set; }

        public static Controller<Weapon> Weapon { get; set; }

        public static Controller<Headgear> Headgear { get; set; }

        public static Controller<Chest> Chest { get; set; }

        public static Controller<Gloves> Gloves { get; set; }

        public static Controller<Legs> Legs { get; set; }

        public static Controller<Race> Race { get; set; }

        public static ControllerCharacter Character { get; set; }
    }
}
