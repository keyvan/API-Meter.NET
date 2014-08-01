using ApiMeter.Configuration;
using ApiMeter.Core.Tests.Utilities;
using ApiMeter.Domain;
using ApiMeter.Providers.BufferProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ApiMeter.Core.Tests.Providers.BufferProvider
{
    [TestClass]
    public class RedisBufferDataProviderTests
    {
        private IApiMeterConfiguration configuration;
        private RequestResponseData data;

        [TestInitialize]
        public void LoadConfiguration()
        {
            Mock<IApiMeterConfiguration> configMock = new Moq.Mock<IApiMeterConfiguration>();
            configMock.SetupProperty(d => d.RedisServerUrl, "localhost");
            configMock.SetupProperty(d => d.RedisServerPort, 6379);
            configMock.SetupProperty(d => d.RedisConnectionTimeout, 1000);
            configMock.SetupProperty(d => d.RedisSendTimeout, 500);
            configMock.SetupProperty(d => d.RedisTimeToLive, 30);

            configuration = configMock.Object;

            data = RequestResponseDataGenerator.GetSample();
        }

        [TestMethod]
        public void WriteToRedis()
        {
            RedisBufferDataProvider provider = new RedisBufferDataProvider(configuration);
            provider.Write(data);
        }

        [TestMethod]
        public void GetAllRedisObjects()
        {
            RedisBufferDataProvider provider = new RedisBufferDataProvider(configuration);
            List<RequestResponseData> actualData = provider.GetAll().ToList();
            Assert.AreEqual(1, actualData.Count);
            Assert.AreEqual(data.ID, actualData[0].ID);
        }

        [TestMethod]
        public void DeleteRedisObject()
        {
            RedisBufferDataProvider provider = new RedisBufferDataProvider(configuration);
            provider.Delete(this.data);
        }
    }
}


