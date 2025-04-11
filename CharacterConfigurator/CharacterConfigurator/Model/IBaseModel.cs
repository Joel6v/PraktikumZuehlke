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
        int Id { get; set; }

        static abstract ModelTypeDb DbModel { get; }

        string Name { get; set; }

        string GetAttributs();

        List<string> GetListAttributes();

        void SetAttributes(MySqlDataReader sqlResult);
    }
}
