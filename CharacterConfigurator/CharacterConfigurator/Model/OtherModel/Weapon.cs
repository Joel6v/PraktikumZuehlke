using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Weapon : IBaseModel<Weapon>, IItem
    {
        public Weapon()
        {

        }

        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.WEAPON;

        public string Name { get; set; }

        public BitmapImage Image { get; set; }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            DamagePerHit = sqlResult.GetInt32(2);
            AttackSpeed = (AttackSpeed)sqlResult.GetInt32(3);
            Image = DataHandler.LoadImage((byte[])sqlResult.GetValue(4));
        }

        public int DamagePerHit {  get; private set; }

        public AttackSpeed AttackSpeed { get; private set; }
    }
}
