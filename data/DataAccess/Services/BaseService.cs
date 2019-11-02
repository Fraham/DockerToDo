using Microsoft.Extensions.Logging;

namespace Data.Services
{
    public abstract class BaseService
    {
        internal readonly ILogger<BaseService> _logger;

        public BaseService(ILogger<BaseService> logger){
            _logger = logger;
        }
    }
}