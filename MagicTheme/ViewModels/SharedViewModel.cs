using MagicTheme.Models;
using MagicTheme.Utils.Handlers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using SettingsUI.Helpers;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Windows.ApplicationModel;
using Windows.System.UserProfile;

namespace MagicTheme.ViewModels
{
    public class SharedViewModel : ObservableObject
    {
        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, ImagePath); }
        }

        public ImageSource SetImage(Image image)
        {


            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);

            const uint SPI_GETDESKWALLPAPER = 0x0073;
            StringBuilder wallPaperPath = new StringBuilder(200);

            if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
            {
                return image.Source = new BitmapImage(new Uri(wallPaperPath.ToString()));
            }
            else
            {
                return new BitmapImage(new Uri(""));
            }
        }
        public bool IsDevMode
        {
            get;
            set;
        } = ApplicationHelper.IsPackaged && Package.Current.IsDevelopmentMode;

        public string CurrentAppearance
        {
            get; set;
        } = SettingsUI.Helpers.ThemeHelper.ActualTheme.ToString();

        public string Username { get; set; } 
 //       if (UserInformation.NameAccessAllowed == true)
   //         {

    } 
}

