using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using azuretest_2.Domain.StoryDomain.Entites;

namespace azuretest_2.App.StoryAppLayer.Gateway
{
    public interface IStoryRepoository
    { 
        Task<IEnumerable<Story>> GetAsync();
        Task<Story> GetByIdAsync(Guid id);
        Task<Story> AddAsync(Story story);
        Task<Story> UpdateAsync(Story story);
        Task<Story> RemoveAsync(Guid id);

    }
}