using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpProject.API.Models.MongoSettings.Contract;

namespace UpProject.API.Models.MongoSettings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}