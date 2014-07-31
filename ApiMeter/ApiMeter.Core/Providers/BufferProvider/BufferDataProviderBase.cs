using ApiMeter.Core.Domain;
using System.Threading.Tasks;

namespace ApiMeter.Core.Providers.BufferProvider
{
    public abstract class BufferDataProviderBase
    {
        public abstract Task Write(RequestResponseData data);
    }
}
