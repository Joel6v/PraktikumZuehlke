using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public class ExceptionNameLength : Exception
    {
        private string _Message;
        public override string Message => _Message;

        public ExceptionNameLength()
        {
            _Message = $"The Username is too short or too long. The minimum length is {DataConverter.MinNameLength} and the maximum length is {DataConverter.MaxNameLength}.";
        }
    }
}
