using CharacterConfigurator.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterConfigurator.Repository;
using CharacterConfigurator.Model.DbEnum;

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

        public List<string> GetAllNames()
        {
            List<string> names = new List<string> ();
            for(int i = 0; i < BaseModelsList.Count; i++)
            {
                names.Add (BaseModelsList[i].Name);
            }
            return names;
        }

        public void Add(TBaseModel baseModel)
        {
            Repository.Save(baseModel);
            BaseModelsList.Add(baseModel);
        }

        public void Delete(int index)
        {
            Repository.Delete(BaseModelsList[index]);
            BaseModelsList.RemoveAt(index);
        }

        public void Update(TBaseModel baseModel)
        {
            int index = -1;
            for(int i = 0; i < BaseModelsList.Count; i++)
            {
                if(BaseModelsList[i].Id == baseModel.Id)
                {
                    index = i; 
                    break;
                }
            }
            Repository.Update(baseModel);
            BaseModelsList[index] = baseModel;
        }

        public bool CheckIfNameExists(string newName)
        {
            foreach (TBaseModel baseModel in BaseModelsList)
            {
                if(baseModel.Name == newName)
                {
                    return true;
                }
            }

            return false;
        }

        private void Load()
        {
            BaseModelsList = Repository.Load();
        }
    }
}
