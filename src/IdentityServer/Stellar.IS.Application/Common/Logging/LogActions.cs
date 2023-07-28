using Microsoft.Extensions.Logging;
using Stellar.IS.Application.Common.Logging.Events;

namespace Stellar.IS.Application.Common.Logging;

public static partial class LogActions
{
    #region Exceptions

    [LoggerMessage(
        EventId = LogEvents.Exceptions.UnexpectedException.Id,
        EventName = LogEvents.Exceptions.UnexpectedException.Name,
        Level = LogLevel.Error)]
    public static partial void LogUnexpectedException(this ILogger logger, Exception exception);

    #endregion
}