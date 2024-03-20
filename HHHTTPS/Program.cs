using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HHHTTPS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 10000000; i++)
            {
                string url = $"https://www.google.com/search?q={Guid.NewGuid()}"; 
                var http = new HttpClient();
                var response = await http.GetAsync(url);
                Console.WriteLine($"Запрос: {i + 1}: {(int)response.StatusCode}");
                tasks.Add(response.Content.ReadAsStringAsync());
            }
            await Task.WhenAll(tasks);
            Console.WriteLine("Все запросы завершены.");
            Console.ReadKey();
        }
    }
}
//Написать свой тестировщик где вы указывете путь и количество запросов и происходит атака на этот сайт