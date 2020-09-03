using RestSharp;
using System.IO;
using static System.Console;

namespace SimpleRestSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var restSharpClient = new RestClient("https://www.otcmarkets.com");

            var downloadRequest = new RestRequest("research/stock-screener/api/downloadCSV?pageSize=20", 
                Method.GET);

            var fileInBytes = restSharpClient.DownloadData(downloadRequest);

            File.WriteAllBytes(@"D:\LordKrishna\GitHub\speaker_series_2020\General\SimpleRestSharpDemo\SimpleRestSharpDemo\Downloads\StockData.xlsx",
                fileInBytes);

            WriteLine("\n\nPress any key ...");
            ReadKey();
        }
    }
}
