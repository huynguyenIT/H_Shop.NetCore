using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.DataModel
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id_SanPham { get; set; }

        public int? Quantity { get; set; }

        //public virtual Product_Admin Product_Admin { get; set; }
    }
}
