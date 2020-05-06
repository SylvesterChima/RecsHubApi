using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecsHub.Messages;

namespace RecsHub.Helpers
{
    public class ExceptionLoggingMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly IMessageService _messageService;
        private readonly RequestDelegate _next;

        public ExceptionLoggingMiddleware(RequestDelegate next, IHostEnvironment env, IMessageService messageService)
        {
            _env = env;
            _messageService = messageService;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await _messageService.SendExceptionEmailAsync(e, context);
            }
        }
    }
}
