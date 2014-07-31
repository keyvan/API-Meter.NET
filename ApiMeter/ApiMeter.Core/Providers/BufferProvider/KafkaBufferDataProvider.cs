using ApiMeter.Core.Domain;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ApiMeter.Core.Providers.BufferProvider
{
    /// <summary>
    /// A Kafka data provider to write raw metric data into 
    /// </summary>
    public class KafkaBufferDataProvider : BufferDataProviderBase
    {
        /// <summary>
        /// Sends request and response raw data to Kafka
        /// </summary>
        /// <param name="data">Request and response metrics in raw form</param>
        /// <returns>A completed task</returns>
        public override async Task Write(RequestResponseData data)
        {
            try
            {
                KafkaOptions options = new KafkaOptions(new Uri("http://SERVER1:9092"), new Uri("http://SERVER2:9092"));
                BrokerRouter router = new BrokerRouter(options);
                Producer client = new Producer(router);

                client.SendMessageAsync("API-Meter Data", new[] { new Message { Value = "NULL for now" } }).Wait();
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }
    }
}
