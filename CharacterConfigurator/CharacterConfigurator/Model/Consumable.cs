using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Consumable : Item
    {
        public new const string DbTableName = "consumable";

        public Consumable(uint id, string name, string pathImage)
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
        }

        public override string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, pathImage) VALUE {Name}, {PathImage};";
        }
    }
}
