using Microsoft.ApplicationInsights.Extensibility;
using Serilog;

namespace Drona.AyushmanBharat.API.Factories
{
    public class LoggerConfigurationFactory
    {
        public static Serilog.ILogger CreateLogger()
        {
            // Application Insights configuration
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            //todo : read it from configuration
            configuration.ConnectionString = "InstrumentationKey=6caccfba-cbae-4c27-9314-fda3ab468b00;IngestionEndpoint=https://centralindia-0.in.applicationinsights.azure.com/;LiveEndpoint=https://centralindia.livediagnostics.monitor.azure.com/"; // Replace with your actual Instrumentation Key

            // Serilog configuration
            return new LoggerConfiguration()
                .WriteTo.ApplicationInsights(configuration, TelemetryConverter.Events)
                .CreateLogger();
        }
    }
}
