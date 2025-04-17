using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterConfigurator.View
{
    public static class ThemeManager
    {
        public static void ApplyTheme(string themeName)
        {
            var newTheme = new ResourceDictionary
            {
                Source = new Uri($"View/Themes/{themeName}Theme.xaml", UriKind.Relative)
            };

            var existingTheme = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source?.OriginalString.Contains("Theme") == true);

            if (existingTheme != null)
                Application.Current.Resources.MergedDictionaries.Remove(existingTheme);

            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }
    }
}
