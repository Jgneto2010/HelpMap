using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.User
{
    public class SettingsViewModel
    {
        public bool CustomScrollbars { get; set; } = true;

        public LayoutViewModel Layout { get; set; } = new LayoutViewModel();
        public ThemeViewModel Theme { get; set; } = new ThemeViewModel();
    }
}
