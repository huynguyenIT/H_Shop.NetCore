using DataAndServices.CommonModel;
using DataAndServices.Data;
using DataAndServices.DataModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAndServices.Admin_Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product_Admin> _db;
        private readonly IMongoCollection<Discount_Product> _dbDis;
        private readonly IMongoCollection<Item> _dbItem;
        private readonly DataContext db = new DataContext("mongodb://localhost:27017", "OnlineShop");

        public ProductService(DataContext db)
        {
            _db = db.GetProductAdminCollection();
            _dbDis = db.GetDiscountProductCollection();
            _dbItem = db.GetItemCollection();
        }

        public Task<int> CreateProduct(Product_Item_Type dTO_Account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product_Item_Type>> GetAllProductItem()
        {
            throw new NotImplementedException();
        }

        public Task<List<List<Dis_Product>>> GetAllProductItem_Type()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product_Admin>> GetAllProducts()
        {
            return await _db.Find(s => true).ToListAsync();
        }

        public  Task<List<Dis_Product>> GetAllProduct_Discount()
        {
            throw new NotImplementedException();
        }

        public async Task<Product_Admin> GetProductById(string id)
        {

            return await _db.Find(s => s._id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Dis_Product>> GetProductById_Item(int id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item.Id_SanPham equals product.Id_SanPham
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Product_Item_Type()
                        {
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Quantity = item.Quantity




                        }).FirstOrDefault();

            return Info;

        }

        public  Product_Item_Type GetProductItemById(int id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info =  (from item in itemCollection.AsQueryable()
                       join product in productCollection.AsQueryable() on item.Id_SanPham equals product.Id_SanPham
                       where product.Id_SanPham == id && item.Id_SanPham == id
                       select new Product_Item_Type()
                       {
                           Id_SanPham = product.Id_SanPham,
                           Name = product.Name,
                           Price = product.Price,
                           Details = product.Details,
                           Photo = product.Photo,
                           Id_Item = product.Id_Item,
                           Quantity = item.Quantity




                       }).FirstOrDefault();
            if (GetPriceDiscountById(Info.Id_SanPham) != 0)
            {
                Info.Price = Convert.ToInt32(GetPriceDiscountById(Info.Id_SanPham));
            }
            return Info;
        }

        private int GetPriceDiscountById(object id_SanPham)
        {
            throw new NotImplementedException();
        }

        public Product_Item_Type GetProductItemById2(string id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item.Id_SanPham equals product.Id_SanPham
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Product_Item_Type()
                        {
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Quantity = item.Quantity




                        }).FirstOrDefault();
           
            return  Info;
        }
    

        public Task<Product_Item_Type> GetProductItemById_admin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product_Item_Type>> GetProductItemById_client(int id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item.Id_SanPham equals product.Id_SanPham
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Product_Item_Type()
                        {
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Quantity = item.Quantity




                        }).FirstOrDefault();

            return Info;
        }

        public Task<List<Product_Item_Type>> GetProductItemByPageList()
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item.Id_SanPham equals product.Id_SanPham
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Product_Item_Type()
                        {
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Quantity = item.Quantity




                        }).FirstOrDefault();

            return Info;
        }

        public async Task<Dis_Product> GetProduct_DiscountById(int id)
        {
            var discountProCollection = db.GetDiscountProductCollection();
            var productCollection = db.GetProductClientCollection();
            var infoProduct_discount = from dis in discountProCollection.AsQueryable()
                                       join product in productCollection.AsQueryable() on dis.Id_SanPham equals product.Id_SanPham
                                       where product.Id_SanPham == id && dis.Id_SanPham == id
                                       select new Dis_Product()
                                       {
                                           Id_SanPham = product.Id_SanPham,
                                           Name = product.Name,
                                           Price = product.Price,
                                           Details = product.Details,
                                           Photo = product.Photo,
                                           Id_Item = product.Id_Item,
                                           Content = dis.Content,
                                           Price_Dis = dis.Price_Dis,
                                           Start = dis.Start,
                                           End = dis.End




                                       };
            return await infoProduct_discount.FirstOrDefaultAsync();
        }

        public async Task<bool> InsertProduct_Discount(Discount_Product dis)
        {

            Discount_Product prodItem = await _dbDis.Find(p => p.Id_SanPham == dis.Id_SanPham).FirstOrDefaultAsync();
            if (prodItem != null)
            {
                prodItem.Id_SanPham = dis.Id_SanPham;
                prodItem.Price_Dis = dis.Price_Dis;
                prodItem.Content = dis.Content;
                prodItem.Start = dis.Start;
                prodItem.End = dis.End;
                await _dbDis.InsertOneAsync(prodItem);
                return true;


            }
            
            return false;


        }

        public Task<int> UpdateProduct(Product_Admin productItem, Item item)
        {

            try
            {



                Product_Admin prodItem = _db.Find(p => p.Id_SanPham == productItem.Id_SanPham).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.Id_SanPham = productItem.Id_SanPham;
                    prodItem.Name = productItem.Name;
                    prodItem.Price = productItem.Price;
                    prodItem.Photo = productItem.Photo;
                    prodItem.Details = productItem.Details;
                    prodItem.Id_Item = productItem.Id_Item;

                }

                Item it = db.Items.Where(p => p.Id_SanPham == productItem.Id_SanPham).FirstOrDefault();
                if (it != null)
                {
                    it.Id_SanPham = item.Id_SanPham;
                    it.Quantity = item.Quantity;

                }

                try
                {


                    int result = db.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -2;
                }
            }
        }

        public async Task<bool> UpdateQuantityItem(string id ,int quantity)
        {
            var itemNow = await _dbItem.Find(s => s._id == id).FirstOrDefaultAsync();

            //var quantityNow;
            if (itemNow != null)
            {
                var quantityNow = itemNow.Quantity; // vidu: 0.3 0.4
                var quantityPay = quantityNow - quantity;
                //if(itemNow.Quantity - quantity > 0)
                if (quantityNow - quantityPay > 0)
                {
                    //Item item = new Item();
                    itemNow.Quantity = quantityPay;
                    //item.Id_SanPham = id;
                    //db.SaveChanges();
                    return true;
                }

            }
            return false;
        }
    }
}
