using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.Domain.StoryDomain.Entites;

namespace azuretest_2.infra
{
    public class MockRepo : IStoryRepoository
    {

        static List<Story> list = new List<Story>()
        {
            new Story{Id= Guid.NewGuid() , Text = "Neo"},
            new Story{Id= Guid.NewGuid(), Text = "Leoon"}
            
        };
        public Task<Story> AddAsync(Story story)
        {
            throw new NotImplementedException();
        }

        public Task<Story> RemoveAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Story>> GetAsync()
        {            
            return list;
        }

        public Task<Story> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Story> UpdateAsync(Story story)
        {
            throw new NotImplementedException();
        }
    }
}