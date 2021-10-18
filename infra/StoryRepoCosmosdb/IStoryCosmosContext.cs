using Microsoft.Azure.Cosmos;

namespace azuretest_2.infra.StoryRepoCosmosdb
{
    public interface IStoryCosmosContext
    {
        Container StoryContainer{get;}
    }
}