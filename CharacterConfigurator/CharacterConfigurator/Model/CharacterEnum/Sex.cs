using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.CharacterEnum
{
    public enum Sex
    {
        [StringValue("Male")]
        [StringPathImage("Male")]
        MALE,
        [StringValue("Female")]
        [StringPathImage("Female")]
        FEMALE
    }
}
