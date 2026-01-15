using AkySystem.Services;
using Microsoft.Extensions.Logging.Abstractions;
using AkySystem.Pages;

namespace AkySystem.Pages;

public partial class RegistrationPage : ContentPage
{
    // Создаем "инструмент" для работы с авторизацией
    AuthService _authService = new AuthService();

    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // 1. Проверяем, не пустые ли поля (LoginEntry и PasswordEntry - это x:Name твоих полей в XAML)
        if (string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля!", "OK");
            return; // Останавливаем выполнение кода дальше
        }

        // 2. Если поля заполнены, идет твоя логика регистрации (сохранение в базу и т.д.)
        // ... твой код сохранения ...

        // 3. После успеха — перекидываем на главную страницу!
        await DisplayAlert("Успех", "Вы успешно зарегистрированы!", "OK");
        // Это сбросит стек навигации и откроет главную страницу
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");


        // ПЕРЕХОД:
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        // Или, если не используешь Shell: await Navigation.PushAsync(new MainPage());
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

}