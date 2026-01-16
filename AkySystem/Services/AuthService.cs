using Microsoft.Maui.Storage;
using AkySystem.Models;           // для User
using System.Threading.Tasks;     // для Task
using AkySystem.Services;         // для DatabaseService

namespace AkySystem.Services
{
    public class AuthService
    {
        private readonly DatabaseService _dbService;

        public AuthService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Register(string username, string password)
        {
            var existingUser = await _dbService.GetUserAsync(username);
            if (existingUser != null)
                return false;

            await _dbService.AddUserAsync(new User { Login = username, Password = password });
            Microsoft.Maui.Storage.Preferences.Default.Set("is_registered", true);
            Microsoft.Maui.Storage.Preferences.Default.Set("is_logged_in", true);
            return true;
        }

        public async Task<bool> Login(string login, string password)
        {
            var user = await _dbService.GetUserAsync(login);
            if (user != null && user.Password == password)
            {
                Microsoft.Maui.Storage.Preferences.Default.Set("is_logged_in", true);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            Microsoft.Maui.Storage.Preferences.Default.Set("is_logged_in", false);
        }
    }
}