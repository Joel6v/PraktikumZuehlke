using CharacterConfigurator.Model;

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
                    return true;
                }
            }
            return false;
        }

        public static void Logout(this Controller<User> controller)
        {
            CurrentUser = null;
        }
    }
}
