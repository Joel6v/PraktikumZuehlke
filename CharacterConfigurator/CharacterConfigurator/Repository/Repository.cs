using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Repository
{
    public class Repository<TBaseModel> where TBaseModel : Model.BaseModel
    {
        private ModelTypeDb DbModel {  get; set; }

        public Repository(ModelTypeDb dbModel) 
        {
            DbModel = dbModel;
        }

        public MySqlDataReader Load() 
        {
            using (DbConnection dbConnection = new())
            {
                string selectCommandStr = $"SELECT * FROM {DbModel.GetStringTable};";
                MySqlCommand selectCommand = new MySqlCommand(selectCommandStr, dbConnection.Connection);
                return selectCommand.ExecuteReader();
            }
        }

        public void SaveAll(List<TBaseModel> baseModelList) 
        {
            string sqlInsert = $"INSERT INTO {baseModelList[0].DbModel.GetStringTable()} ({baseModelList[0].DbModel.GetStringColumns()}) VALUES ";
            foreach (TBaseModel baseModel in baseModelList)
            {
                sqlInsert += "(" + baseModel.GetAttributs() + "),";
            }
            sqlInsert.Remove(sqlInsert.Length -1);
            sqlInsert += ";";

            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlInsert, dbConnection.Connection);
                command.ExecuteNonQuery();
            }
        }

        public void Save(TBaseModel baseModel)
        {
            string sqlInsert = $"INSERT INTO {baseModel.DbModel.GetStringTable()} ({baseModel.DbModel.GetStringColumns()}) VALUE ";
            sqlInsert += "(" + baseModel.GetAttributs() + ");";
            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlInsert, dbConnection.Connection);
                command.ExecuteNonQuery();
            }
        }

        public void Update(TBaseModel baseModel)
        {
            string sqlUpdate = $"UPDATE {baseModel.DbModel.GetStringTable()} SET ";
            for(int i = 0; i < baseModel.DbModel.GetListColumns().Count; i++)
            {
                sqlUpdate += baseModel.DbModel.GetListColumns()[i] + " = " + baseModel.GetListAttributes()[i] + ",";
            }
            sqlUpdate.Remove(sqlUpdate.Length - 1);

            sqlUpdate += "WHERE id = " + baseModel.Id;
            sqlUpdate += ";";

            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlUpdate, dbConnection.Connection);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(TBaseModel baseModel)
        {
            string sqlDelete = $"DELETE FROM {baseModel.DbModel.GetStringTable} WHERE id = {baseModel.Id};";
            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlDelete, dbConnection.Connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
