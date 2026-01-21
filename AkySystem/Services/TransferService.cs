using System.Collections.Generic;
using System.Linq;
using AkySystem.Models;

namespace AkySystem.Services
{
    public class TransferService
    {
        public List<Transfer> Transfers { get; } = new List<Transfer>();

        public void MakeTransfer(string from, string to, int amount, string message)
        {
            Transfers.Add(new Transfer
            {
                FromUser = from,
                ToUser = to,
                Amount = amount,
                Message = message?.Length > 100 ? message.Substring(0, 100) : message, // до 100 символов!
                Date = DateTime.Now
            });
        }

        // последние 10 переводов пользователя
        public List<Transfer> GetHistory(string username)
        {
            return Transfers
                .Where(t => t.FromUser == username || t.ToUser == username)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .ToList();
        }
    }
}