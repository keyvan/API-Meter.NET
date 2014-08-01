using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace ApiMeter.Domain
{
    /// <summary>
    /// The domain representative of raw request and response data and metrics
    /// </summary>
    [Serializable]
    public class RequestResponseData
    {
        /// <summary>
        /// A random GUID given to each request and response pair for identification by API-Meter.NET
        /// </summary>
        [Required]
        public Guid ID { get; set; }

        /// <summary>
        /// Raw request URL
        /// </summary>
        [Required]
        public string RequestURL { get; set; }

        /// <summary>
        /// Request's host address
        /// </summary>
        [Required]
        public string RequestHost { get; set; }

        /// <summary>
        /// HTTP verb used for request
        /// </summary>
        [Required]
        public string HttpRequestVerb { get; set; }

        /// <summary>
        /// User agent of request
        /// </summary>
        [Required]
        public string UserAgent { get; set; }

        /// <summary>
        /// IP address of request/client
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Name value pairs of HTTP headers of request
        /// </summary>
        public NameValueCollection HttpHeaders { get; set; }

        /// <summary>
        /// Major HTTP status code for response
        /// </summary>
        [Required]
        public int HttpResponseStatusCode { get; set; }

        /// <summary>
        /// Minor HTTP status code for response
        /// </summary>
        [Required]
        public int HttpResponseSubStatusCode { get; set; }

        /// <summary>
        /// Size of request stream
        /// </summary>
        public long RequestSize { get; set; }

        /// <summary>
        /// Size of response stream
        /// </summary>
        public long ResponseSize { get; set; }

        /// <summary>
        /// Determines if request is on a secure layer
        /// </summary>
        public bool IsSecure { get; set; }

        /// <summary>
        /// Total miliseconds from the beginning of request to the end of response
        /// </summary>
        [Required]
        public long ProcessingTime { get; set; }

        /// <summary>
        /// Start date and time of request in UTC
        /// </summary>
        [Required]
        public DateTime RequestStartedUtc { get; set; }

        /// <summary>
        /// End date and time of response in UTC
        /// </summary>
        [Required]
        public DateTime ResponseEndedUtc { get; set; }
    }
}
