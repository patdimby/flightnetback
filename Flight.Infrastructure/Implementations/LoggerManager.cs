using Flight.Infrastructure.Interfaces;
using NLog;

namespace Flight.Infrastructure.Implementations;

/// <summary>
/// The logger manager.
/// </summary>
public class LoggerManager : ILoggerManager
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Logs the debug.
    /// </summary>
    /// <param name="message">The message.</param>
    public void LogDebug(string message)
    {
        Logger.Debug(message);
    }

    public void LogError(string message)
    {
        Logger.Error(message);
    }

    public void LogInfo(string message)
    {
        Logger.Info(message);
    }

    public void LogWarn(string message)
    {
        Logger.Warn(message);
    }
}