using ApiMeter.Configuration;
using ApiMeter.Domain;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ApiMeter.Providers.BufferProvider
{
    /// <summary>
    /// A Redis data provider to write raw metric data into 
    /// </summary>
    public class RedisBufferDataProvider : BufferDataProviderBase
    {
        private static RedisClient _client;

        public RedisBufferDataProvider(IApiMeterConfiguration configuration)
            : base(configuration)
        {
            _client = new RedisClient(base.configuration.RedisServerUrl, base.configuration.RedisServerPort);
            _client.ConnectTimeout = base.configuration.RedisConnectionTimeout;
            _client.SendTimeout = base.configuration.RedisSendTimeout;

        }

        /// <summary>
        /// Writes request and response raw data into Redis
        /// </summary>
        /// <param name="data">Request and response metrics in raw form</param>
        public override void Write(RequestResponseData data)
        {
            try
            {
                _client.Add<RequestResponseData>(data.ID.ToString(), data, TimeSpan.FromMinutes(base.configuration.RedisTimeToLive));
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }

        /// <summary>
        /// Gets all the available request and response data available on Redis
        /// </summary>
        /// <returns>A collection of available request and response data</returns>
        public override IList<RequestResponseData> GetAll()
        {
            try
            {
                return _client.GetAll<RequestResponseData>();
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Deletes a particular request and response data item from Redis
        /// </summary>
        /// <param name="data">Data to be deleted</param>
        public override void Delete(RequestResponseData data)
        {
            try
            {
                _client.Del(data.ID.ToString());
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }
    }
}
