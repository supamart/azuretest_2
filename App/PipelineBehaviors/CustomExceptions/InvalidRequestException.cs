using System;
using System.Collections.Generic;

namespace azuretest_2.App.PipelineBehaviors.CustomExceptions
{public class InvalidRequestException : Exception
    {
        public List<string> Errors { get; }

        public InvalidRequestException(List<string> errors)
        {
            Errors = errors;
        }
    }
}