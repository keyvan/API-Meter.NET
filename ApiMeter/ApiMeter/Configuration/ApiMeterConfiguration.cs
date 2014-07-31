using System;

namespace ApiMeter.Configuration
{
    /// <summary>
    /// Default implementation of configuration interface
    /// </summary>
    internal class ApiMeterConfiguration : IApiMeterConfiguration
    {
        private string _configurationFilePath;

        public ApiMeterConfiguration(string configurationFilePath)
        {
            this._configurationFilePath = configurationFilePath;
        }

        /// <summary>
        /// Timeout interval for connecting to Redis buffer storage
        /// </summary>
        public int RedisConnectionTimeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Timeout interval for sending data to Redis buffer storage
        /// </summary>
        public int RedisSendTimeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The maximum time in minutes that data can survive on Redis buffer storage
        /// </summary>
        public int RedisTimeToLive
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The URL to Redis server
        /// </summary>
        public string RedisServerUrl
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The interval at which data aggregator service executes (in seconds)
        /// </summary>
        public int ServiceExecutionInterval
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
