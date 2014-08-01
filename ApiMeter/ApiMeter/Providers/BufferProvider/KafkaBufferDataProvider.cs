using ApiMeter.Configuration;
using ApiMeter.Domain;
using System;
using System.Collections.Generic;

namespace ApiMeter.Providers.BufferProvider
{
    /// <summary>
    /// A Kafka data provider to write raw metric data into 
    /// </summary>
    public class KafkaBufferDataProvider : BufferDataProviderBase
    {
        public KafkaBufferDataProvider(IApiMeterConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Sends request and response raw data to Kafka
        /// </summary>
        /// <param name="data">Request and response metrics in raw form</param>
        public override void Write(RequestResponseData data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the available request and response data available from Kafka
        /// </summary>
        /// <returns>A collection of available request and response data</returns>
        public override IList<RequestResponseData> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a particular request and response data item from Kafka
        /// </summary>
        /// <param name="data">Data to be deleted</param>
        public override async void Delete(RequestResponseData data)
        {
            throw new NotImplementedException();
        }
    }
}
