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

        public static abstract ModelTypeDb DbModel { get; }

        public abstract string Name { get; set; }

        public abstract string GetAttributs();

        public abstract List<string> GetListAttributes();

        public abstract void SetAttributes(MySqlDataReader sqlResult);
    }
}
