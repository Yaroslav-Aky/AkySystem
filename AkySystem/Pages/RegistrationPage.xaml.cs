using AkySystem.Services;

namespace AkySystem.Pages
{
    public partial class RegistrationPage : ContentPage
    {
        private readonly AuthService _authService;

        // DI-конструктор — DI сам передаст нужный сервис!
        public RegistrationPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var login = LoginEntry.Text?.Trim();
            var password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Поля логина и пароля не должны быть пустыми.", "OK");
                return;
            }

            // Пытаемся зарегистрировать пользователя
            var isRegistered = await _authService.Register(login, password);

            if (isRegistered)
            {
                await DisplayAlert("Успех", "Регистрация прошла успешно!", "ОК");
                await Shell.Current.GoToAsync("//LoginPage"); // Перейти на страницу входа после регистрации
            }
            else
            {
                await DisplayAlert("Ошибка", "Пользователь с таким логином уже существует.", "OK");
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
