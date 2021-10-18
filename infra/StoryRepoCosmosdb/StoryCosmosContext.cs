using azuretest_2.infra.Settings;
using Microsoft.Azure.Cosmos;

namespace azuretest_2.infra.StoryRepoCosmosdb
{
    public class StoryCosmosContext : IStoryCosmosContext
    {
        public StoryCosmosContext(CosmosSettings cosmossettings)
        {
            
            //For local emulator cosmosdb
            //string endpoint = "https://localhost:8081";
            //string key = "";

            //For azure protal cosmosdb (replace these values with your own)
           

            CosmosClient _client = new CosmosClient(cosmossettings.Endpoint,cosmossettings.Key);

            StoryContainer = _client.GetContainer(cosmossettings.DatabaseName, cosmossettings.StoryContainer);
        }
        public Container StoryContainer {get;}
    }
}