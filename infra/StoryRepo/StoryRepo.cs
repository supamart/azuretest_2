using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.Domain.StoryDomain.Entites;

namespace azuretest_2.infra.StoryRepo
{
    public class StoryRepo : IStoryRepoository
    {
        public Task<Story> AddAsync(Story story)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Story>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Story> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Story> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Story> UpdateAsync(Story story)
        {
            throw new NotImplementedException();
        }
    }
}