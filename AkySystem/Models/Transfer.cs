namespace AkySystem.Models
{
    public class Transfer
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; } // ← добавлено!
        public DateTime Date { get; set; }
    }
}