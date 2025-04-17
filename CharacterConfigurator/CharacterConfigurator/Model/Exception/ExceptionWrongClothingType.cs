namespace CharacterConfigurator.Model
{
    class ExceptionWrongClothingType : Exception
    {
        private string _Message;
        public override string Message => _Message;

        public ExceptionWrongClothingType(string requiredClothing) 
        {
            _Message = $"Wrong clothing for this clothing type selected. The required clothing type is {requiredClothing}.";
        }
    }
}
