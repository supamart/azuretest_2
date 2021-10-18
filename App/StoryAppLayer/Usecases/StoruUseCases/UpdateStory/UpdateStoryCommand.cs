using System;
using azuretest_2.App.StoryAppLayer.Dto;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.UpdateStory
{
    public class UpdateStoryCommand:IRequest<StoryDto>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public string[] Images { get; set; }
    }
}