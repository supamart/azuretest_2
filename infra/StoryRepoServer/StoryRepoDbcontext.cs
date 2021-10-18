using azuretest_2.Domain.StoryDomain.Entites;
using Microsoft.EntityFrameworkCore;

namespace azuretest_2.infra.StoryRepoServer
{
    public class StoryRepoDbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Story> Story {get;set;}
    }
}