using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.DTO_Ad
{
    public class DTO_Item
    {
       // public string Id_SanPham { get; set; }

        public int? Quantity { get; set; }

        public virtual DTO_Product Product { get; set; }
    }
}
