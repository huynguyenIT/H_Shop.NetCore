﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
   public class DTO_Checkout_Order
    {
        //    public string _id { get; set; }
        //    public int ID { get; set; }

        //    public int Id_KH { get; set; }

        //    public int Id_SanPham { get; set; }

        //    [StringLength(50)]
        //    public string TenSP { get; set; }

        //    public int? SoLuong { get; set; }

        //    public double? Gia { get; set; }

        //    public DateTime? NgayTao { get; set; }
        //    public string TrangThai { get; set; }

        //   // public virtual Checkout_Customer Checkout_Customer { get; set; }
        //[BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        // public string _id { get; set; }
        ////public int ID { get; set; }

        //public ObjectId Id_KH { get; set; }

        public string Id_SanPham { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }

        //public DateTime? NgayTao { get; set; }
        //public string TrangThai { get; set; }
    }
}
