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
    public abstract class BaseModel
    {
        public int Id { get; protected set; }

        public abstract ModelTypeDb DbModel { get; protected set; }

        public abstract string Name { get; set; }

        public abstract string GetAttributs();

        public abstract List<string> GetListAttributes();

        public abstract void SetAttributes(MySqlDataReader sqlResult);
    }
}
