using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecsHub.Helpers;

namespace RecsHub.Controllers
{
    public abstract class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private ILogger<T> logger;
        private IImageHelper imageHelper;
        private IActionContextAccessor accessor;
        private IHttpContextAccessor ca;
        private IMapper mapper;

        protected ILogger<T> _Logger => logger ?? (logger = HttpContext?.RequestServices.GetService<ILogger<T>>());
        protected IImageHelper _imageHelper => imageHelper ?? (imageHelper = HttpContext?.RequestServices.GetService<IImageHelper>());
        protected IActionContextAccessor _accessor => accessor ?? (accessor = HttpContext?.RequestServices.GetService<IActionContextAccessor>());
        protected IHttpContextAccessor _ca => ca ?? (ca = HttpContext?.RequestServices.GetService<IHttpContextAccessor>());
        protected IMapper _mapper => mapper ?? (mapper = HttpContext?.RequestServices.GetService<IMapper>());

        [NonAction]
        public InternalServerErrorObjectResult InternalServerError()
        {
            return new InternalServerErrorObjectResult();
        }

        [NonAction]
        public InternalServerErrorObjectResult InternalServerError(object value)
        {
            return new InternalServerErrorObjectResult(value);
        }

    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public InternalServerErrorObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}