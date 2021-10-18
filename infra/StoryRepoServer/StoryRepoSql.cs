using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.Domain.StoryDomain.Entites;
using Microsoft.EntityFrameworkCore;


//Add-Migration FirstCreate --- Migration Folder is created Have Up & Down Method
//update-databasde ---- To Run ad create table in database

namespace azuretest_2.infra.StoryRepoServer
{
    public class StoryRepoSql : IStoryRepoository
    {
        private readonly StoryRepoDbcontext _storyDbContext;
        public StoryRepoSql(StoryRepoDbcontext storyDbContext)
        {
            _storyDbContext = storyDbContext;
        }

        public async Task<Story> AddAsync(Story story)
        {
            await _storyDbContext.AddAsync(story);
            await _storyDbContext.SaveChangesAsync();
            return story;
        }

        public async Task<Story> RemoveAsync(Guid Id)
        {
             var storyToRemove = await GetByIdAsync(Id);
            _storyDbContext.Story.Remove(storyToRemove);
            await _storyDbContext.SaveChangesAsync();
            return storyToRemove;
        }

        public async Task<IEnumerable<Story>> GetAsync()
        {
            return await _storyDbContext.Story.ToListAsync();
        }

        public async Task<Story> GetByIdAsync(Guid Id)
        {
            return await _storyDbContext.Story.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Story> UpdateAsync(Story story)
        {
            _storyDbContext.Update(story);
            await _storyDbContext.SaveChangesAsync();
            return story;
        }
    }
}