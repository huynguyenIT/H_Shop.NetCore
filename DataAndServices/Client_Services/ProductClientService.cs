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
        private readonly IMongoCollection<Item> _dbItem;
        private readonly IMongoCollection<Discount_Product> _dbDis;
        private DataContext db = new DataContext("mongodb://localhost:27017", "OnlineShop");
        public ProductClientService(DataContext db)
        {
            _db = db.GetProductClientCollection();
            _dbItem = db.GetItemCollection();
            _dbDis = db.GetDiscountProductCollection();
        }
        public List<Dis_Product> GetAllProductByName(string name)
        {
            var discountCollection = db.GetDiscountProductCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from dis in discountCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on dis._id equals product._id

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





                               }).Where(s => s.Name.StartsWith(name)).ToList();
           

            return Info;
        }

        public List<Dis_Product> GetAllProductByPrice(int? gia, int? gia_)
        {
            var discountCollection = db.GetDiscountProductCollection();
            var productCollection = db.GetProductClientCollection();
            var Info = (from dis in discountCollection.AsQueryable()
                        join product in productCollection.AsQueryable() on dis._id equals product._id

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





                              });
            List<Dis_Product> dis_Product = new List<Dis_Product>();
            List<Dis_Product> dis_Product2 = new List<Dis_Product>();
            Dis_Product dis_Product3 = new Dis_Product();
            Dis_Product dis_Product4 = new Dis_Product();
            List<Dis_Product> dis_Product5 = new List<Dis_Product>();
            List<Dis_Product> dis_Product6 = new List<Dis_Product>();



            foreach (var item in Info)
            {
                //dis_Product.Add(item);
                if (GetPriceDiscountById(Convert.ToInt32(item.Id_SanPham)) != 0)
                {
                    //item.Price = Convert.ToInt32(GetPriceDiscountById((Convert.ToInt32(item.Id_SanPham))));

                    bool dis_Product7 = (item.Price_Dis <= gia_ && item.Price_Dis >= gia);
                    if (dis_Product7 == true)
                    {
                        dis_Product5.Add(item);
                    }

                }
                else
                {
                    bool dis_Product8 = (item.Price <= gia_ && item.Price >= gia);
                    if (dis_Product8 == true)
                    {
                        dis_Product2.Add(item);
                    }

                }





            }
            dis_Product6.AddRange(dis_Product2);
            dis_Product6.AddRange(dis_Product5);



            return dis_Product6;
        }
        public double GetPriceDiscountById(int id)
        {
            DateTime dateTime = DateTime.Today;
            var item_discount = _dbDis.Find(t => t.Id_SanPham == id && t.End.Value >= dateTime).FirstOrDefault();

            if (item_discount != null && item_discount.Price_Dis != null)
            {
                return Convert.ToDouble(item_discount.Price_Dis);
            }
            return 0;
        }

        public async Task<List<Product_Client>> GetAllProducts()
        {
            return await _db.Find(s => true).ToListAsync();
        }

        public Task<Product_Client> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetSoLuong(int id)
        {
            var temp = await _dbItem.Find(s => s.Id_SanPham == id).FirstOrDefaultAsync();
            if (temp != null)
            {
                return (int)temp.Quantity; // vidu: 0.3 0.4
            }
            return 0;
        }
    }
}
