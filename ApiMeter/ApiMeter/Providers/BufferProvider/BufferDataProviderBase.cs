using ApiMeter.Configuration;
using ApiMeter.Domain;
using System.Threading.Tasks;

namespace ApiMeter.Providers.BufferProvider
{
    /// <summary>
    /// Anbstract base class for buffer data provider to write raw request and response data into intermediate buffer
    /// </summary>
    public abstract class BufferDataProviderBase
    {
        protected IApiMeterConfiguration configuration;

        /// <summary>
        /// Public default constructor to initiate a buffer data provider with specified configuration
        /// </summary>
        /// <param name="configuration"></param>
        public BufferDataProviderBase(IApiMeterConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Writes request and response raw data to a buffer data storage
        /// </summary>
        /// <param name="data">Data to be stored</param>
        /// <returns>A completed task</returns>
        public abstract Task Write(RequestResponseData data);
    }
}
