using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class ApiService
{
    private static string GetBaseUrl()
    {
#if ANDROID
        return "http://10.0.2.2:5121/api/auth/";
#elif DEBUG
    return "http://192.168.0.10:5121/api/auth/";
#else
    return "http://0.0.0.0:5121/api/auth/";
#endif
    }

    // Применяешь:
    private readonly HttpClient httpClient;

    public ApiService()
    {
        httpClient = new HttpClient()
        {
            BaseAddress = new Uri(GetBaseUrl())
        };
    }


    public async Task<bool> CreateTransferAsync(int fromUserId, int toUserId, decimal amount)
    {
        var dto = new
        {
            fromUserId = fromUserId,
            toUserId = toUserId,
            amount = amount
        };

        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var resp = await httpClient.PostAsync("transfer", content);

        return resp.IsSuccessStatusCode;
    }

    public async Task<(bool ok, string body)> RegisterUserAsync(string login, string password)
    {
        var dto = new { Login = login.Trim(), Password = password };
        var resp = await httpClient.PostAsJsonAsync("register", dto);
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }

    public async Task<(bool ok, string body)> LoginUserAsync(string login, string password)
    {
        var dto = new { Login = login.Trim(), Password = password };
        var resp = await httpClient.PostAsJsonAsync("login", dto);
        var body = await resp.Content.ReadAsStringAsync();
        return (resp.IsSuccessStatusCode, body);
    }
}