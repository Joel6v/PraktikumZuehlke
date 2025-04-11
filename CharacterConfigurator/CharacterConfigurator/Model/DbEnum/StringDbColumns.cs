using System.Reflection;

namespace CharacterConfigurator.Model.DbEnum
{
    public class StringDbColumns : Attribute
    {
        public List<string> Value { get; set; }

        public StringDbColumns(string[] values)
        {
            Value = values.ToList();
        }
    }

    public static class EnumExtensionsDbColumns
    {
        public static string GetStringColumns(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(StringDbColumns), false);

                if (attrs != null && attrs.Length > 0)
                {
                    string valueStr = string.Empty;
                    foreach (string item in ((StringDbColumns)attrs[0]).Value)
                    {
                        valueStr += item + ", ";
                    }
                    valueStr = valueStr.Remove(valueStr.Length - 2);
                    return valueStr;
                }
            }

            return value.ToString();
        }

        public static List<string> GetListColumns(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(StringDbColumns), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((StringDbColumns)attrs[0]).Value;
                }
            }

            return null;
        }
    }
}
