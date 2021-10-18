using System;
using azuretest_2.App.StoryAppLayer.Dto;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.GetStoryById
{
    public class GetStoryByIdQuery:IRequest<StoryDto>
    {
        public Guid Id { get; set; }
                
    }
}