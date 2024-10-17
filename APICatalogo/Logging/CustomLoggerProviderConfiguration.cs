namespace APICatalogo.Logging
{
    //LogLevel: Define o nível mínimo de log a ser registrado, com o padrão LogLevel.Warning
    //EventId: Define o Id do evento de log, com o padrão sendo 0
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;   
    }
}
