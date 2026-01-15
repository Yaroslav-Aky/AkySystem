using AkySystem.Pages;
using CommunityToolkit.Maui.Alerts;

namespace AkySystem;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Регистрируем маршрут для главной страницы
        Routing.RegisterRoute(nameof(MainPage), typeof(Pages.MainPage));
    }


    // Этот метод исправит все ошибки "DisplayToastAsync"
    public static async Task DisplayToastAsync(string message)
    {
        var toast = Toast.Make(message);
        await toast.Show();
    }
}