using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public abstract class Item<T> where T : class
    {
        public uint Id { get; protected set; }
        //public required string Name { get; set; }
        public string Name { get; protected set; }
        public string PathImage { get; protected set; }

        public static string DbTableName { get; protected set; }
    }
}
