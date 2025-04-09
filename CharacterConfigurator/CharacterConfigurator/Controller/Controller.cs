using CharacterConfigurator.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterConfigurator.Repository;

namespace CharacterConfigurator.Controller
{
    public class Controller<TBaseModel> where TBaseModel : BaseModel<TBaseModel>
    {
        public List<TBaseModel> BaseModelsList { get; private set; }

        public Controller() 
        {
            Load();
        }

        public void AddBaseModel(TBaseModel baseModel)
        {
            BaseModelsList.Add(baseModel);
        }

        public void RemoveBaseModel(int index)
        {
            BaseModelsList.RemoveAt(index);
        }

        public void UpdateBaseModel(int index, TBaseModel baseModel)
        {
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
            DbConnection dbConnection = new();
            string selectCommandStr = $"SELECT * FROM {BaseModel<TBaseModel>.DbTableName};";
            MySqlCommand selectCommand = new MySqlCommand(selectCommandStr, dbConnection.Connection);
            selectCommand.ExecuteNonQuery();
        }
    }
}
