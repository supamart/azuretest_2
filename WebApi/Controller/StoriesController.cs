using System;
using System.Threading.Tasks;
using azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.CreateStory;
using azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.DeleteStory;
using azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.GetStories;
using azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.GetStoryById;
using azuretest_2.App.StoryAppLayer.Usecases.StoruUseCases.UpdateStory;
using azuretest_2.WebApi.Controller.seed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace azuretest_2.WebApi.Controller
{
    public class StoriesController:SharedController
    {
        private readonly ILogger _logger;
        public StoriesController(ILogger<StoriesController> logger)
        {
            _logger = logger;
            _logger.LogInformation("The Main Controller Has started..");
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetStoriesQuery query)
        {
            var stories = await Mediator.Send(query);
            return Ok(stories);
        }

        [HttpGet("{id}")] //stories/id
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var story = await Mediator.Send(new GetStoryByIdQuery { Id = id });

            if(story == null)
            {
                return ApiError.RecordNotFound;
            }

            return Ok(story);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStoryCommand command)
        {
            var story = await Mediator.Send(command);
            return CreatedAtAction("Get", new { id = story.Id }, story);
        }

        [HttpPut("{id}")]//stories/id
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateStoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var story = await Mediator.Send(command);
            return Ok(story);
        }

        [HttpDelete("{id}")]//stories/id
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var story = await Mediator.Send(new DeleteStoryCommand { Id = id });

             if(story == null)
            {
                return ApiError.RecordNotFound;
            }

            return Ok(story);
        }
        
    }
}