using AkySystem.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using static AkySystem.Pages.TransferHistoryPage;

namespace AkySystem.Pages
{
    public partial class TransferPage : ContentPage
    {
        public ObservableCollection<TransferHistoryItem> DisplayedTransfers { get; set; } = new ObservableCollection<TransferHistoryItem>();

        public TransferPage()
        {
            InitializeComponent();
            HistoryList.ItemsSource = DisplayedTransfers;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateHistory();
        }

        private void UpdateHistory()
        {
            DisplayedTransfers.Clear();
            var history = App.TransferService.GetHistory(App.CurrentUser);
            foreach (var t in history)
            {
                DisplayedTransfers.Add(new TransferHistoryItem
                {
                    AmountLabel = (t.FromUser == App.CurrentUser ? "-" : "+") + t.Amount.ToString() + " Aky Coin",
                    Message = string.IsNullOrEmpty(t.Message) ? "(Без сообщения)" : t.Message,
                    Date = t.Date,
                    Direction = t.FromUser == App.CurrentUser
                        ? $"Вы → {t.ToUser}"
                        : $"{t.FromUser} → Вы"
                });
            }
        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            var toUser = ToUserEntry.Text?.Trim();
            if (string.IsNullOrEmpty(toUser))
            {
                await DisplayAlert("Ошибка", "Введите логин получателя!", "OK");
                return;
            }

            if (!int.TryParse(AmountEntry.Text, out int amount) || amount <= 0)
            {
                await DisplayAlert("Ошибка", "Некорректная сумма!", "OK");
                return;
            }

            if (toUser == App.CurrentUser)
            {
                await DisplayAlert("Ошибка", "Нельзя перевести самому себе!", "OK");
                return;
            }

            var message = MessageEntry.Text ?? "";

            App.TransferService.MakeTransfer(App.CurrentUser, toUser, amount, message);

            ToUserEntry.Text = "";
            AmountEntry.Text = "";
            MessageEntry.Text = "";
            UpdateHistory();

            await DisplayAlert("Успешно", "Перевод выполнен!", "OK");
        }

        public class TransferHistoryItem
        {
            public string AmountLabel { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public string Direction { get; set; }
        }
    }
}