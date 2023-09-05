namespace Drona.AyushmanBharat.Cache
{
    public class CacheConnectionOptions
    {
        public string? ConnectionString { get; set; }
        public int TimeToLive { get; set; }
        public int ConnectRetry { get; set; }
        public int ReConnectRetry { get; set; }
    }
}
