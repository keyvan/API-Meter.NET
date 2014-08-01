using ApiMeter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMeter.Core.Tests.Utilities
{
    internal static class RequestResponseDataGenerator
    {
        public static RequestResponseData GetSample()
        {
            RequestResponseData data = new RequestResponseData();
            data.ID = Guid.NewGuid();
            data.UserAgent = "Test";

            return data;
        }
    }
}
