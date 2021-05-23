using DataAndServices.Admin_Services.Products;
using DataAndServices.CommonModel;
using DataAndServices.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Admin
{
    [Route("api/Products_Ad")]
    [ApiController]
    public class Products_AdController : ControllerBase
    {
        private readonly IProductService _productService;
        public Products_AdController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProductById/{Id}")]
        public async Task<IActionResult> GetProductById(string Id)
        {
           var proById= await _productService.GetProductById(Id);
            return Ok(proById);
        }
        [HttpGet]
        [Route("GetProductItemById/{Id}")]
        public IActionResult GetProductItemById(int Id)
        {
           var proItemById=  _productService.GetProductItemById(Id);
            return Ok(proItemById);
        }
        [HttpGet]
        [Route("GetProductItemById_admin/{Id}")]
        public async Task<IActionResult> GetProductItemById_Admin(int Id)
        {
            var proItemById= await _productService.GetProductItemById_admin(Id);
            return Ok(proItemById);
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var listPro= await _productService.GetAllProducts();
            return Ok(listPro);
        }
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var listPro = await _productService.GetAllProductItem();
            return Ok(listPro);
        }

       
        [HttpGet]
        [Route("GetAllProductByIdItem/{id}")]
        public async Task<IActionResult> GetAllProductByIdItem(int id)
        {
           var listProItemById= await _productService.GetProductById_Item(id);
            return Ok(listProItemById);
        }

     
        [HttpGet]
        [Route("GetAllProductByType")]
        public async Task<IActionResult> GetAllProductByType()
        {
           var listlistProItem=  await _productService.GetAllProductItem_Type();
            return Ok(listlistProItem);
        }
        [Route("CreateProduct")]
        public async Task<int> CreateProduct(Product_Item_Type dTO_Product_Item)
        {
            return await _productService.CreateProduct(dTO_Product_Item);
        }
        [Route("UpdateProduct")]
        public async Task<int> UpdateProduct(Product_Item_Type dTO_Product_Item)
        {
            return await _productService.UpdateProduct(dTO_Product_Item);
        }
       

        [Route("DeleteProduct/{id}")]
        public async Task <bool> DeleteProduct(int id)
        {
            return await _productService.DeleteAccount(id);
        }
        [Route("UpdateQuantityItem")]
        public  async Task<bool> UpdateQuantityItem(Item item)
        {
            return await _productService.UpdateQuantityItem(item);
        }

        [HttpGet]
        [Route("GetAllProduct_Discount")]
        public async Task<IActionResult> GetAllProduct_Discount()
        {
            var listProDis= await _productService.GetAllProduct_Discount();
            return Ok(listProDis);
        }
        [HttpGet]
        [Route("GetProduct_DiscountById/{id}")]
        public async Task<IActionResult> GetProduct_DiscountById(int id)
        {
            var proDisById= await _productService.GetProduct_DiscountById(id);
            return Ok(proDisById);
        }
        [Route("CreateProduct_Discount")]
        public async Task< bool> CreateProduct_Discount(Discount_Product dTO_Product_Item)
        {
            return await _productService.InsertProduct_Discount(dTO_Product_Item);
        }
    }
}
