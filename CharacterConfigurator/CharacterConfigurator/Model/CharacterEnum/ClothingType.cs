using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.CharacterEnum
{
    public enum ClothingType
    {
        [StringValue("Headgear")]
        [StringPathImage("Headgear")]
        HEADGEAR,
        [StringValue("Chest")]
        [StringPathImage("Chest")]
        CHEST,
        [StringValue("Gloves")]
        [StringPathImage("Gloves")]
        GLOVES,
        [StringValue("Legs")]
        [StringPathImage("Legs")]
        LEGS
    }
}
