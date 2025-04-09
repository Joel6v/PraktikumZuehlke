using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public class Weapon : Item
    {
        public int DamagePerHit {  get; private set; }

        public new const string DbTableName = "weapon";

        public AttackSpeed AttackSpeed { get; private set; }

        public Weapon(uint id, string name, string pathImage, int damagePerHit, AttackSpeed attackSpeed) 
        { 
            Id = id;
            Name = name;
            PathImage = pathImage;
            DamagePerHit = damagePerHit;
            AttackSpeed = attackSpeed;
        }

        public override string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, pathImage, damagePerHit, attackSpeed) VALUE {Name}, {PathImage}, {DamagePerHit}, {Convert.ToInt32(AttackSpeed)};";
        }
    }
}
