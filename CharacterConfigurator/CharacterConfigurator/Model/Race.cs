using CharacterConfigurator.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterConfigurator.Model.CharacterEnum;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Model
{
    public class Race : IBaseModel<Clothing>, IItem
    {
        public static DbEnum.ModelTypeDb DbModel { get; } = DbEnum.ModelTypeDb.RACE;

        public override string Name
        {
            get { return _Name; }
            set
            {
                if (!MainController.RaceController.CheckIfNameExists(value))
                {
                    _Name = value;
                }
            }
        }
        private string _Name { get; set; }

        public override string GetAttributs()
        {
            return $"'{Name}', {Health}, {Magicka}, {Stamina}, {(int)Skill}";
        }

        public override List<string> GetListAttributes()
        {
            return new List<string>() { $"'{Name}'", $"{Health}", $"{Magicka}", $"{Stamina}", $"{(int)Skill}"};
        }

        public override void SetAttributes(MySqlDataReader sqlResult)
        {
            Id = sqlResult.GetInt32(0);
            Name = sqlResult.GetString(1);
            Health = sqlResult.GetInt32(2);
            Magicka = sqlResult.GetInt32(3);
            Stamina = sqlResult.GetInt32(4);
            Skill = (Skill)sqlResult.GetInt32(5);
        }

        public int Health { get; private set; }

        public int Magicka { get; private set; }

        public int Stamina { get; private set; }

        public Skill Skill { get; private set; }

        public Race()
        {

        }

        public Race(int id, string name, int health, int magicka, int stamina, Skill skill)
        {
            Id = id;
            Name = name;
            Health = health;
            Magicka = magicka;
            Stamina = stamina;
            Skill = skill;
        }
    }
}
