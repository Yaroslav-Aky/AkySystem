using AkySystem.Services;
using Microsoft.Extensions.Logging.Abstractions;
using AkySystem.Pages;

namespace AkySystem.Pages;
public partial class LoginPage : ContentPage
{
    AuthService _authService = new AuthService();

    public LoginPage()
    {
        InitializeComponent();
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Передаем пустые строки, если поля не заполнены, чтобы не было вылета
        _authService.Login("user", "pass");
        await Shell.Current.GoToAsync("//MainPage");
    }
}