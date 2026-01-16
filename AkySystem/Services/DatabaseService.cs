using SQLite;
using AkySystem.Models;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace AkySystem.Services // или AkySystem.Repositories — как у тебя
{
    public class ProjectRepository
    {
        private readonly DatabaseService _database;

        // ВОТ ЭТО — DI-конструктор
        public ProjectRepository(DatabaseService database)
        {
            _database = database;
        }

        public Task<List<Project>> GetProjectsAsync()
        {
            // тут используешь _database для запросов к БД
            // например:
            // return _database.Connection.Table<Project>().ToListAsync();
            throw new NotImplementedException();
        }

        // другие методы, использующие _database
    }


public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public async Task Init()
        {
            if (_database != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<User>();
        }

        public async Task<User> GetUserAsync(string login)
        {
            await Init();
            return await _database.Table<User>().FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<int> AddUserAsync(User user)
        {
            await Init();
            return await _database.InsertAsync(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Init();
            return await _database.Table<User>().ToListAsync();
        }
    }
}
