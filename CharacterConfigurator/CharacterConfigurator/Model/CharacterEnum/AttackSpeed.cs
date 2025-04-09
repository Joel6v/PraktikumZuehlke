using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public enum AttackSpeed
    {
        [StringValue("Slow")]
        SLOW,
        [StringValue("Medium")]
        MEDIUM,
        [StringValue("Fast")]
        FAST,
        [StringValue("Very Fast")]
        VERY_FAST
    }
}
