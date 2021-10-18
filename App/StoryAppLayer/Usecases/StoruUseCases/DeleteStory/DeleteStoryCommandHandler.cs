using System.Threading;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Dto;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.Domain.StoryDomain.Entites;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.DeleteStory
{
    public class DeleteStoryCommandHandler : IRequestHandler<DeleteStoryCommand, StoryDto>
    {
       
        private readonly IStoryRepoository _storyRepository;

        public DeleteStoryCommandHandler(IStoryRepoository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var deletedStory = await _storyRepository.RemoveAsync(request.Id);

            if(deletedStory == null)
            {
                return null;
            }

            var storyDto = new StoryDto { Id = deletedStory.Id, Text = deletedStory.Text, Images=deletedStory.Images };

            return storyDto;
        }
    }
}