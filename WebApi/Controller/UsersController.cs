using System.Threading.Tasks;
using azuretest_2.App.AccApplayer.Usecases.UserUsecases.GetId;
using azuretest_2.WebApi.Controller.seed;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace azuretest_2.WebApi.Controller
{
    
    public class UsersController:SharedController
    {        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskAsync([FromRoute] int id)
        {
            var request = new GetIdRequest {Id = id};
            var user = await Mediator.Send(request);
            return Ok(user);
            
        }
    }
}