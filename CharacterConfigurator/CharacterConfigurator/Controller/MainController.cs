using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using System.Text;

namespace CharacterConfigurator.Controller
{
    public static class MainController
    {
        public static Controller<User> User { get; set; } = new Controller<User>();

        public static Controller<Consumable> Consumable { get; set; } = new Controller<Consumable>();

        public static Controller<Weapon> Weapon { get; set; } = new Controller<Weapon> ();

        public static Controller<Clothing> Clothing { get; set; } = new Controller<Clothing> ();

        public static Controller<Race> Race { get; set; } = new Controller<Race> ();

        public static Controller<Character> Character { get; set; } = new Controller<Character> ();
    }
}
