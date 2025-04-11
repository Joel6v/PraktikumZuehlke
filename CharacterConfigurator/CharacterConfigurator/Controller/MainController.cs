using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using System.Text;

namespace CharacterConfigurator.Controller
{
    public static class MainController
    {
        public static User CurrentUser { get; set; } = null;

        public static Controller<User> UserController { get; set; } = new Controller<User>();

        public static Controller<Consumable> ConsumableController { get; set; } = new Controller<Consumable>();

        public static Controller<Weapon> WeaponController { get; set; } = new Controller<Weapon> ();

        public static Controller<Clothing> ClothingController { get; set; } = new Controller<Clothing> ();

        public static Controller<Race> RaceController { get; set; } = new Controller<Race> ();

        public static Controller<Character> CharacterController { get; set; } = new Controller<Character> ();
    }
}
