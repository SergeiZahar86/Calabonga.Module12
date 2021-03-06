using System;

namespace Calabonga.Module12.Core.Exceptions
{
    /// <summary>
    /// Represent Price Point Exception
    /// </summary>
    public class MicroserviceInvalidOperationException : Exception
    {
        public MicroserviceInvalidOperationException() : base(AppData.Exceptions.InvalidOperationException)
        {

        }

        public MicroserviceInvalidOperationException(string message) : base(message)
        {

        }

        public MicroserviceInvalidOperationException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
