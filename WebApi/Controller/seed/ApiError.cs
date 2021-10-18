using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace azuretest_2.WebApi.Controller.seed
{
    public static class ApiError
    {
        public static NotFoundObjectResult RecordNotFound
        {
            get
            {
                var problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Type = "https://httpstatuses.com/404",
                    Title = "Record not found",
                    Detail = "No record exist in database with specified Id. Please try again using valid Id",
                };

                return new NotFoundObjectResult(problemDetails);
            }
        }
    }
}