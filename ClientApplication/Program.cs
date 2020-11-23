using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace OcelotGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7001/api/");
                //HTTP GET
                var responseTask = client.GetAsync("apione");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var values = JsonConvert.DeserializeObject<string[]>(readTask.Result);

                    foreach (var value in values)
                    {
                        Console.WriteLine(value);
                    }
                }


                responseTask = client.GetAsync("apitwo");
                responseTask.Wait();

                result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var values = JsonConvert.DeserializeObject<string[]>(readTask.Result);

                    foreach (var value in values)
                    {
                        Console.WriteLine(value);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
