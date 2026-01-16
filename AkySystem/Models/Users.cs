using SQLite;

namespace AkySystem.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, NotNull]
        public string Login { get; set; }

        [NotNull]
        public string Password { get; set; }
    }
}
