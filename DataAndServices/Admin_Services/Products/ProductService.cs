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
        private readonly IMongoCollection<Item_type> _dbItemtype;
        private readonly DataContext db = new DataContext("mongodb://localhost:27017", "OnlineShop");

        public ProductService(DataContext db)
        {
            _db = db.GetProductAdminCollection();
            _dbDis = db.GetDiscountProductCollection();
            _dbItem = db.GetItemCollection();
            _dbItemtype = db.GetItem_TypeCollection();
        }
        public double GetPriceDiscountByIdList(int id)
        {
            DateTime dateTime = DateTime.Today;
            var item_discount = _dbDis.Find(t => t.Id_SanPham == id && t.End.Value >= dateTime).ToList();
            foreach (var item in item_discount)
            {
                if (item != null && item.Price_Dis != null)
                    return Convert.ToDouble(item.Price_Dis);
            }

            return 0;
        }

        public int CreateProduct(Product_Item_Type product_Item_Type)
        {
            try
            {
                Product_Admin products = new Product_Admin();
                products.Id_Item = product_Item_Type.Id_Item;
                //products.Id_SanPham = product_Item_Type.Id_SanPham;
                products.Name = product_Item_Type.Name;
                products.Photo = product_Item_Type.Photo;
                products.Price = product_Item_Type.Price;
                products.Details = product_Item_Type.Details;

                Item item = new Item();
                //item.Id_SanPham = product_Item_Type.Id_SanPham;
                item.Quantity = product_Item_Type.Quantity;

                _db.InsertOne(products);


                 item._id = products._id;

                _dbItem.InsertOne(item);
                Discount_Product dis = new Discount_Product();
                dis._id = item._id;
                _dbDis.InsertOne(dis);
                return 1;

            }
            catch
            {
                return 0;
            }




            
            
        }

        public bool DeleteAccount(string id)
        {
            try
            {
                
                var deleteFilter = Builders<Product_Admin>.Filter.Eq("_id", id);
                var deleteFilter2 = Builders<Item>.Filter.Eq("_id", id);
                var deleteFilter3 = Builders<Discount_Product>.Filter.Eq("_id", id);

                _db.DeleteOne(deleteFilter);
               
                _dbItem.DeleteOne(id);
                _dbDis.DeleteOne(id);
            
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Product_Item_Type>> GetAllProductItem()
        {
            var itemCollection =  db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var infoProduct = from item in itemCollection.AsQueryable()
                              join product in productCollection.AsQueryable() on item.Id_SanPham equals product.Id_SanPham

                              select new Product_Item_Type()
                              {
                                  Id_SanPham = product.Id_SanPham,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Details = product.Details,
                                  Photo = product.Photo,
                                  Id_Item = product.Id_Item,
                                  Quantity = item.Quantity




                              };
            return await infoProduct.ToListAsync();
        }

        public List<List<Dis_Product>> GetAllProductItem_Type()
        {
            List<Item_type> item_Types = new List<Item_type>();
            List<List<Dis_Product>> productsByType = new List<List<Dis_Product>>();
            item_Types = _dbItemtype.Find(s=>true).ToList();
            foreach (Item_type item in item_Types)
            {

                List<Dis_Product> products = GetProductById_Item(item.Id_Item);
                productsByType.Add(products);
            }
            return productsByType.ToList();
        }

        public async Task<List<Product_Admin>> GetAllProducts()
        {
            return await _db.Find(s => true).ToListAsync();
        }

        public List<Dis_Product> GetAllProduct_Discount()
        {
          var test=  _db.AsQueryable().Select(x => x.Id_SanPham==15).FirstOrDefault();

            //var discount_Products = (IQueryable<Discount_Product>)db.GetDiscountProductCollection();
            //var Products = (IQueryable<Product_Client>)db.GetDiscountProductCollection();
            //var joinResult = discount_Products.Join(Products,
            //    s => s.Id_SanPham,
            //    o => o.Id_SanPham,
            //    (s, o) => new Dis_Product()
            //    {
            //        Id_SanPham = o.Id_SanPham,
            //        Name = o.Name,
            //        Price = o.Price,
            //        Details = o.Details,
            //        Photo = o.Photo,
            //        Id_Item = o.Id_Item,
            //        Content =s.Content,
            //        Price_Dis = s.Price_Dis,
            //        Start = s.Start,
            //        End = s.End
            //    });

            var discountCollection = db.GetDiscountProductCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from dis in discountCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on dis._id equals product._id

                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Dis_Product()
                        {
                            _id = dis._id,
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




                        });

            return  Info.ToList();


           
        }

        public async Task<Product_Admin> GetProductById(string id)
        {

            return await _db.Find(s => s._id == id).FirstOrDefaultAsync();
        }

        public List<Dis_Product> GetProductById_Item(int id)
        {
            var discountCollection = db.GetDiscountProductCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from dis in discountCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on dis._id equals product._id
                        where product.Id_Item==id
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Dis_Product()
                        {
                            _id = dis._id,
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




                        });

            return Info.ToList();

        }

        public  Product_Item_Type GetProductItemById(string id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info =  (from item in itemCollection.AsQueryable()
                       join product in productCollection.AsQueryable() on item._id equals product._id
                       where  item._id == id
                       select new Product_Item_Type()
                       {
                           _id = item._id,
                           Id_SanPham = item.Id_SanPham,
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

        private double GetPriceDiscountById(int id)
        {
            DateTime dateTime = DateTime.Today;
            var item_discount = _dbDis.Find(t => t.Id_SanPham == id && t.End.Value >= dateTime).FirstOrDefault();

            if (item_discount != null && item_discount.Price_Dis != null)
            {
                return Convert.ToDouble(item_discount.Price_Dis);
            }
            return 0;
        }

        public Product_Item_Type GetProductItemById2(string id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item._id equals product._id
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Product_Item_Type()
                        {
                            _id = product._id,
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
    

        public Product_Item_Type GetProductItemById_admin(string id)
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item._id equals product._id
                        where item._id == id 
                        select new Product_Item_Type()
                        {
                            _id = item._id,
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Quantity = item.Quantity




                        });

            return Info.FirstOrDefault();
            
        }

        public List<Product_Item_Type> GetProductItemById_client(int id)
        {
            var itemTypeCollection = db.GetItem_TypeCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemTypeCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item.Id_Item equals product.Id_Item
                        where  item.Id_Item == id
                        select new Product_Item_Type()
                        {
                            _id = item._id,
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Type_Product = item.Type_Product




                        }).ToList();

            foreach (var item in Info)
            {
                if (GetPriceDiscountByIdList(item.Id_SanPham) != 0)
                {
                    item.Price = Convert.ToInt32(GetPriceDiscountById(item.Id_SanPham));
                }
            }
            return  Info.ToList();
        }

        public List<Product_Item_Type> GetProductItemByPageList()
        {
            var itemCollection = db.GetItemCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from item in itemCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on item._id equals product._id
                        orderby item._id
                        //where product.Id_SanPham == id && item.Id_SanPham == id
                        select new Product_Item_Type()
                        {
                            _id = item._id,
                            Id_SanPham = product.Id_SanPham,
                            Name = product.Name,
                            Price = product.Price,
                            Details = product.Details,
                            Photo = product.Photo,
                            Id_Item = product.Id_Item,
                            Quantity = item.Quantity




                        });

            return  Info.ToList();
        }

        public Dis_Product GetProduct_DiscountById(string id)
        {
            var discountProCollection = db.GetDiscountProductCollection();
            var productCollection = db.GetProductClientCollection();
            var infoProduct_discount = from dis in discountProCollection.AsQueryable()
                                       join product in productCollection.AsQueryable() on dis._id equals product._id
                                       where dis._id == id 
                                       select new Dis_Product()
                                       {
                                           _id = dis._id,
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
            return  infoProduct_discount.FirstOrDefault();
        }

        public bool InsertProduct_Discount(Discount_Product custom)
        {

            Discount_Product prodItem =  _dbDis.Find(p => p._id == custom._id).FirstOrDefault();
            if (prodItem != null)
            {
                var eqfilter = Builders<Discount_Product>.Filter.Where(s => s._id == custom._id);
                var update = Builders<Discount_Product>.Update.Set(s => s._id, custom._id)
                    .Set(s => s.Price_Dis, custom.Price_Dis)
                    .Set(s => s.Content, custom.Content)
                    .Set(s => s.Start, custom.Start)
                    .Set(s => s.End, custom.End);

                var options = new UpdateOptions { IsUpsert = true };
                _dbDis.UpdateOneAsync(eqfilter, update, options).ConfigureAwait(false);

              
                
                return true;


            }
            else
            {
                _dbDis.InsertOne(custom);
            }
            
            return false;


        }

     

        //public bool UpdateQuantityItem(string _id,int quantity)
        //{
        //    var itemNow =  _dbItem.Find(s => s._id == _id).FirstOrDefault();

           
        //    if (itemNow != null)
        //    {
        //        var quantityNow = itemNow.Quantity; // vidu: 0.3 0.4
        //        var quantityPay = quantityNow - quantity;
               
        //        if (quantityNow - quantityPay > 0)
        //        {

                    
        //            itemNow.Quantity = quantityPay;
        //            var eqfilter = Builders<Item>.Filter.Where(s => s._id == _id);
        //            var update = Builders<Item>.Update.Set(s => s.Quantity, itemNow.Quantity);
                    

        //            var options = new UpdateOptions { IsUpsert = true };
        //            _dbItem.UpdateOne(eqfilter, update, options);

        //            //db.SaveChanges();
        //            return true;
        //        }

        //    }
        //    return false;
        //}

        public bool UpdateProduct(Product_Item_Type custom)
        {
            try
            {





                var eqfilter = Builders<Product_Admin>.Filter.Where(s => s._id == custom._id);
                var update = Builders<Product_Admin>.Update.Set(s => s.Name, custom.Name)
                    .Set(s => s.Photo, custom.Photo)
                    .Set(s => s.Details, custom.Details)
                    .Set(s => s.Price, custom.Price)
                    .Set(s => s._id, custom._id)
                    .Set(s => s.Id_Item, custom.Id_Item);

                var options = new UpdateOptions { IsUpsert = true };
                _db.UpdateOneAsync(eqfilter, update, options).ConfigureAwait(false);

                var eqfilter2 = Builders<Item>.Filter.Where(s => s._id == custom._id);
                var update2 = Builders<Item>.Update.Set(s => s._id, custom._id)
                    .Set(s => s.Quantity, custom.Quantity);
                   

                var options2 = new UpdateOptions { IsUpsert = true };
                _dbItem.UpdateOneAsync(eqfilter2, update2, options2).ConfigureAwait(false);

                return true;
            }

               
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
