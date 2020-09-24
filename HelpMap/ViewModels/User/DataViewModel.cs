using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels.User
{
    public class DataViewModel
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }

        public List<string> Shortcuts { get; set; } = new List<string>()
        {
            "calendar",
            "perfil",
            "contacts"
        };

        public SettingsViewModel Settings { get; set; } = new SettingsViewModel();

    }
}
