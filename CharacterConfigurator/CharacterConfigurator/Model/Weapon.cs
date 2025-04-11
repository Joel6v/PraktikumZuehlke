using CharacterConfigurator.Controller;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public class Weapon : IBaseModel<Weapon>, IItem
    {
        public int Id { get; set; }

        public static DbEnum.ModelTypeDb DbModel { get; private set; } = DbEnum.ModelTypeDb.WEAPON;

        public string Name
        {
            get { return _Name; }
            set
            {
                if (!MainController.WeaponController.CheckIfNameExists(value))
                {
                    _Name = value;
                }
            }
        }
        private string _Name { get; set; }

        public static string BasePathImage { get; } = ImagePath.FullRootPath + "Weapon\\";

        public string GetFullPathImageStr()
        {
            return BasePathImage + Name + ImagePath.FileExtension;
        }

        public BitmapImage GetFullPathImage()
        {
            return new BitmapImage(new Uri(GetFullPathImageStr(), UriKind.Absolute));
        }

        public string GetAttributs()
        {
            return $"'{Name}', {DamagePerHit}, {(int)AttackSpeed}";
        }

        public List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{DamagePerHit}", $"{(int)AttackSpeed}"};
        }

        public void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            _Name = sqlResult.GetString(1);
            DamagePerHit = sqlResult.GetInt32(2);
            AttackSpeed = (AttackSpeed)sqlResult.GetInt32(3);
        }

        public int DamagePerHit {  get; private set; }

        public AttackSpeed AttackSpeed { get; private set; }

        public Weapon()
        {

        }
    }
}
