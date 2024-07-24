using Serilog.Core;
using Serilog.Events;

namespace KormosalaWebApi.KormosalaWebApi.Configurations.ColumnWriters
{
    public class CustomUserNameColumn : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var (userName, value) = logEvent.Properties.FirstOrDefault(x => x.Key == "UserName");
            if (value is not null)
            {
                var getValue = propertyFactory.CreateProperty(userName, value);
                logEvent.AddPropertyIfAbsent(getValue);
            }
        }
    }
}
