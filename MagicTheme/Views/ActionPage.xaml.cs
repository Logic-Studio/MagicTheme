using MagicTheme.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MagicTheme.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActionPage : Page
    {
        public ActionViewModel ViewModel { get;} = new ActionViewModel();
        public ActionPage()
        {
            this.InitializeComponent();
            ViewModel.IsInforTipOn = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SetAppearanceToDarkCommand();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.SetAppearanceToLightCommand();
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
        }


        private void AutoAppearanceSwitcher_Toggled(object sender, RoutedEventArgs e)
        {
            if (AutoAppearanceSwitcher.IsOn)
            {
                if (ModeSelector.SelectedIndex == -1)
                {
                    ViewModel.IsAppearanceScheduleOn = true;
                }
                else
                {
                    if (ModeSelector.SelectedIndex == 0)
                    {
                        ViewModel.IsAppearanceScheduleOn = true;
                    }
                    else if (ModeSelector.SelectedIndex == 1)
                    {
                        ViewModel.IsAppearanceScheduleOn = false;
                    }
                }
            }
            else
            {
                ViewModel.IsAppearanceScheduleOn = false;
            }
        }

        private void ModeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ModeSelector.SelectedIndex == 0)
            {
                ViewModel.IsAppearanceScheduleOn = true;
            }
            else
            {
                ViewModel.IsAppearanceScheduleOn = false;
                if(ViewModel.IsNeverRemindOn ==false)ViewModel.IsInforTipOn = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModel.IsNeverRemindOn = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }
    }
}
