using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace BddTests.Drivers;

public class WebDriver
{
    private HttpClient _httpClient;
    private HttpResponseMessage _httpResponseMessage;

    public void InitializeHttpClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task HttpClientGet(string url)
    {
        _httpResponseMessage = await _httpClient.GetAsync(url);
    }

    public async Task HttpClientPost(string url, string body)
    {
        _httpResponseMessage =
            await _httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
    }

    public void CheckResponseStatusCode(int expectedStatusCode)
    {
        _httpResponseMessage.StatusCode.Should().Be(expectedStatusCode);
    }
}