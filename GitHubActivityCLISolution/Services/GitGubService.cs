using ServiceContracts;
using System.Collections;
using System.Text.Json;

namespace Services
{
    public class GitGubService : IGitGubService
    {
        private readonly HttpClient _httpClient;
        public GitGubService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GitHubActivity");
        }

        public async Task<List<Dictionary<string, object>>?> FetchActivity(string userName)
        {
            string url = $"https://api.github.com/users/{userName}/events";

            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url);
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                List<Dictionary<string, object>>? responseList =
                    JsonSerializer.Deserialize<List<Dictionary<string, object>>>(responseBody);

                return responseList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
