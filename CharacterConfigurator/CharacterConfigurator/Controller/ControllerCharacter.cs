using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;

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
            if(!CheckIfNameNotExists(character.Name)) { throw new ExceptionAlreadyExistingName(); }
            if(!CheckIfNameValid(character.Name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(character.Name)) { throw new ExceptionNameLength(); }
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
            if (!CheckIfNameNotExists(character.Name, index)) { throw new ExceptionAlreadyExistingName(); }
            if (!CheckIfNameValid(character.Name)) { throw new ExceptionInvalidLetters(); }
            if (!CheckIfNameLength(character.Name)) { throw new ExceptionNameLength(); }
            Repository.Update(character);
            CharacterListCurrentUser[index] = character;
        }

        public bool CheckIfNameNotExists(string newName)
        {
            foreach (Character baseModel in CharacterListCurrentUser)
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
            for(int i = 0;i < CharacterListCurrentUser.Count; i++)
            {
                if(CharacterListCurrentUser[i].Name == newName && i != indexExlude)
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

        private void Load()
        {
            CharacterListCurrentUser = Repository.Load("userId", MainController.User.CurrentUser.Id);
        }
    }
}
