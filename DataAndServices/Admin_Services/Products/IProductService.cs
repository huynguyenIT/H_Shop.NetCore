using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.Products
{
    public interface IProductService
    {
        Task<List<Product_Admin>> GetAllProducts();


        Task<List<Product_Item_Type>> GetAllProductItem();


        Task<List<List<Dis_Product>>> GetAllProductItem_Type();

        Task<Product_Admin> GetProductById(string id);


        Task<List<Dis_Product>> GetProductById_Item(int id);

        Product_Item_Type GetProductItemById(int id);

        Task<Product_Item_Type> GetProductItemById_admin(int id);

        Product_Item_Type GetProductItemById2(string id);

        Task<List<Product_Item_Type>> GetProductItemByPageList();

        Task<List<Product_Item_Type>> GetProductItemById_client(int id);


        Task<int> CreateProduct(Product_Item_Type dTO_Account);

        Task<bool> DeleteAccount(int id);


        Task<int> UpdateProduct(Product_Item_Type dTO_Account);














        Task<bool> UpdateQuantityItem(Item item);



        Task<Dis_Product> GetProduct_DiscountById(int id);


        Task<List<Dis_Product>> GetAllProduct_Discount();


        Task<bool> InsertProduct_Discount(Discount_Product tO_Dis_Product);
      
    }
}
