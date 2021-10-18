using System;
using System.Threading;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Dto;
using azuretest_2.App.StoryAppLayer.Gateway;
using azuretest_2.Domain.StoryDomain.Entites;
using MediatR;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.CreateStory
{
      public class CreateStoryCommandHandler : IRequestHandler<CreateStoryCommand, StoryDto>
    {
        private readonly IStoryRepoository _storyRepository;

        public CreateStoryCommandHandler(IStoryRepoository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var story = new Story
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                Images= request.Images
            };

            var newStory = await _storyRepository.AddAsync(story);

            var storyDto = new StoryDto
            {
                Id = newStory.Id,
                Text = newStory.Text,
                Images= newStory.Images
            };

            return storyDto;
        }
    }
}

/* private readonly IStoryRepository _storyRepository;

        public CreateStoryCommandHandler(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<StoryDto> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var story = new Story
            {
                Id = Guid.NewGuid(),
                Text = request.Text
            };

            var newStory = await _storyRepository.AddAsync(story);

            var storyDto = new StoryDto
            {
                Id = newStory.Id,
                Text = newStory.Text
            };

            return storyDto;
            
*/
