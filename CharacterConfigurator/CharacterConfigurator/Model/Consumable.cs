using CharacterConfigurator.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public class Consumable : Item
    {
        public int Id { get; private set; }

        public static DbEnum.ModelTypeDb DbModel { get; protected set; } = DbEnum.ModelTypeDb.CONSUMABLE;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (!MainController.ConsumableController.CheckIfNameExists(value))
                {
                    _Name = value;
                }
            }
        }
        private string _Name { get; set; }

        public string GetAttributs()
        {
            return $"'{Name}'";
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
        }

        public Consumable()
        {

        }

        public Consumable(int id, string name, string pathImage)
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
        }
    }
}
