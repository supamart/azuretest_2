using Azure.Storage.Blobs;
using azuretest_2.App.CommonAppLayer.Interfaces;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.infra.Settings;
using azuretest_2.infra.StoryRepoCosmosdb;
using azuretest_2.infra.StoryRepoServer;
using azuretest_2.infra.ThirdPartyServices.AzureServices;
using azuretest_2.infra.ThirdPartyServices.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace azuretest_2.infra
{
    public static class DependencyInjection
    {
          public static IServiceCollection AddSqlRepository(this IServiceCollection services)
        {
            services.AddScoped<StoryRepoDbcontext>();
            services.AddScoped<IStoryRepoository,StoryRepoSql>();
            return services;
        }

         public static IServiceCollection AddCosmosRepository(this IServiceCollection services,IConfiguration configuration)
        {
             var cosmosSettings = new CosmosSettings();
            configuration.GetSection(CosmosSettings.SettingName).Bind(cosmosSettings);
            services.AddSingleton(cosmosSettings);

            services.AddSingleton<IStoryCosmosContext, StoryCosmosContext>();

            services.AddScoped<IStoryRepoository, StoryRepoCosmos>();

            return services;
        }

         public static IServiceCollection AddMockRepository(this IServiceCollection services)
        {
            services.AddScoped<IStoryRepoository,MockRepo>();

            return services;
        }

         public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, IConfiguration configuration)
        {
            var blobStorageSettings = new BlobStorageSettings();
            configuration.GetSection(BlobStorageSettings.SettingName).Bind(blobStorageSettings);

            services.AddSingleton(x => new BlobServiceClient(blobStorageSettings.ConnectionString));

            services.AddScoped<IFileStorageService, BlobStorageService>();

            return services;
        }
        /*  "BlobStorageSettings": {
             "ConnectionString": "DefaultEndpointsProtocol=https;AccountName=storyrepo;AccountKey=aaMRZ5I7pXAr/WSSRZdKtRatezFEaInybF9FO4Hs8uItQlYSg+BZGWNkMTGP6gHuClySGg6xRPZivImYYAfwUg==;EndpointSuffix=core.windows.net"
        },*/
    }
}