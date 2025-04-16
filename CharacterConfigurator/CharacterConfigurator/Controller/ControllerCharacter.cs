using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Controller
{
    public class ControllerCharacter
    {
        private List<Character> CharacterListCurrentUser { get; set; } = new List<Character>(); //For testing resons in must be set

        private RepositoryVariable<Character, Character> Repository;

        public ControllerCharacter()
        {
            Repository = new RepositoryVariable<Character, Character>();
        }

        public void CurrentUserChanged()
        {
            if (MainController.User.CurrentUser != null)
            {
                Load();
            }
            else
            {
                CharacterListCurrentUser = new List<Character>();
            }
        }

        public Character Get(int index)
        {
            return CharacterListCurrentUser[index];
        }

        public List<Character> GetAll()
        {
            return CharacterListCurrentUser;
        }

        public int Count()
        {
            return CharacterListCurrentUser.Count;
        }

        public int GetIndex(Character baseModel)
        {
            for (int i = 0; i < CharacterListCurrentUser.Count; i++)
            {
                if (baseModel.Id == CharacterListCurrentUser[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<string> GetAllNames()
        {
            List<string> names = new List<string>();
            for (int i = 0; i < CharacterListCurrentUser.Count; i++)
            {
                names.Add(CharacterListCurrentUser[i].Name);
            }
            return names;
        }

        public void Add(Character character)
        {
            int newId = Repository.Save(character);
            character.Id = newId;
            CharacterListCurrentUser.Add(character);
        }

        public void Delete(int index)
        {
            Repository.Delete(CharacterListCurrentUser[index]);
            CharacterListCurrentUser.RemoveAt(index);
        }

        /// <summary>
        /// Deletes all Character from the current User
        /// </summary>
        public void DeleteAll()
        {
            for(int i = 0; i < CharacterListCurrentUser.Count; i++)
            {
                Repository.Delete(CharacterListCurrentUser[i]);
            }
        }

        public void Update(Character character)
        {
            int index = -1;
            for (int i = 0; i < CharacterListCurrentUser.Count; i++)
            {
                if (CharacterListCurrentUser[i].Id == character.Id)
                {
                    index = i;
                    break;
                }
            }
            Repository.Update(character);
            CharacterListCurrentUser[index] = character;
        }

        public bool CheckIfNameExists(string newName)
        {
            foreach (Character baseModel in CharacterListCurrentUser)
            {
                if (baseModel.Name == newName)
                {
                    return true;
                }
            }

            return false;
        }

        private void Load()
        {
            CharacterListCurrentUser = Repository.Load("userId", MainController.User.CurrentUser.Id);
        }
    }
}
