using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.DbEnum
{
    public class ColumnAmountImage : Attribute
    {
        public int AmountImage { get; set; }

        public ColumnAmountImage(int amountImage)
        {
            AmountImage = amountImage;
        }
    }

    public static class EnumExtensionsColumnImageTable
    {
        public static int GetAmountImages(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(ColumnAmountImage), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((ColumnAmountImage)attrs[0]).AmountImage;
                }
            }

            return -1;
        }
    }
}
