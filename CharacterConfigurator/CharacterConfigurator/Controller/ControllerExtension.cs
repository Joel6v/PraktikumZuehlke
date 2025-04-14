using CharacterConfigurator.Model;
using CharacterConfigurator.Model.CharacterEnum;

namespace CharacterConfigurator.Controller
{
    public static class UserControllerExtension
    {
        private static User CurrentUser { get; set; } = null;

        public static bool Validate(this Controller<User> controller, string loginName, string loginPassword)
        {
            byte[] loginPasswordHash = DataConverter.GenerateHex(loginName);
            foreach (User user in controller.GetAll())
            {
                if (loginName == user.Name && loginPasswordHash == user.Password)
                {
                    CurrentUser = user;
                    MainController.Character.CurrentUserChanged();
                    return true;
                }
            }
            return false;
        }

        public static void Logout(this Controller<User> controller)
        {
            CurrentUser = null;
            MainController.Character.CurrentUserChanged();
        }

        public static User GetCurrentUser(this Controller<User> controller)
        {
            return CurrentUser;
        }
    }

    public static class ClothingControllerExtension
    {
        public static List<Clothing> GetAllFromType(this Controller<Clothing> controller, ClothingType clothingType)
        {
            List<Clothing> clothings = new List<Clothing>();
            for(int i = 0;  i < controller.Count(); i++)
            {
                if(controller.Get(i).ClothingType == clothingType)
                {
                    clothings.Add(controller.Get(i));
                }
            }
            return clothings;
        }

        public static int GetIndex(this Controller<Clothing> controller, Clothing clothing, ClothingType clothingType)
        {
            for (int i = 0; i < GetAllFromType(controller, clothingType).Count; i++)
            {
                if (clothing.Id == GetAllFromType(controller, clothingType)[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
