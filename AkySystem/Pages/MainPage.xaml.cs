namespace AkySystem.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Тут мы можем вручную задать баланс для теста
        BalanceLabel.Text = "1500 Aky Coin";
    }

    // Это сработает, когда нажмешь "Перевести"
    private async void OnTransferClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AkySystem.Pages.TransferPage());
    }


    // Это сработает, когда нажмешь "Магазин"
    private async void OnShopClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Магазин", "Магазин пока в разработке", "ОК");
    }
}