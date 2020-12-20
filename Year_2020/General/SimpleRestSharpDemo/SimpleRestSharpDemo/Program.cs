using RestSharp;
using System.IO;
using static System.Console;

namespace SimpleRestSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeLogicAppsHttpsEnpoint();

            GetStockPrices();

            WriteLine("\n\nPress any key ...");
            ReadKey();
        }

        private static void InvokeLogicAppsHttpsEnpoint()
        {
            var mainUrl = "https://YourEndPoint.eastus.logic.azure.com:443";
            var endPoint = "/workflows/SomeNumber/triggers/manual/paths/invoke";

            var client = new RestClient(mainUrl);
            var request = new RestRequest(endPoint, Method.POST);

            request.AddJsonBody(new
            {
                id = "101",
                name = "Joe Davis"
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            WriteLine($"Output: {content}");
        }

        private static void GetStockPrices()
        {
            var restSharpClient = new RestClient("https://www.otcmarkets.com");

            var downloadRequest = new RestRequest("research/stock-screener/api/downloadCSV?pageSize=20",
                Method.GET);

            var fileInBytes = restSharpClient.DownloadData(downloadRequest);

            File.WriteAllBytes(@"D:\LordKrishna\GitHub\speaker_series_2020\General\SimpleRestSharpDemo\SimpleRestSharpDemo\Downloads\StockData.xlsx",
                fileInBytes);
        }
    }
}
