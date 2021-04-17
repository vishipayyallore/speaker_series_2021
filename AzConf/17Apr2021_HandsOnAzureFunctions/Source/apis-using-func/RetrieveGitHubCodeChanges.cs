using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace AzGlobalIndia.Function
{
    public static class RetrieveGitHubCodeChanges
    {
        [FunctionName("RetrieveGitHubCodeChanges")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Table("GitCodeChanges")] CloudTable cloudTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            TableQuery<CodeChangesEntity> rangeQuery = new TableQuery<CodeChangesEntity>();

            foreach (CodeChangesEntity entity in
                await cloudTable.ExecuteQuerySegmentedAsync(rangeQuery, null))
            {
                log.LogInformation(
                    $"{entity.PartitionKey}\t{entity.RowKey}\t{entity.Timestamp}\t{entity.FullName}");
            }

            return new OkObjectResult(await cloudTable.ExecuteQuerySegmentedAsync(rangeQuery, null));
        }
    }

}
