using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    enum ClothingType : int
    {
        [StringValue("Headgear")]
        HEADGEAR,
        [StringValue("Chest")]
        CHEST,
        [StringValue("Gloves")]
        GLOVES,
        [StringValue("Legs")]
        LEGS
    }
}
