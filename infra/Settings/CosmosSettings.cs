namespace azuretest_2.infra.Settings
{
    public class CosmosSettings
    {
        public const string SettingName = "CosmosSettings";

        public string Endpoint { get; set; }
        public string Key { get; set; }
        public string DatabaseName { get; set; }
        public string StoryContainer { get; set; }
    }
}