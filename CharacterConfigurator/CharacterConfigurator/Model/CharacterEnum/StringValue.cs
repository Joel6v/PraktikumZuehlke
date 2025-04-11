using System.Reflection;

namespace CharacterConfigurator.Model.CharacterEnum
{
    public class StringValue : Attribute
    {
        public string FullName { get; set; }

        public StringValue(string fullName) 
        {
            FullName = fullName;
        }
    }


    public static class EnumExtensionsCharacter
    {
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(StringValue), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((StringValue)attrs[0]).FullName;
                }
            }

            return value.ToString();
        }
    }

}
