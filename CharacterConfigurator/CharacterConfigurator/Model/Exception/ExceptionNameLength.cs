using CharacterConfigurator.Controller;

namespace CharacterConfigurator.Model
{
    public class ExceptionNameLength : Exception
    {
        private string _Message;
        public override string Message => _Message;

        public ExceptionNameLength(bool maxLength)
        {
            if (maxLength)
            {
                _Message = $"The Username is too short or too long. The minimum length is {DataHandler.MinNameLength} and the maximum length is {DataHandler.MaxNameLength}.";
            }
            else
            {
                _Message = $"The Username is too short. The minimum length is {DataHandler.MinNameLength}.";
            }
        }
    }
}
