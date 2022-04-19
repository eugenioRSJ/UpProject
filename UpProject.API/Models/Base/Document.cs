using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using UpProject.API.Models.Base.Contract;

namespace UpProject.API.Models.Base
{
    public class Document : IDocument
    {
        public ulong Id { get; set; }

        public DateTime CreatedAt => DateTime.Now;
    }
}