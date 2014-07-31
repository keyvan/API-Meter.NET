using ApiMeter.Core.Domain;
using System;
using System.Threading.Tasks;

namespace ApiMeter.Core.Providers.BufferProvider
{
    /// <summary>
    /// A Redis data provider to write raw metric data into 
    /// </summary>
    public class RedisDataProvider : BufferDataProviderBase
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
                client.Add<RequestResponseData>(data.ID.ToString(), data, TimeSpan.FromMinutes(15));
            }
            catch (Exception ex)
            {
                // We need to handle these exceptions
            }
        }
    }
}
