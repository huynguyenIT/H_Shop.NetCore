﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO_Model
{
    public class DTO_Dis_Product
    {
        public string _id { get; set; }
        public int ID_Discount { get; set; }
        public string Content { get; set; }
        public Nullable<double> Price_Dis { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        
       // public string Id_SanPham { get; set; }

      
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public string Photo { get; set; }
        public string Details { get; set; }
        public int Id_Item { get; set; }
    }
}
