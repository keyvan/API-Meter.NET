using ApiMeter.Configuration;
using ApiMeter.Domain;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ApiMeter.Providers.BufferProvider
{
    /// <summary>
    /// A Redis data provider to write raw metric data into 
    /// </summary>
    public class RedisBufferDataProvider : BufferDataProviderBase
    {
        public RedisBufferDataProvider(IApiMeterConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Writes request and response raw data into Redis
        /// </summary>
        /// <param name="data">Request and response metrics in raw form</param>
        /// <returns>A completed task</returns>
        public override async Task Write(RequestResponseData data)
        {
            try
            {
                ServiceStack.Redis.RedisClient client = new ServiceStack.Redis.RedisClient();
                client.ConnectTimeout = base.configuration.RedisConnectionTimeout;
                client.SendTimeout = base.configuration.RedisSendTimeout;
                client.Add<RequestResponseData>(data.ID.ToString(), data, TimeSpan.FromMinutes(base.configuration.RedisTimeToLive));
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }
    }
}
