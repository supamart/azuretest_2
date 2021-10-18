using System.Threading;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Dto;
using azuretest_2.App.StoryAppLayer.Gateway;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.GetStoryById
{
    public class GetStoryByIdQueryHandler : IRequestHandler<GetStoryByIdQuery, StoryDto>
    {
        private readonly IStoryRepoository _storyRepository;

        public GetStoryByIdQueryHandler(IStoryRepoository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(GetStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var story = await _storyRepository.GetByIdAsync(request.Id);

            if(story == null)
            {
                return null;
            }

            var storyDto = new StoryDto { Id = story.Id, Text = story.Text,Images=story.Images };

            return storyDto;
        }
    }
}