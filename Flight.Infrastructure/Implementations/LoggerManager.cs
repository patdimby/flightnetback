using Flight.Infrastructure.Interfaces;
using NLog;

namespace Flight.Infrastructure.Implementations;
/// <summary>
/// The logger manager.
/// </summary>

public class LoggerManager : ILoggerManager
{
    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Logs the debug.
    /// </summary>
    /// <param name="message">The message.</param>
    public void LogDebug(string message)
    {
        _logger.Debug(message);
    }

    public void LogError(string message)
    {
        _logger.Error(message);
    }

    public void LogInfo(string message)
    {
        _logger.Info(message);
    }

    public void LogWarn(string message)
    {
        _logger.Warn(message);
    }
}