using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Controller
{
    public class ControllerUser
    {
        private List<User> UserList { get; set; }

        private User CurrentUser { get; set; } = null;

        private RepositoryVariable<User, User> Repository;

        public ControllerUser()
        {
            Repository = new RepositoryVariable<User, User>();
            Load();
        }

        public User Get(int index)
        {
            return UserList[index];
        }

        public List<User> GetAll()
        {
            return UserList;
        }

        public int Count()
        {
            return UserList.Count;
        }

        public int GetIndex(User user)
        {
            for (int i = 0; i < UserList.Count; i++)
            {
                if (user.Id == UserList[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<string> GetAllNames()
        {
            List<string> names = new List<string>();
            for (int i = 0; i < UserList.Count; i++)
            {
                names.Add(UserList[i].Name);
            }
            return names;
        }

        public void Add(User user)
        {
            int newId = Repository.Save(user);
            user.Id = newId;
            UserList.Add(user);
        }

        public void Delete(int index)
        {
            MainController.Character.DeleteAll();
            Repository.Delete(UserList[index]);
            UserList.RemoveAt(index);
        }

        public void Update(User user)
        {
            int index = -1;
            for (int i = 0; i < UserList.Count; i++)
            {
                if (UserList[i].Id == user.Id)
                {
                    index = i;
                    break;
                }
            }
            Repository.Update(user);
            UserList[index] = user;
        }

        public bool CheckIfNameExists(string newName)
        {
            foreach (User user in UserList)
            {
                if (user.Name == newName)
                {
                    return true;
                }
            }

            return false;
        }

        private void Load()
        {
            UserList = Repository.Load();
        }

        public bool Validate(string loginName, string loginPassword)
        {
            byte[] loginPasswordHash = DataConverter.GenerateHex(loginPassword);
            foreach (User user in UserList)
            {
                if (loginName == user.Name && loginPasswordHash.Equals(user.Password))
                {
                    CurrentUser = user;
                    MainController.Character.CurrentUserChanged();
                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            MainController.Character.CurrentUserChanged();
        }

        public User GetCurrentUser()
        {
            return CurrentUser;
        }
    }
}
