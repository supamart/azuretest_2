using System.Collections;
using System.Collections.Generic;
using azuretest_2.App.StoryAppLayer.Dto;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.GetStories
{
    public class GetStoriesQuery:IRequest<IEnumerable<StoryDto>>
    {
        
    }
}