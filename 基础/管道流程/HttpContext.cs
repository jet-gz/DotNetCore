using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace 管道流程
{
    public class HttpContext
    {
        public HttpContext(IFeatureCollection features)
        {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
        public  HttpRequest Request { get; }

        public  HttpResponse Response { get; }

    }

    public class HttpRequest
    {
        private readonly IHttpRequestFeature _feature;

        public HttpRequest(IFeatureCollection features)
        {
            _feature = features.Get<IHttpRequestFeature>();

        }

        public Uri Url => _feature.Url;

        public NameValueCollection Headers => _feature.Headers;

        public Stream Body => _feature.Body;


    }

    public class HttpResponse
    {
        private readonly IHttpResponseFeature _feature;

        public HttpResponse(IFeatureCollection features)
        {
            _feature = features.Get<IHttpResponseFeature>();

        }


        public int StatusCode { 
            get=>_feature.StatusCode;
            set=>_feature.StatusCode=value; 
        }

        public NameValueCollection Headers => _feature.Headers;

        public Stream Body => _feature.Body;


    }



}
