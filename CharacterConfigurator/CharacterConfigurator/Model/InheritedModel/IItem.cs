using System.Windows.Media.Imaging;

namespace CharacterConfigurator.Model
{
    public interface IItem
    {
        BitmapImage Image { get; set; }
    }
}
