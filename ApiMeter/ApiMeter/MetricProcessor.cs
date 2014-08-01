using ApiMeter.Configuration;
using ApiMeter.Domain;
using ApiMeter.Providers.BufferProvider;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiMeter
{
    public class MetricProcessor
    {
        public void WriteRequestResponse(string configurationFilePath, RequestResponseData data)
        {
            RedisBufferDataProvider dataProvider = new RedisBufferDataProvider(new ApiMeterConfiguration(configurationFilePath));
            dataProvider.Write(data);
        }

        public void WriteRequestResponse(IApiMeterConfiguration apiConfiguration, RequestResponseData data)
        {
            RedisBufferDataProvider dataProvider = new RedisBufferDataProvider(apiConfiguration);
            dataProvider.Write(data);
        }

        private void ValidateData(RequestResponseData data)
        {
            

        }
    }
}
