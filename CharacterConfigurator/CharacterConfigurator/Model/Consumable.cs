using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Consumable : Item<Consumable>
    {
        public Consumable(uint id, string name, string pathImage)
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
        }
    }
}
