using MagicTheme.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SettingsUI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MagicTheme.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();
       // public SystemBackdropsHelper backdropsHelper = SystemBackdropsHelper.GetCurrent();
        public ShellPage()
        {
            this.InitializeComponent();

            ViewModel.InitializeNavigation(shellFrame, shellNavi)
                .LoadDefaultPage(typeof(DashboardPage))
                .LoadSettingsPage(typeof(SettingsPage));
                ;
            ViewModel.Header = "开始";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnLoaded();            
            //BackdropType newType;
            //switch (backdropsHelper.CurrentBackdrop)
            //{
            //    case BackdropType.Mica: newType = BackdropType.DesktopAcrylic; break;
            //    case BackdropType.DesktopAcrylic: newType = BackdropType.DefaultColor; break;
            //    default:
            //    case BackdropType.DefaultColor: newType = BackdropType.Mica; break;
            //}
            //backdropsHelper.SetBackdrop(newType);
        }

        private void shellNavi_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ViewModel.OnItemInvoked(args);
            ViewModel.Header = args.InvokedItem.ToString();
        }
    }
}
