using System;
using System.Collections.Generic;

namespace Model.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(string message) : base(message)
        {
            Title = message;
        }

        public CustomValidationException(string message, long status, string traceId) : base(message)
        {
            Title = message;
            Status = status;
            TraceId = traceId;
        }

        public CustomValidationException(Dictionary<string, string[]> errors)
        {
            Title = "One or more validation errors occurred.";
            Errors = errors;
        }

        public Uri Type { get; } = new("https://tools.ietf.org/html/rfc7231#section-6.5.1");

        public string Title { get; }
        public long Status { get; set; }
        public string TraceId { get; set; }

        public Dictionary<string, string[]> Errors { get; }


        public CustomValidationProblemDetails ToProblemDetails()
        {
            var problemDetails = new CustomValidationProblemDetails
            {
                Type = Type,
                Title = Title,
                Status = Status,
                TraceId = TraceId,
                Errors = Errors
            };

            return problemDetails;
        }
    }
}