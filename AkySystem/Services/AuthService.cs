namespace AkySystem.Services;

public class AuthService
{
    // Проверка, зарегистрирован ли кто-то
    public bool IsUserRegistered() => Preferences.Default.Get("is_registered", false);

    // Проверка, вошел ли пользователь
    public bool IsSessionActive() => Preferences.Default.Get("is_logged_in", false);

    // Вход (теперь принимает логин и пароль, чтобы не было ошибок)
    public void Login(string username, string password)
    {
        Preferences.Default.Set("is_logged_in", true);
    }

    // Регистрация (добавили этот метод)
    public void Register(string username, string password)
    {
        Preferences.Default.Set("is_registered", true);
        Preferences.Default.Set("is_logged_in", true); // Сразу входим после регистрации
    }

    public void Logout()
    {
        Preferences.Default.Set("is_logged_in", false);
    }
}