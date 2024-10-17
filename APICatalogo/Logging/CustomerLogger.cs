
namespace APICatalogo.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string LoggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
        {
            LoggerName = name;
            loggerConfig = config;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= loggerConfig.LogLevel;
        }

        public IDisposable? BeginScope<TState>(TState tstate)
        {
            return null;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagens = $"{logLevel.ToString()} - {eventId.Id} - {formatter(state, exception)}";
            EscreverTextoNoArquivo(mensagens);
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivoLog = @"C:\Users\barbara.gianvechio\Documents\dados\logAPI.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
