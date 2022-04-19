using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UpProject.API.Models.Base.Contract
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int64)]
        ulong Id { get; set; }

        DateTime CreatedAt { get; }
    }
}