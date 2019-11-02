using System;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Data.Services.DataAccess
{
    public abstract class BaseDataAccessService : BaseService
    {
        internal IMongoDatabase _database;
        
        public BaseDataAccessService(ILogger<BaseDataAccessService> logger) : base(logger)
        {
            var mongoConnectionString = Environment.GetEnvironmentVariable("MONGO_CONN");

            var client = new MongoClient(mongoConnectionString);
            _database = client.GetDatabase("DockerToDo");
        }
    }
}