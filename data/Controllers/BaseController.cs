using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Data.Controllers
{
    public abstract class BaseController : ControllerBase
    {

        internal ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
    }
}