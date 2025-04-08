using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Race : Item
    {
        public int Health { get; private set; }

        public int Magicka { get; private set; }

        public int Stamina { get; private set; }

        public Skill Skill { get; private set; }

        public Race(int health, int magicka, int stamina, Skill skill)
        {
            Health = health;
            Magicka = magicka;
            Stamina = stamina;
            Skill = skill;
        }
    }
}
