using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CharacterConfigurator.Model.DbEnum;

namespace CharacterConfigurator.Model
{
    public interface IBaseModel<T> where T : IBaseModel<T>
    {
        public int Id { get; protected set; }

        public static ModelTypeDb DbModel { get; }

        public string Name { get; set; }

        public string GetAttributs();

        public List<string> GetListAttributes();

        public void SetAttributes(MySqlDataReader sqlResult);
    }
}
