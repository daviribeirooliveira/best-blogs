using System;
using System.Collections.Generic;

namespace Model.Exceptions
{
    public class CustomValidationProblemDetails
    {
        public Uri Type { get; set; } = new("https://tools.ietf.org/html/rfc7231#section-6.5.1");
        public string Title { get; set; }
        public long Status { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }
}