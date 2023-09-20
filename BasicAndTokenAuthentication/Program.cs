using System;
using System.Net;
using System.Text;

class Program
{
    static void Main()
    {
        string url = "https://example.com/api/resource";
        string username = "your_username";
        string password = "your_password";

        // Kullanıcı adı ve parola Base64 ile kodlanır
        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));

        // HTTP isteği oluşturulur
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Headers.Add("Authorization", "Basic " + credentials);

        try
        {
            // İstek gönderilir ve yanıt alınır
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine("Response: " + response.StatusDescription);
        }
        catch (WebException ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }
}

