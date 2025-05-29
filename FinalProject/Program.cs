using Views;
using log4net;
using log4net.Config;
using System.Reflection;
class Program
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Program));
    static void Main()
    {
        new ConsoleView().Start();
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        log.Info("Application started");
    }
}

