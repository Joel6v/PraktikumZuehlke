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
