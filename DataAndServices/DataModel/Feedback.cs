using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.DataModel
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string SDT { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string Details { get; set; }
    }
}
