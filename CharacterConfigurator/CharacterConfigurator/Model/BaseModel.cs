using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CharacterConfigurator.Model
{
    public abstract class BaseModel<T> where T : class
    {
        public uint Id { get; protected set; }

        public abstract string Name { get;set; }

        public static string DbTableName { get; private set; }

        public abstract string ConvertToSqlInsert();
    }
}
