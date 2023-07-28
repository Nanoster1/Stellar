using Microsoft.Extensions.Logging;

namespace Stellar.IS.Application.Common.Logging.Events;

public static partial class LogEvents
{
    public static class Exceptions
    {
        public static class UnexpectedException
        {
            public const int Id = ((int)EventTypes.Exceptions) + 1;
            public const string Name = nameof(UnexpectedException);
            public static EventId EventId => new(Id, Name);
        }
    }
}