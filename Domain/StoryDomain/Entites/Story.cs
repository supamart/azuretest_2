using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace azuretest_2.Domain.StoryDomain.Entites
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Story
    {
      //  [JsonProperty("id")]
        public Guid Id { get; set; }
        public string Text { get; set; }

        public string[] Images {get;set;}
    }
}