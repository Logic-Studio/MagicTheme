using MagicTheme.Helpers.Navigation;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MagicTheme.ViewModels
{
    public class ShellViewModel : ObservableObject
    {
        private string _header;
        private bool isBackEnabled;
        private bool enumerate_navigationItemsOnItemInvoke;
        private IEnumerable<NavigationViewItem> navigationItems;
        private NavigationView navigationView;
        private Type defaultPage;
        private Type settingsPage;
        private NavigationViewItem selected;
        private ICommand loadedCommand;
        private ICommand itemInvokedCommand;

        public bool IsBackEnabled
        {
            get { return isBackEnabled; }
            set { SetProperty(ref isBackEnabled, value); }
        }
        public NavigationViewItem Selected
        {
            get { return selected; }
            set { SetProperty(ref selected, value); }
        }
        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }
        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(OnLoaded);

        public ICommand ItemInvokedCommand => itemInvokedCommand ??= new RelayCommand<NavigationViewItemInvokedEventArgs>(OnItemInvoked);
            public async void OnLoaded()
        {
            await Task.CompletedTask.ConfigureAwait(false);

            if (defaultPage != null)
            {
                NavigationService.Navigate(defaultPage);
            }
            navigationItems = GetAllNavigationViewItems();
        }
         private void InternalInitialize(Frame frame ,NavigationView navigationView)
        {
            this.navigationView = navigationView;
            NavigationService.Frame = frame;
            NavigationService.NavigationFailed += Frame_NavigationFailed;
            NavigationService.Navigated += Frame_Navigated;
            this.navigationView.BackRequested += OnBackRequested;
        }
        /// <summary>
        /// Initialize ShellViewModel
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="navigationView"></param>
        /// <returns></returns>
        public ShellViewModel InitializeNavigation(Frame frame, NavigationView navigationView)
        {
            InternalInitialize(frame, navigationView);
            return this;
        }
        public ShellViewModel LoadSettingsPage(Type settingsPage)
        {
            this.settingsPage = settingsPage;
            return this;
        }
        public ShellViewModel LoadDefaultPage(Type defaultPage)
        {
            this.defaultPage = defaultPage;
            return this;
        }
        private void OnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            NavigationService.GoBack();
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw e.Exception;
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            IsBackEnabled = NavigationService.CanGoBack;
            if (e.SourcePageType == settingsPage)
            {
                Selected = (NavigationViewItem)navigationView.SettingsItem;
            }
            else if (e.SourcePageType != null)
            {
                Selected = navigationView.MenuItems
                    .OfType<NavigationViewItem>()
                    .FirstOrDefault(menuItem => IsNavigationItemForPageType(menuItem, e.SourcePageType));
            }
        }

        private static bool IsNavigationItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            var pageType = menuItem.GetValue(NavigationHelper.NavigateToProperty) as Type;
            return pageType == sourcePageType;
        }
        public ShellViewModel LoadEnumerateNavigationItemsOnItemInvoke(bool enumerateMenuItemsOnItemInvoke = true)
        {
            this.enumerate_navigationItemsOnItemInvoke = enumerateMenuItemsOnItemInvoke;
            return this;
        }
        private IEnumerable<NavigationViewItem> EnumerateNavigationViewItem(IList<object> parent)
        {
            if (parent != null)
            {
                foreach (var g in parent)
                {
                    yield return (NavigationViewItem)g;

                    foreach (var sub in EnumerateNavigationViewItem(((NavigationViewItem)g).MenuItems))
                    {
                        yield return sub;
                    }
                }
            }
        }
        private IEnumerable<NavigationViewItem> GetAllNavigationViewItems()
        {
            var _menuItems = EnumerateNavigationViewItem(navigationView.MenuItems);
            var footer = EnumerateNavigationViewItem(navigationView.FooterMenuItems);
            return _menuItems.Concat(footer);
        }
        public void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true && settingsPage != null)
            {
                NavigationService.Navigate(settingsPage);
            }
            else if(args.InvokedItemContainer != null)
            {
                if (enumerate_navigationItemsOnItemInvoke)
                {
                    navigationItems = GetAllNavigationViewItems();
                }
                var item = navigationItems.FirstOrDefault(navigationItems =>(string)navigationItems.Content == (string)args.InvokedItem);
                if(item != null)
                {
                    var pageType = item.GetValue(NavigationHelper.NavigateToProperty) as Type;
                    NavigationService.Navigate(pageType,null, new DrillInNavigationTransitionInfo());
                }

            }
        }
    }
}
