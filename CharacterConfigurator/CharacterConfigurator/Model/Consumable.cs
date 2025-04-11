using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Consumable : IBaseModel<Consumable>, IItem
    {
        public int Id { get; set; }

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

        public static string BasePathImage { get; } = ImagePath.FullRootPath + "Consumable\\";

        public string GetFullPathImageStr()
        {
            return BasePathImage + Name + ".png";
        }

        public BitmapImage GetFullPathImage()
        {
            return new BitmapImage(new Uri(GetFullPathImageStr(), UriKind.Absolute));
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
            _Name = sqlResult.GetString(1);
        }

        public Consumable()
        {

        }
    }
}
