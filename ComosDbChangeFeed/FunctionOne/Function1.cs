using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionOne
{
    public static class Functions
    {
        [FunctionName("FunctionOne")]
        public static void RunOne([CosmosDBTrigger(
            databaseName: "changefeeddatabase",
            collectionName: "changefeed",
            ConnectionStringSetting = "CosmosDbConnectionString",
            LeaseCollectionName = "leases",
            LeaseCollectionPrefix = "leaseOne",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> input,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation($"I am in FunctionOne: {input[0].Id}");
            }
        }

        [FunctionName("FunctionTwo")]
        public static void RunTwo([CosmosDBTrigger(
            databaseName: "changefeeddatabase",
            collectionName: "changefeed",
            ConnectionStringSetting = "CosmosDbConnectionString",
            LeaseCollectionName = "leases",
            LeaseCollectionPrefix = "leaseTwo",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> input,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation($"I am in FunctionTwo: {input[0].Id}");
            }
        }
    }
}
