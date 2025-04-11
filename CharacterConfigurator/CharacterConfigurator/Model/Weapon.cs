using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterConfigurator.Model.CharacterEnum;
using CharacterConfigurator.Controller;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Model
{
    public class Weapon : IItem
    {
        public override DbEnum.ModelTypeDb DbModel { get; protected set; } = DbEnum.ModelTypeDb.WEAPON;

        public override string Name
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

        public override string GetAttributs()
        {
            return $"'{Name}', {DamagePerHit}, {(int)AttackSpeed}";
        }

        public override List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{DamagePerHit}", $"{(int)AttackSpeed}"};
        }

        public override void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            DamagePerHit = sqlResult.GetInt32(2);
            AttackSpeed = (AttackSpeed)sqlResult.GetInt32(3);
        }

        public int DamagePerHit {  get; private set; }

        public AttackSpeed AttackSpeed { get; private set; }

        public Weapon()
        {

        }

        public Weapon(int id, string name, string pathImage, int damagePerHit, AttackSpeed attackSpeed) 
        { 
            Id = id;
            Name = name;
            PathImage = pathImage;
            DamagePerHit = damagePerHit;
            AttackSpeed = attackSpeed;
        }
    }
}
