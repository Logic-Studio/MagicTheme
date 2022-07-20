using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheme.Helpers.Navigation
{
    public class NavigationHelper
    {

        //Set property to navigate
        public static readonly DependencyProperty NavigateToProperty = DependencyProperty.RegisterAttached("NavigateTo", typeof(Type), typeof(NavigationHelper), new PropertyMetadata(null));
        public static Type GetNavigateTo(NavigationViewItem item)
        {
            return (Type)item?.GetValue(NavigateToProperty);
        }
        public static void SetNavigateTo(NavigationViewItem item, Type value)
        {
            item?.SetValue(NavigateToProperty, value);
        }
    }
}
