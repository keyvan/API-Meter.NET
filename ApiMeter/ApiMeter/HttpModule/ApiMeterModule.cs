using ApiMeter.Domain;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Web;

namespace ApiMeter.HttpModule
{
    /// <summary>
    /// HttpModule to capture the incoming and outgoing traffic to an ASP.NET application.
    /// </summary>
    public class ApiMeterModule : IHttpModule
    {
        private Stopwatch _timer = new Stopwatch();
        private RequestResponseData _data = new RequestResponseData();

        public void Dispose()
        {
            this._timer = null;
            this._data = null;
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                HttpApplication application = sender as HttpApplication;
                this._data.ID = Guid.NewGuid();
                this._data.RequestURL = application.Request.RawUrl;
                this._data.RequestHost = application.Request.Url.Host;
                this._data.UserAgent = application.Request.UserAgent;
                this._data.IpAddress = application.Request.UserHostAddress;
                this._data.HttpRequestVerb = application.Request.RequestType;
                this._data.HttpHeaders = application.Request.Headers;
                this._data.RequestSize = application.Request.InputStream.Length;
                this._data.IsSecure = application.Request.IsSecureConnection;
                this._data.RequestStartedUtc = DateTime.UtcNow;
                this._timer.Start();
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            try
            {
                HttpApplication application = sender as HttpApplication;
                this._timer.Stop();
                this._data.ResponseEndedUtc = DateTime.UtcNow;
                this._data.HttpResponseStatusCode = application.Response.StatusCode;
                this._data.HttpResponseSubStatusCode = application.Response.SubStatusCode;
                this._data.ResponseSize = application.Response.OutputStream.Length;
                this._data.ProcessingTime = this._timer.ElapsedMilliseconds;
                MetricProcessor processor = new MetricProcessor();

                string configurationFilePath = application.Request.MapPath(ConfigurationManager.AppSettings["ApiMeterConfigurationFilePath"]);
                processor.WriteRequestResponse(configurationFilePath, this._data);
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
        }
    }
}
