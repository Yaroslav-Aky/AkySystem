using AkySystem.Services;

namespace AkySystem.Pages
{
    public partial class RegistrationPage : ContentPage
    {
        private readonly AuthService _authService;

        public RegistrationPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string login = LoginEntry.Text?.Trim();
            string password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль.", "OK");
                return;
            }

            var (isSuccess, message) = await _authService.RegisterUserAsync(login, password);

            if (isSuccess)
            {
                await DisplayAlert("Успешно", "Вы зарегистрированы!", "OK");
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await DisplayAlert("Ошибка регистрации", message, "OK");
            }
        }
            private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }

}
