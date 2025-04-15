using CharacterConfigurator.Model;
using CharacterConfigurator.Model.DbEnum;
using CharacterConfigurator.Model.InheritedModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Repository
{
    public class RepositoryVariable<TBaseModel, TBaseModelVariable> 
        where TBaseModel : IBaseModel<TBaseModel>, new()
        where TBaseModelVariable : IBaseModel<TBaseModel>, IBaseModelVariable<TBaseModel>
    {
        public RepositoryVariable()
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

        public List<TBaseModel> Load(string idName, int id)
        {
            List<TBaseModel> baseModelList = new List<TBaseModel>();
            using (DbConnection dbConnection = new())
            {
                string selectCommandStr = $"SELECT * FROM {TBaseModel.DbModel.GetStringTable()} WHERE {idName} = {id};";
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

        public void SaveAll(List<TBaseModelVariable> baseModelList)
        {
            string sqlInsert = $"INSERT INTO {TBaseModel.DbModel.GetStringTable()} ({TBaseModel.DbModel.GetStringColumns()}) VALUES ";
            foreach (TBaseModelVariable baseModel in baseModelList)
            {
                sqlInsert += "(" + baseModel.GetAttributes() + "),";
            }
            sqlInsert.Remove(sqlInsert.Length - 1);
            sqlInsert += ";";

            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlInsert, dbConnection.Connection);
                command.ExecuteNonQuery();
            }
        }

        public int Save(TBaseModelVariable baseModel)
        {
            string sqlInsert = $"INSERT INTO {TBaseModel.DbModel.GetStringTable()} ({TBaseModel.DbModel.GetStringColumns()}) VALUE ";
            sqlInsert += "(" + baseModel.GetAttributes() + ");";
            int newId;
            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlInsert, dbConnection.Connection);
                command.ExecuteNonQuery();
                newId = (int)command.LastInsertedId;
            }
            return newId;
        }

        public void Update(TBaseModelVariable baseModel)
        {
            string sqlUpdate = $"UPDATE {TBaseModel.DbModel.GetStringTable()} SET ";
            for (int i = 0; i < TBaseModel.DbModel.GetListColumns().Count; i++)
            {
                sqlUpdate += TBaseModel.DbModel.GetListColumns()[i] + " = " + baseModel.GetListAttributes()[i] + ",";
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
            string sqlDelete = $"DELETE FROM {TBaseModel.DbModel.GetStringTable()} WHERE id = {baseModel.Id};";
            using (DbConnection dbConnection = new())
            {
                MySqlCommand command = new MySqlCommand(sqlDelete, dbConnection.Connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
