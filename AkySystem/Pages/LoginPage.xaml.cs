using AkySystem.Services;

namespace AkySystem.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var login = UsernameEntry.Text?.Trim();
            var password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Укажите логин и пароль", "OK");
                return;
            }

            var (isLogged, message) = await _authService.LoginUserAsync(login, password);

            if (isLogged)
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Ошибка", $"Не удалось войти: {message}", "OK");
            }
        }
    }
}
