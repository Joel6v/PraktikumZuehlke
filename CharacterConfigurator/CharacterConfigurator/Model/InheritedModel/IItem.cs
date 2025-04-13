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

        public const string FileExtension = ".png";
    }
}
