using DataAndServices.CommonModel;
using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Client_Services
{
    public class ProductClientService : IProductClientServices
    {
        private readonly IMongoCollection<Product_Client> _db;
        public ProductClientService(DataContext db)
        {
            _db = db.GetProductClientCollection();
        }
        public Task<List<Dis_Product>> GetAllProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dis_Product>> GetAllProductByPrice(int? gia, int? gia_)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product_Client>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product_Client> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetSoLuong(int id)
        {
            throw new NotImplementedException();
        }
    }
}
