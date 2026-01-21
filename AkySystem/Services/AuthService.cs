using System.Threading.Tasks;
using AkySystem.Services;

namespace AkySystem.Services
{
    public class AuthService
    {
        private readonly ApiService _apiService;

        public AuthService(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Регистрация пользователя на сервере
        public async Task<(bool ok, string message)> RegisterUserAsync(string login, string password)
        {
            var (ok, body) = await _apiService.RegisterUserAsync(login, password);
            return (ok, body);
        }

        // Попытка логина на сервере
        public async Task<(bool ok, string message)> LoginUserAsync(string login, string password)
        {
            var (ok, body) = await _apiService.LoginUserAsync(login, password);
            if (ok)
            {
                // При успехе входа можно сохранить флаг или токен, если нужно
                Microsoft.Maui.Storage.Preferences.Default.Set("is_logged_in", true);
            }
            return (ok, body);
        }

        // Выход из системы (опционально)
        public void Logout()
        {
            Microsoft.Maui.Storage.Preferences.Default.Set("is_logged_in", false);
        }
    }
}
