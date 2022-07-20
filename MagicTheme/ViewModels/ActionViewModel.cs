using MagicTheme.Models;
using MagicTheme.Utils.Handlers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MagicTheme.ViewModels
{
    public class ActionViewModel : ObservableObject
    {
        private static IEnumerable<KeyValuePair<T, string>> GetKeyValuePairFromEnum<T>()
        {
            Type type = typeof(T);

            IEnumerable<T> values = Enum.GetValues(type).Cast<T>();

            return values.Select((value) =>
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])type.GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

                string description = "";

                if (attributes.Length > 0)
                {
                    description = attributes.First().Description;
                }

                return new KeyValuePair<T, string>(value, description);
            });
        }

        private bool _enabled;
        public bool Enabled
        {
            get => _enabled;
            set => SetProperty(ref _enabled, value);
        }
        private DateTime _lightThemeTime = DateTime.Parse("0001-01-01T07:00:00");
        public DateTime LightThemeTime
        {
            get => _lightThemeTime;
            set => SetProperty(ref(_lightThemeTime), value);
        }
        private DateTime _darkThemeTime = DateTime.Parse("0001-01-01T07:00:00");
        public DateTime DarkThemeTime
        {
            get => _darkThemeTime;
            set => SetProperty(ref (_darkThemeTime), value);
        }
        private SettingsChangeType _changeType = SettingsChangeType.Custom;

        public SettingsChangeType ChangeType
        {
            get => _changeType;
            set => SetProperty(ref (_changeType), value);
        }
        public static IEnumerable<KeyValuePair<SettingsChangeType, string>> ChangeTypeValues = GetKeyValuePairFromEnum<SettingsChangeType>();

        private bool _changeSystemTheme;
        public bool ChangeSystemTheme
        {
            get => _changeSystemTheme;
            set => SetProperty(ref (_changeSystemTheme), value);
        }
        private bool _changeAppTheme;
        public bool ChangeAppTheme
        {
            get => _changeAppTheme; 
            set => SetProperty(ref (_changeAppTheme), value);
        }

        private bool _changeWallpaper;
        public bool ChangeWallpaper
        {
            get => _changeWallpaper;
            set => SetProperty(ref (_changeWallpaper), value);
        }

        private string _lightWallpaperPath;
        public string LightWallpaperPath
        {
            get => _lightWallpaperPath;
            set => SetProperty(ref(_lightWallpaperPath), value);
        }

        private string _darkWallpaperPath;
        public string DarkWallpaperPath
        {
            get => _darkWallpaperPath;
            set => SetProperty(ref (_darkWallpaperPath), value);
        }

        private string _lightThemePath;
        public string LightThemePath
        {
            get => _lightThemePath;
            set => SetProperty(ref(_lightThemePath), value);
        }

        private string _darkThemePath;
        public string DarkThemePath
        {
            get => _darkThemePath;
            set => SetProperty(ref (_darkThemePath), value);
        }

        public  void SetAppearanceToLightCommand()
        {
                AppearanceHandler handler = new AppearanceHandler();
                handler.SetAppearanceToLight(SettingsChangeType.Default);       
        }
        public void SetAppearanceToDarkCommand()
        {
            AppearanceHandler handler = new AppearanceHandler();
            handler.SetAppearanceToDark(SettingsChangeType.Default);
        }

        private bool isAppearanceScheduleOn;
                /// <summary>
        /// 控制根据时间外观切换开关
        /// </summary>
        public bool IsAppearanceScheduleOn { get => isAppearanceScheduleOn; set => SetProperty(ref (isAppearanceScheduleOn), value); }
        private bool isInforTipOn;
        public bool IsInforTipOn { get => isInforTipOn; set => SetProperty(ref (isInforTipOn), value); }
        private bool isNeverRemindOn;
        public bool IsNeverRemindOn { get => isNeverRemindOn; set => SetProperty(ref (isNeverRemindOn), value); }
    }
}
