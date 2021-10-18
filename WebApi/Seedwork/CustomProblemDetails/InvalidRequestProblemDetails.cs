using System.Collections.Generic;
using azuretest_2.App.PipelineBehaviors.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace azuretest_2.WebApi.Seedwork.CustomProblemDetails
{  public class InvalidRequestProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; }

        public InvalidRequestProblemDetails(InvalidRequestException exception, string traceId)
        {
            Title = "Request validation error";
            Status = StatusCodes.Status400BadRequest;
            Type = "https://httpstatuses.com/400";
            Errors = exception.Errors;
            Instance = traceId;
        }
    }
}