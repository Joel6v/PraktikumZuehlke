using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class ExceptionAlreadyExistingName : Exception
    {
        public override string Message => "This name is already exsisting";

        public ExceptionAlreadyExistingName()
        {

        }
    }
}
