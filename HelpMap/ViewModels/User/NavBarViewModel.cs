using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.User
{
    public class NavBarViewModel
    {
        public bool Display { get; set; } = true;
        public bool Folded { get; set; } = false;
        public string Position { get; set; } = "left";
    }
}
