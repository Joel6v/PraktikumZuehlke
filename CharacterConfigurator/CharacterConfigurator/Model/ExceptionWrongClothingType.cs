using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    class ExceptionWrongClothingType : Exception
    {
        private string _Message;
        public override string Message => _Message;

        public ExceptionWrongClothingType(string requiredClothing) 
        {
            _Message = $"Wrong clothing for this type selected. The required clothing is {requiredClothing}.";
        }
    }
}
