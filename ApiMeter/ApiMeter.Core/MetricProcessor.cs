using ApiMeter.Core.Domain;
using ApiMeter.Core.Providers.BufferProvider;
using System.Threading.Tasks;

namespace ApiMeter.Core
{
    public class MetricProcessor
    {
        public void WriteRequestResponse(RequestResponseData data)
        {
            RedisDataProvider dataProvider = new RedisDataProvider();
            dataProvider.Write(data);
        }
    }
}
