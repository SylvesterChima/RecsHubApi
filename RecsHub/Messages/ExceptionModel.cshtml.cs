using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RecsHub.Messages
{
    public class ExceptionModel
    {
        public ExceptionModel(Exception e, HttpContext context)
        {
            var trace = new StackTrace(e, true);
            Frames = trace.GetFrames();
            ExceptionData = e.Data;
            Headers = context.Request.Headers;
            HelpLink = e.HelpLink;
            HResult = e.HResult;
            InnerException = e.InnerException?.Message ?? string.Empty;
            Message = e.Message;
            Source = e.Source;
            StackTrace = e.StackTrace;
            TargetSite = e.TargetSite.ToString();
            Time = $"{DateTime.Now.ToLongDateString()} at {DateTime.Now.ToLongTimeString()}";
            Type = e.GetBaseException().GetType().FullName;
            Url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
        }

        public IDictionary ExceptionData { get; set; }
        public StackFrame[] Frames { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public string HelpLink { get; set; }
        public int HResult { get; set; }
        public string InnerException { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string TargetSite { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string User { get; set; }

    }
}
