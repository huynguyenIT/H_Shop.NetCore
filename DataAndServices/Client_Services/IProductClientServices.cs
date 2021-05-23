using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Client_Services
{
    public interface IProductClientServices
    {
        Task< List<Product_Client>> GetAllProducts();

        Task< Product_Client> GetProductById(int id);

        Task< List<Dis_Product>> GetAllProductByPrice(int? gia, int? gia_);

        Task< List<Dis_Product>> GetAllProductByName(string name);

        Task< int> GetSoLuong(int id);
       
    }
}
