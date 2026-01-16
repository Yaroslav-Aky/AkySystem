using AkySystem.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace AkySystem.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        // Теперь DI сам передаст сюда сервис при создании страницы
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
                await DisplayAlert("Ошибка", "Ой, ошибка =( Похоже, вы не указали логин и пароль", "OK");
                return;
            }

            var isLogged = await _authService.Login(login, password);

            if (isLogged)
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await DisplayAlert("Ошибка", "Неправильный логин или пароль", "OK");
            }
        }
    }
}
