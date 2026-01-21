namespace AkySystem
{
    public partial class App : Application

    {
        public static AkySystem.Services.TransferService TransferService = new AkySystem.Services.TransferService();
        public static string CurrentUser = "User1"; // или как у тебя логин хранится
        public App()
        {
            InitializeComponent();
           MainPage = new AppShell();
        }

        // Когда приложение уходит в фон
        protected override void OnSleep()
        {
            // Сохраняем время выхода
            Preferences.Set("LastExitTime", DateTime.Now);
        }

        // Когда приложение возвращается из фона
        protected override void OnResume()
        {
            CheckSession();
        }

        private void CheckSession()
        {
            if (Preferences.Get("is_logged_in", false))
            {
                DateTime lastExit = Preferences.Get("LastExitTime", DateTime.Now);
                TimeSpan diff = DateTime.Now - lastExit;

                if (diff.TotalMinutes > 30)
                {
                    // Получаем AuthService через DI
                    var authService = ServiceHelper.GetService<AuthService>();
                    authService?.Logout();
                }
            }
        }
    }
}