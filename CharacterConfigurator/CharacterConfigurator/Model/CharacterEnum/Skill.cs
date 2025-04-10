using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.CharacterEnum
{
    public enum Skill
    {
        [StringValue("None")]
        NONE,
        [StringValue("Smithing")]
        SMITHING,
        [StringValue("Archery")]
        ARCHERY,
        [StringValue("Enchanting")]
        ENCHANTING,
        [StringValue("Lockpicking")]
        LOCKPICKING
    }
}
