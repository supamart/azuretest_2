using FluentValidation;

namespace azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.CreateStory
{
    
    public class CreateStoryCommandValidator : AbstractValidator<CreateStoryCommand>
    {
        public CreateStoryCommandValidator()
        {
            RuleFor(v => v.Text).NotNull().NotEmpty();
        }
    }
}