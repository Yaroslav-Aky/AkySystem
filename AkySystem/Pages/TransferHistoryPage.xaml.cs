using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using AkySystem.Models;

namespace AkySystem.Pages
{
    public partial class TransferHistoryPage : ContentPage
    {
        public ObservableCollection<TransferHistoryItem> TransferHistoryItems { get; set; }

        public TransferHistoryPage()
        {
            InitializeComponent();
            TransferHistoryItems = new ObservableCollection<TransferHistoryItem>();
            HistoryList.ItemsSource = TransferHistoryItems;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TransferHistoryItems.Clear();
            var history = App.TransferService.GetHistory(App.CurrentUser);
            foreach (var t in history)
            {
                TransferHistoryItems.Add(new TransferHistoryItem
                {
                    Amount = (t.FromUser == App.CurrentUser ? "-" : "+") + t.Amount.ToString() + " Aky Coin",
                    Message = string.IsNullOrEmpty(t.Message) ? "(Без сообщения)" : t.Message,
                    Date = t.Date,
                    FromToText = t.FromUser == App.CurrentUser ? $"Вы отправили {t.ToUser}" : $"Вам от {t.FromUser}"
                });
            }
        }

        public class TransferHistoryItem
        {
            public string Amount { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public string FromToText { get; set; }
        }
    }
}