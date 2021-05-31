using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.DataModel
{
    public class Item_Client
    {
        List<Item_Client> items = new List<Item_Client>();
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        //public string Id_SanPham { get; set; }

        public int? Quantity { get; set; }

        //public virtual Product_Client Product { get; set; }
        public int Total_Quantity()
        {
            return (int)items.Sum(s => s.Quantity);
        }
    }
}
