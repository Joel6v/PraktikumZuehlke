using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Weapon : Item<Weapon>
    {
        public int DamagePerHit {  get; private set; }

        public AttackSpeed AttackSpeed { get; private set; }

        public Weapon(uint id, string name, string pathImage, int damagePerHit, AttackSpeed attackSpeed) 
        { 
            Id = id;
            Name = name;
            PathImage = pathImage;
            DamagePerHit = damagePerHit;
            AttackSpeed = attackSpeed;
        }
    }
}
