using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public abstract class Item : BaseModel<Item>
    {
        //public required string Name { get; set; }
        public string Name { get; protected set; }
        public string PathImage { get; protected set; }

        public override string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, pathImage) VALUE {Name}, {PathImage};";
        }
    }
}
