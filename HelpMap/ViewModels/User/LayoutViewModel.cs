using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.User
{
    public class LayoutViewModel
    {
        public string Style { get; set; } = "layout1";

        public ConfigViewModel Config { get; set; } = new ConfigViewModel();
    }
}
