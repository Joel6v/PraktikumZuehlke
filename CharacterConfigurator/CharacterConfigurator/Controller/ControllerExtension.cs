using CharacterConfigurator.Model;

namespace CharacterConfigurator.Controller
{
    public static class UserControllerExtension
    {
        public static bool ValidateUser(this Controller<User> controller, string loginName, string loginPassword)
        {
            byte[] loginPasswordHash = DataConverter.GenerateHex(loginName);
            foreach (User user in controller.GetAll())
            {
                if (loginName == user.Name && loginPasswordHash == user.Password)
                {
                    MainController.CurrentUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}
