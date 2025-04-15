using CharacterConfigurator.Model;
using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System.IO;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Repository
{
    public class Repository<TBaseModel> where TBaseModel : Model.IBaseModel<TBaseModel>, new()
    {
        public Repository() 
        {
        }

        public List<TBaseModel> Load() 
        {
            List<TBaseModel> baseModelList = new List<TBaseModel>();
            using (DbConnection dbConnection = new())
            {
                string selectCommandStr = $"SELECT * FROM {TBaseModel.DbModel.GetStringTable()};";
                MySqlCommand selectCommand = new MySqlCommand(selectCommandStr, dbConnection.Connection);
                MySqlDataReader result = selectCommand.ExecuteReader();
                while (result.Read())
                {
                    TBaseModel baseModel = new();
                    baseModel.SetAttributes(result);
                    baseModelList.Add(baseModel);
                }
            }
            return baseModelList;
        }
    }
}
