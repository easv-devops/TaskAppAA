using Serilog;

namespace monitoring;

public class MonitorService
{
    public ILogger Log => Serilog.Log.Logger;

    static MonitorService()

    {
        Serilog.Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .WriteTo.Seq("http://5.189.171.183:5341")
            .CreateLogger();
    }
}