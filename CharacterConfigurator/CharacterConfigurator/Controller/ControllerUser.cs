using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Controller
{
    public class ControllerUser
    {
        private List<User> UserList { get; set; }

        public User CurrentUser { get; private set; } = null;

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
            if (!CheckIfNameNotExists(user.Name)) { throw new ExceptionAlreadyExistingName(); }
            if (!CheckIfNameValid(user.Name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(user.Name)) { throw new ExceptionNameLength(); }
            int newId = Repository.Save(user);
            user.Id = newId;
            UserList.Add(user);
            CurrentUser = user;
            MainController.Character.CurrentUserChanged();
        }

        public void Delete() 
        {
            MainController.Character.DeleteAll();
            Repository.Delete(CurrentUser);
            UserList.Remove(CurrentUser);
            Logout();
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
            if (!CheckIfNameNotExists(user.Name, index)) { throw new ExceptionAlreadyExistingName(); }
            if (!CheckIfNameValid(user.Name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(user.Name)) { throw new ExceptionNameLength(); }
            Repository.Update(user);
            UserList[index] = user;
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
                if (loginName == user.Name && loginPasswordHash.SequenceEqual(user.Password))
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

        public bool CheckIfNameNotExists(string newName)
        {
            foreach (User baseModel in UserList)
            {
                if (baseModel.Name == newName)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfNameNotExists(string newName, int indexExlude)
        {
            for (int i = 0; i < UserList.Count; i++)
            {
                if (UserList[i].Name == newName && i != indexExlude)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfNameLength(string newName)
        {

            if (newName.Length < DataConverter.MinNameLength || newName.Length > DataConverter.MaxNameLength)
            {
                return false;
            }
            return true;
        }


        public bool CheckIfNameValid(string newName)
        {
            foreach (char c in newName)
            {
                if (!(char.IsLetterOrDigit(c) || c == ' '))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
