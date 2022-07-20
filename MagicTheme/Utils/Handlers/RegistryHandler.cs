using MagicTheme.Models;
using MagicTheme.Utils.Loggers;
using Microsoft.Win32;
using System;

namespace MagicTheme.Utils.Handlers
{
    public class RegistryHandler
    {
        private static readonly string KeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private static readonly ILogger Logger = AppLogger.GetLoggerForCurrentClass();

        public static WindowsThemeType GetAppTheme()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath))
            {
                object registryValueObject = key?.GetValue("AppsUseLightTheme");

                if (registryValueObject == null)
                {
                    return WindowsThemeType.Light;
                }

                int registryValue = (int)registryValueObject;

                return registryValue > 0 ? WindowsThemeType.Light : WindowsThemeType.Dark;
            }
        }


        /// <param name="param">Determin whether set to light(1) or dark(0)</param>
        public static void SetAppAppearance(object param)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath, true);
                key.SetValue("AppsUseLightTheme", (bool)param ? 1 : 0, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                Logger.Exception(ex);
            }
        }

        /// <param name="param">Determin whether set to light(1) or dark(0)</param>
        public static void SetSystemAppearance(object param)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath, true);
                key.SetValue("SystemUsesLightTheme", (bool)param ? 1 : 0, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                Logger.Exception(ex);
            }
        }

        public static bool CanSetAppearance(object param)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath, true);

            if (key.Handle.IsInvalid == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
