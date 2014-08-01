using ApiMeter.Configuration;
using ApiMeter.Domain;
using System.Collections.Generic;
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
        public abstract void Write(RequestResponseData data);

        /// <summary>
        /// Gets all the available request and response data available on buffer data storage
        /// </summary>
        /// <returns>A collection of available request and response data</returns>
        public abstract IList<RequestResponseData> GetAll();

        /// <summary>
        /// Deletes a particular request and response data item from buffer data storage
        /// </summary>
        /// <param name="data">Data to be deleted</param>
        public abstract void Delete(RequestResponseData data);
    }
}
