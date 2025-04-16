using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model.Clothing
{
    public class Headgear : IBaseModel<Headgear>, IItem, IClothing
    {
        public Headgear() 
        {
        }

        public int Id { get; set; }

        public static ModelTypeDb DbModel { get; private set; } = ModelTypeDb.HEADGEAR;

        public string Name { get; set; }

        public BitmapImage Image { get; set; }

        public int Defense { get; set; }

        public string GetAttributs()
        {
            return string.Join(", ", GetListAttributes());
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{Defense}"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            Defense = sqlResult.GetInt32(2);
            Image = DataHandler.LoadImage((byte[])sqlResult.GetValue(3));
        }
    }
}
