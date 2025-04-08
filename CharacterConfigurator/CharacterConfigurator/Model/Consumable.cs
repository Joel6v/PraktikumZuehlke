using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class Consumable : Item
    {
        public Consumable(int id, string name, string pathImage)
        {
            Id = id;
            Name = name;
            PathImage = pathImage;
        }
    }
}
