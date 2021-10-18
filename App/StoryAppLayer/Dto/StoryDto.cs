using System;

namespace azuretest_2.App.StoryAppLayer.Dto
{
    public class StoryDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string[] Images { get; set; }
    }
}