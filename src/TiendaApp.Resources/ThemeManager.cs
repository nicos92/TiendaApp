using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TiendaApp.Resources
{
    public static class ThemeManager
    {
        private static ResourceDictionary CurrentThemeDictionary;

        public static void SetLightTheme()
        {
            ChangeTheme("LightTheme");
        }

        public static void SetDarkTheme()
        {
            ChangeTheme("DarkTheme");
        }

        private static void ChangeTheme(string themeKey)
        {
            var app = Application.Current;
            var themeDict = app.Resources.MergedDictionaries[0];

            if (themeDict[themeKey] is ResourceDictionary newTheme)
            {
                // Remover el tema actual
                if (CurrentThemeDictionary != null)
                {
                    app.Resources.MergedDictionaries.Remove(CurrentThemeDictionary);
                }

                // Agregar el nuevo tema
                CurrentThemeDictionary = newTheme;
                app.Resources.MergedDictionaries.Add(newTheme);
            }
        }

        public static void Initialize()
        {
            // Por defecto, tema claro
            SetLightTheme();
        }
    }
}
