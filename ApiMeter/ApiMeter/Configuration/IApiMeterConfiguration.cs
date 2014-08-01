
namespace ApiMeter.Configuration
{
    /// <summary>
    /// Interface for configuration and settings
    /// </summary>
    public interface IApiMeterConfiguration
    {
        /// <summary>
        /// Timeout interval for connecting to Redis buffer storage
        /// </summary>
        int RedisConnectionTimeout { get; set; }

        /// <summary>
        /// Timeout interval for sending data to Redis buffer storage
        /// </summary>
        int RedisSendTimeout { get; set; }

        /// <summary>
        /// The maximum time in minutes that data can survive on Redis buffer storage
        /// </summary>
        int RedisTimeToLive { get; set; }

        /// <summary>
        /// The URL to Redis server
        /// </summary>
        string RedisServerUrl { get; set; }

        /// <summary>
        /// Port for Redis server
        /// </summary>
        int RedisServerPort { get; set; }
    }
}
