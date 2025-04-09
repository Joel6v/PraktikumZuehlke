using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class ExceptionInvalidLetters : Exception
    {
        public override string Message => "This input contains prohibited characters.";

        public ExceptionInvalidLetters()
        {

        }
    }
}
