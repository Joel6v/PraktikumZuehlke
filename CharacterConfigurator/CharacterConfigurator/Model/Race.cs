using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Race : Item
    {
        public new const string DbTableName = "race";

        public int Health { get; private set; }

        public int Magicka { get; private set; }

        public int Stamina { get; private set; }

        public Skill Skill { get; private set; }

        public Race(uint id, string name, int health, int magicka, int stamina, Skill skill)
        {
            Id = id;
            Name = name;
            Health = health;
            Magicka = magicka;
            Stamina = stamina;
            Skill = skill;
        }

        public override string ConvertToSqlInsert()
        {
            return $"INSERT INTO {DbTableName} (name, pathImage, health, magicka, stamina, skill) VALUE {Name}, {PathImage}, {Health}, {Magicka}, {Stamina}, {Convert.ToInt32(Skill)};";
        }
    }
}
