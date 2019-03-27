using System;

namespace $safeprojectname$.Helpers
{
    public class FmiException: Exception
    {
        public string Body { get; }

        public FmiException(string message, string body = null) : base(message)
        {
            Body = body;
        }
    }
}