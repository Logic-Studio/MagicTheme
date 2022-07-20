using MagicTheme.Models;
using MagicTheme.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheme.Utils.Handlers
{
    public class AppearanceHandler
    {
        private ActionViewModel ViewModel { get; } =new ActionViewModel();

        public void SetAppearanceToLight(SettingsChangeType changeType)
        {
            if(changeType == SettingsChangeType.Custom)
            {
                if (ViewModel.ChangeAppTheme) RegistryHandler.SetAppAppearance(true);
                if (ViewModel.ChangeSystemTheme) RegistryHandler.SetSystemAppearance(true);
              //TODO: if (ViewModel.ChangeWallpaper) WallpaperHandler.ChangeWallpaper(ViewModel.LightWallpaperPath);
            }
            else if (changeType == SettingsChangeType.Theme)
            {
             //   ThemeHandler.ChangeTheme(ViewModel.LightThemePath);
            }
            else if (changeType == SettingsChangeType.Default)
            {
                RegistryHandler.SetAppAppearance(true);
                RegistryHandler.SetSystemAppearance(true);
            }
        }
        public void SetAppearanceToDark(SettingsChangeType changeType)
        {
            if (changeType == SettingsChangeType.Custom)
            {
                if (ViewModel.ChangeAppTheme) RegistryHandler.SetAppAppearance(false);
                if (ViewModel.ChangeSystemTheme) RegistryHandler.SetSystemAppearance(false);
                //TODO: if (ViewModel.ChangeWallpaper) WallpaperHandler.ChangeWallpaper(ViewModel.DarkWallpaperPath);
            }
            else if (changeType == SettingsChangeType.Theme)
            {
                //   ThemeHandler.ChangeTheme(ViewModel.DarkThemePath);
            }
            else if (changeType == SettingsChangeType.Default)
            {
                RegistryHandler.SetAppAppearance(false);
                RegistryHandler.SetSystemAppearance(false);
            }
        }

    }
}
