using ApiMeter.Core.Domain;
using System.Threading.Tasks;

namespace ApiMeter.Core.Providers.BufferProvider
{
    /// <summary>
    /// Anbstract base class for buffer data provider to write raw request and response data into intermediate buffer
    /// </summary>
    public abstract class BufferDataProviderBase
    {
        public abstract Task Write(RequestResponseData data);
    }
}
