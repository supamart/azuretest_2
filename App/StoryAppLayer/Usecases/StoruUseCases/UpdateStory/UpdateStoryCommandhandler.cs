using System.Threading;
using azuretest_2.App.StoryAppLayer.Dto;
using MediatR;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Gateway;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.UpdateStory
{
    public class UpdateStoryCommandhandler : IRequestHandler<UpdateStoryCommand, StoryDto>
    {
        private readonly IStoryRepoository _storyRepository;

        public UpdateStoryCommandhandler(IStoryRepoository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {
            var story = await _storyRepository.GetByIdAsync(request.Id);

            story.Text = request.Text;
            story.Images=request.Images;

            var updatedStory = await _storyRepository.UpdateAsync(story);

            return new StoryDto { Id = updatedStory.Id, Text = updatedStory.Text,Images=updatedStory.Images };
        }
    }
}