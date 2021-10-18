using System;
using azuretest_2.App.StoryAppLayer.Dto;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.DeleteStory
{
    public class DeleteStoryCommand:IRequest<StoryDto>
    {
        public Guid Id { get; set; }
    }
}