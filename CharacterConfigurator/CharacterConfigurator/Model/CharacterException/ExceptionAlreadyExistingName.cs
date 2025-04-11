namespace CharacterConfigurator.Model
{
    class ExceptionAlreadyExistingName : Exception
    {
        public override string Message => "This name already exists.";

        public ExceptionAlreadyExistingName()
        {

        }
    }
}
