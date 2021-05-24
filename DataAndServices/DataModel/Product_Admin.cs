﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.DataModel
{
    public class Product_Admin
    {
        public Product_Admin()
        {
            Photo = "~/images_product/ap.jpg";
        }
        
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public int Id_SanPham { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Price { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }
        //public HttpPostedFileBase ImageUpload { get; set; }

        public string Details { get; set; }

        public int Id_Item { get; set; }

        // public virtual DTO_Item Item { get; set; }

        //public virtual Item_Type Item_Type { get; set; }
    }
}
