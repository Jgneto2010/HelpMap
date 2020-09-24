using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.User
{
    public class ConfigViewModel
    {
        public string Scroll { get; set; } = "content";
        public string Mode { get; set; } = "fullwidth";

        public NavBarViewModel Navbar { get; set; } = new NavBarViewModel();
        public ToolbarViewModel Toolbar { get; set; } = new ToolbarViewModel();
        public FooterViewModel Footer { get; set; } = new FooterViewModel();
    }
}

