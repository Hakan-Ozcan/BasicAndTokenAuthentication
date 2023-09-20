using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://example.com/api/resource";
        string token = "your_access_token";

        using (HttpClient client = new HttpClient())
        {
            // Belirteci isteğin "Authorization" başlığına eklenir
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                // GET isteği yapılır
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + content);
                }
                else
                {
                    Console.WriteLine("Hata: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}

