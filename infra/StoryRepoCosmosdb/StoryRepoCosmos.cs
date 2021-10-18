using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.Domain.StoryDomain.Entites;
using Microsoft.Azure.Cosmos;

namespace azuretest_2.infra.StoryRepoCosmosdb
{
    public class StoryRepoCosmos : IStoryRepoository
    {
        private readonly IStoryCosmosContext _cosmosContext;

        public StoryRepoCosmos(IStoryCosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext;
        }

        public async Task<Story> AddAsync(Story story)
        {
            var partitionKey = new PartitionKey(story.Id.ToString());
            var result = await _cosmosContext.StoryContainer.CreateItemAsync(story, partitionKey);
            return result.Resource;
        }

        public async Task<IEnumerable<Story>> GetAsync()
        {
            var queryDefination = new QueryDefinition("SELECT * FROM Story");
            var query = _cosmosContext.StoryContainer.GetItemQueryIterator<Story>(queryDefination);
            
            var result = new List<Story>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.ToList());
            }

            return result;
        }

        public async Task<Story> GetByIdAsync(Guid id)
        {
            try
            {
                var partitionKey = new PartitionKey(id.ToString());
                var result = await _cosmosContext.StoryContainer.ReadItemAsync<Story>(id.ToString(), partitionKey);
                return result.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Story> RemoveAsync(Guid id)
        {
            var recordToDelete = await GetByIdAsync(id);  //This is not requred if you dont want to return recod from Remove method
            if(recordToDelete == null)
            {
                return null;
            }
            var partitionKey = new PartitionKey(id.ToString());
            var result = await _cosmosContext.StoryContainer.DeleteItemAsync<Story>(id.ToString(), partitionKey);
            return recordToDelete;
        }

        public async Task<Story> UpdateAsync(Story story)
        {
            var partitionKey = new PartitionKey(story.Id.ToString());
            var result = await _cosmosContext.StoryContainer.UpsertItemAsync(story, partitionKey);
            return result.Resource;
        }
    }
}