using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public interface IItem
    {
        abstract static string BasePathImage { get;  }

        string GetFullPathImage();
    }

    public class ImagePath
    {
        public const string RootPath = @"\Resources\Image\";
    }
}
