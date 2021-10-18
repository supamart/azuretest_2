using System;
using azuretest_2.App.StoryAppLayer.Dto;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.CreateStory
{
    public class CreateStoryCommand:IRequest<StoryDto>
    {       
        public string Text { get; set; }
        public string[] Images { get; set; }
    }
}