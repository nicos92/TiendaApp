using System;
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
            
            // Encontrar el diccionario principal que contiene los temas anidados
            ResourceDictionary mainThemeDict = null;
            foreach (var dict in app.Resources.MergedDictionaries)
            {
                if (dict.Contains("LightTheme") || dict.Contains("DarkTheme"))
                {
                    mainThemeDict = dict;
                    break;
                }
            }

            if (mainThemeDict != null && mainThemeDict[themeKey] is ResourceDictionary newTheme)
            {
                // Remover el tema actual
                if (CurrentThemeDictionary != null && app.Resources.MergedDictionaries.Contains(CurrentThemeDictionary))
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
            // Por defecto, tema oscuro
            SetDarkTheme();
        }
    }
}