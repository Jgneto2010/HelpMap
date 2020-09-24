using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.User
{
    public class ToolbarViewModel
    {
        public bool Display { get; set; } = true;
        public string Style { get; set; } = "fixed";
        public string Position { get; set; } = "below";
    }
}
