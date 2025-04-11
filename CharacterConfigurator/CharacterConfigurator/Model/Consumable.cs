using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public class Consumable : IBaseModel<Clothing>, IItem
    {
        public int Id { get; private set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.CONSUMABLE;

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

        public static string BasePathImage { get; } = AppContext.BaseDirectory + ImagePath.RootPath + "Consumable\\";

        public string GetFullPathImage()
        {
            return BasePathImage;
        }

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

        public Consumable(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
