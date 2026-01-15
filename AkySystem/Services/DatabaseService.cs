using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AkySystem.Models;

namespace AkySystem.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null) return;

            // Путь к БД зависит от платформы (Android/Windows)
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "AkyDB.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<AkyItem>();
        }

        public async Task AddItem(AkyItem item)
        {
            await Init();
            await _database.InsertAsync(item);
        }

        public async Task<List<AkyItem>> GetItems()
        {
            await Init();
            return await _database.Table<AkyItem>().ToListAsync();
        }
    }
}
