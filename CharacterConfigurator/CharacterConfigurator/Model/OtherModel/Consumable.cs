using CharacterConfigurator.Controller;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Consumable : IBaseModel<Consumable>, IItem
    {
        public Consumable()
        {

        }

        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.CONSUMABLE;

        public string Name { get; set; }

        public BitmapImage Image { get; set; }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            Image = DataConverter.LoadImage((byte[])sqlResult.GetValue(3));
        }
    }
}
