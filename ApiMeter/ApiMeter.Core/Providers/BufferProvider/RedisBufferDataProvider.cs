using ApiMeter.Core.Domain;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ApiMeter.Core.Providers.BufferProvider
{
    /// <summary>
    /// A Redis data provider to write raw metric data into 
    /// </summary>
    public class RedisBufferDataProvider : BufferDataProviderBase
    {
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
                client.ConnectTimeout = 3;
                client.SendTimeout = 3;
                client.Add<RequestResponseData>(data.ID.ToString(), data, TimeSpan.FromMinutes(30));
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }
    }
}
