using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public interface IItem
    {
        abstract static string BasePathImage { get;  }

        string GetFullPathImageStr();

        BitmapImage GetFullPathImage();
    }

    public class ImagePath
    {
        private const string RootPath = @"\Resources\Image\";

        public readonly static string FullRootPath = AppContext.BaseDirectory + RootPath;
    }
}
