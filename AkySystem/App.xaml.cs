namespace AkySystem
{
    public partial class App : Application
    {
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

                if (diff.TotalMinutes >= 30)
                {
                    // Если у вас там создается экземпляр сервиса:
                    var authService = new AkySystem.Services.AuthService();
                    authService.Logout();
                }
            }
        }
    }
}