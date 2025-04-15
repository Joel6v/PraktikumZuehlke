using CharacterConfigurator.Model;
using CharacterConfigurator.Repository;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace CharacterConfigurator.Controller
{
    public class Controller<TBaseModel> where TBaseModel : IBaseModel<TBaseModel>, new()
    {
        private List<TBaseModel> BaseModelsList { get; set; }

        private Repository<TBaseModel> Repository;

        public Controller() 
        {
            Repository = new Repository<TBaseModel>();
            Load();
        }

        public TBaseModel Get(int index)
        {
            return BaseModelsList[index];
        }

        public List<TBaseModel> GetAll()
        {
            return BaseModelsList;
        }

        public int Count()
        {
            return BaseModelsList.Count;
        }

        public int GetIndex(TBaseModel baseModel)
        {
            for(int i = 0; i < BaseModelsList.Count; i++)
            {
                if(baseModel.Id == BaseModelsList[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public List<string> GetAllNames()
        {
            List<string> names = new List<string> ();
            for(int i = 0; i < BaseModelsList.Count; i++)
            {
                names.Add (BaseModelsList[i].Name);
            }
            return names;
        }

        private void Load()
        {
            BaseModelsList = Repository.Load();
        }
    }
}
