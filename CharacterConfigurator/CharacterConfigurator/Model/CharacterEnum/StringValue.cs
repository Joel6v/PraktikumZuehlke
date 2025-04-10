using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.CharacterEnum
{
    public class StringValue : Attribute
    {
        public string Value { get; set; }

        public StringValue(string value) 
        {
            Value = value;
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
                        return ((StringValue)attrs[0]).Value;
                    }
                }

                return value.ToString();
            }
        }

}
