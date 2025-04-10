using CharacterConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Controller
{
    public static class MainController
    {
        public static User CurrentUser { get; set; }

        public static Controller<User> UserController { get; set; }

        public static Controller<Character> CharacterController { get; set; }

        public static Controller<Clothing> ClothingController { get; set; }
    }
}
