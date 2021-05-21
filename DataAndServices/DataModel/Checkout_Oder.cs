using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.DataModel
{
    public class Checkout_Oder
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int ID { get; set; }

        public int Id_KH { get; set; }

        public int Id_SanPham { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }

        public DateTime? NgayTao { get; set; }
        public string TrangThai { get; set; }
    }
}
