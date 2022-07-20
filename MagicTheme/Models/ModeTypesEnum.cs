using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheme.Models
{
    public enum SettingsChangeType
    {
        [Description("Based on individual settings")]
        Custom,
        [Description("Change System & App Appearance")]
        Default,
        [Description("Based on a .theme file")]
        Theme
    }
    public enum WindowsThemeType
    {
        Dark =0,
        Light =1
    }
}
