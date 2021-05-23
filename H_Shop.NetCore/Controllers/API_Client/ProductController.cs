using DataAndServices.Client_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_Shop.NetCore.Controllers.API_Client
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductClientServices _productClientService;
        public ProductController(IProductClientServices productClientServices)
        {
            _productClientService = productClientServices;
        }
        [HttpGet]
        [Route("GetAllproducts")]
        public JsonResult<List<DTO_Product_Client>> GetAllProducts()
        {
            return Json<List<DTO_Product_Client>>(bLL_Product.GetAllProducts());
        }
        //[HttpGet]
        //[Route("GetAllProductByPrice/{giaMin:int}/{giaMax:int}")]
        //public JsonResult<List<DTO_Product_Client>> GetAllProductByPrice(int giaMin,int giaMax)
        //{
        //    return Json<List<DTO_Product_Client>>(bLL_Product.GetAllProductByPrice(giaMin, giaMax));
        //}
        [HttpGet]
        [Route("GetAllProductByPrice/{giaMin:int}/{giaMax:int}")]
        public JsonResult<List<DTO_Dis_Product>> GetAllProductByPrice(int giaMin, int giaMax)
        {
            return Json<List<DTO_Dis_Product>>(bLL_Product.GetAllProductByPrice(giaMin, giaMax));
        }
        //[HttpGet]
        //[Route("GetAllProductByName/{name}")]
        //public JsonResult<List<DTO_Product_Client>> GetAllProductByName(string name)
        //{
        //    return Json<List<DTO_Product_Client>>(bLL_Product.GetAllProductByName(name));
        //}
        [HttpGet]
        [Route("GetAllProductByName/{name}")]
        public JsonResult<List<DTO_Dis_Product>> GetAllProductByName(string name)
        {
            return Json<List<DTO_Dis_Product>>(bLL_Product.GetAllProductByName(name));
        }


        [HttpGet]
        [Route("GetAllProductItemByPageList")]
        public JsonResult<List<DTO_Product_Item_Type>> GetAllProductItemByPageList()
        {
            return Json<List<DTO_Product_Item_Type>>(BLL_Products.GetProductItemByPageList());
        }
        [Route("GetAllProductItem")]
        public JsonResult<List<DTO_Product_Item_Type>> GetAllProductItem()
        {
            return Json<List<DTO_Product_Item_Type>>(BLL_Products.GetAllProductItem());
        }
        [HttpGet]
        [Route("GetProductById/{Id:int}")]
        public JsonResult<DTO_Product_Client> GetProductById(int Id)
        {
            return Json<DTO_Product_Client>(bLL_Product.GetProductById(Id));
        }
        [HttpGet]
        [Route("GetAllProductByIdItemClient/{id:int}")]
        public JsonResult<List<DTO_Product_Item_Type>> GetAllProductByIdItem(int id)
        {
            return Json<List<DTO_Product_Item_Type>>(BLL_Products.GetProductItemById_client(id));
        }
        [HttpGet]
        [Route("GetProductItemById/{Id:int}")]
        public JsonResult<DTO_Product_Item_Type> GetProductItemById(int Id)
        {
            return Json<DTO_Product_Item_Type>(BLL_Products.GetProductItemById(Id));
        }
        [Route("GetSoLuong/{Id:int}")]
        public int GetSoLuong(int Id)
        {
            return bLL_Product.GetSoLuong(Id);
        }
    }
}
