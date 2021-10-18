using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Dto;
using azuretest_2.App.StoryAppLayer.Gateway;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.GetStories
{
    public class GetStoriesQueryHandler : IRequestHandler<GetStoriesQuery, IEnumerable<StoryDto>>
    {
        private readonly IStoryRepoository _storyRepository;

        public GetStoriesQueryHandler(IStoryRepoository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<IEnumerable<StoryDto>> Handle(GetStoriesQuery request, CancellationToken cancellationToken)
        {
            var stories = await _storyRepository.GetAsync();

            var storiesDto = stories.Select(x => new StoryDto { Id = x.Id, Text = x.Text , Images = x.Images});

            return storiesDto;
        }
    }
}