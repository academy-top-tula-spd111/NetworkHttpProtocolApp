//for(int i = 0; i < 10; i++)
//{
//    using(var client = new HttpClient())
//    {
//        using var result = await client.GetAsync("https://yandex.ru");
//        Console.WriteLine(result.StatusCode);
//    }
//}


//class Program
//{
//    static HttpClient? clientStatic;

//    static async Task Main(string[] args)
//    {
//        var socketHandler = new SocketsHttpHandler()
//        {
//            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
//        };
//        clientStatic = new HttpClient(socketHandler);
//    }
//}

//using Microsoft.Extensions.DependencyInjection;
//var services = new ServiceCollection();
//services.AddHttpClient();

//var servicesProvider = services.BuildServiceProvider();
//var httpClientFactory = servicesProvider.GetService<IHttpClientFactory>();

//var client1 = httpClientFactory?.CreateClient();

class Program
{
    static HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://yandex.ru");
        using HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

        Console.WriteLine($"Status Code: {responseMessage.StatusCode}");
        Console.WriteLine($"Headers:");
        foreach(var header in responseMessage.Headers)
        {
            Console.Write($"{header.Key}: ");
            foreach(var value in header.Value)
                Console.WriteLine($"{value}");
        }

        Console.WriteLine("\nContent:");
        string content = responseMessage.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);

        Console.WriteLine("\n\n");

        using HttpResponseMessage responseMessage1 = await client.GetAsync("https://yandex.ru");
        Console.WriteLine($"Status Code: {responseMessage1.StatusCode}");
        Console.WriteLine($"Headers:");
        foreach (var header in responseMessage1.Headers)
        {
            Console.Write($"{header.Key}: ");
            foreach (var value in header.Value)
                Console.WriteLine($"{value}");
        }

        Console.WriteLine("\nContent:");
        content = responseMessage1.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);

        Console.WriteLine("\n\n");

        string content1 = await client.GetStringAsync("https://yandex.ru");
        Console.WriteLine(content1);
    }
}
