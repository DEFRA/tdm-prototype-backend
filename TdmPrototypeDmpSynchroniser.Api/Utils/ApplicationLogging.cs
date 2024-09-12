namespace TdmPrototypeDmpSynchroniser.Api.Utils;

public static class ApplicationLogging
{
    private static ILoggerFactory _loggerFactory;
    
    public static ILoggerFactory LoggerFactory
    {
        get { return _loggerFactory; }
        set
        {
            _loggerFactory = value;
            TdmPrototypeDmpSynchroniser.Api.Utils.ApplicationLogging.LoggerFactory = value;
        }
    }

    public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();        
    public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
}