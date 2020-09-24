namespace HelpMap.ViewModels.User
{
    public class UserSettingsViewModel
    {
        public int Uuid { get; set; }
        public int idGrupo { get; set; }
        public string From { get; set; } = "custom-db";
        public string Password { get; set; }
        public string Role { get; set; } = "admin";
        public DataViewModel Data { get; set; } = new DataViewModel();
    }
}
