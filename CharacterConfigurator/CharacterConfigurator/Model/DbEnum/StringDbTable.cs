using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.DbEnum
{
    public class StringDbTable : Attribute
    {
        public string Value { get; set; }

        public StringDbTable(string value)
        {
            Value = value;
        }
    }

    public static class EnumExtensionsDbTable
    {
        public static string GetStringTable(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(StringDbTable), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((StringDbTable)attrs[0]).Value;
                }
            }

            return value.ToString();
        }
    }
}
